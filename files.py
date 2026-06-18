from pathlib import Path
import hashlib
import mimetypes
import math
import sys

# ============================================================
# CONFIG
# ============================================================

ROOT_DIR = Path(".").resolve()
OUTPUT_FILE = "project_dump.md"

MAX_FILE_SIZE_MB = 5
MAX_TOTAL_FILES = 5000

CHUNK_SIZE = 12000

SKIP_HIDDEN = True

SKIP_DIRS = {
    ".git",
    ".github",
    ".idea",
    ".vscode",
    "__pycache__",
    ".pytest_cache",
    ".mypy_cache",
    ".tox",
    ".venv",
    "venv",
    "env",
    "node_modules",
    "dist",
    "build",
    "target",
    ".next",
    ".nuxt",
    ".cache",
    "coverage",
    "vendor",
}

SKIP_FILENAMES = {
    ".DS_Store",
    "Thumbs.db",
    "package-lock.json",
    "yarn.lock",
    "pnpm-lock.yaml",
    "poetry.lock",
    "Cargo.lock",
}

SKIP_EXTENSIONS = {
    ".png", ".jpg", ".jpeg", ".gif", ".webp",
    ".bmp", ".ico", ".svg",
    ".mp4", ".avi", ".mov", ".mkv",
    ".mp3", ".wav", ".ogg",
    ".zip", ".rar", ".7z", ".tar", ".gz",
    ".exe", ".dll", ".so", ".dylib",
    ".pdf",
    ".woff", ".woff2", ".ttf", ".otf",
    ".class",
    ".pyc",
}

# ============================================================
# HELPERS
# ============================================================

def estimate_tokens(text: str) -> int:
    return math.ceil(len(text) / 4)


def sha256(path: Path):
    h = hashlib.sha256()

    with open(path, "rb") as f:
        while chunk := f.read(65536):
            h.update(chunk)

    return h.hexdigest()


def detect_language(path: Path):
    ext = path.suffix.lower()

    mapping = {
        ".py": "python",
        ".js": "javascript",
        ".ts": "typescript",
        ".tsx": "tsx",
        ".jsx": "jsx",
        ".json": "json",
        ".yaml": "yaml",
        ".yml": "yaml",
        ".html": "html",
        ".css": "css",
        ".md": "markdown",
        ".txt": "text",
        ".java": "java",
        ".c": "c",
        ".cpp": "cpp",
        ".h": "c",
        ".hpp": "cpp",
        ".cs": "csharp",
        ".rs": "rust",
        ".go": "go",
        ".sh": "bash",
        ".toml": "toml",
        ".xml": "xml",
    }

    return mapping.get(ext, "")


def is_binary(path: Path):
    try:
        with open(path, "rb") as f:
            chunk = f.read(8192)

        if b"\x00" in chunk:
            return True

        text_chars = sum(
            (32 <= b <= 126) or b in b"\n\r\t"
            for b in chunk
        )

        if len(chunk) == 0:
            return False

        return (text_chars / len(chunk)) < 0.70

    except:
        return True


def should_skip(path: Path):
    if path.name in SKIP_FILENAMES:
        return True

    if path.suffix.lower() in SKIP_EXTENSIONS:
        return True

    if SKIP_HIDDEN and path.name.startswith("."):
        return True

    if any(part in SKIP_DIRS for part in path.parts):
        return True

    return False


def chunk_text(text, chunk_size):
    for i in range(0, len(text), chunk_size):
        yield text[i:i + chunk_size]


# ============================================================
# BUILD TREE
# ============================================================

tree_lines = []


def build_tree(path, prefix=""):
    try:
        items = sorted(
            [
                p for p in path.iterdir()
                if not should_skip(p)
            ],
            key=lambda x: (x.is_file(), x.name.lower())
        )
    except:
        return

    for i, item in enumerate(items):

        last = i == len(items) - 1

        connector = "└── " if last else "├── "

        tree_lines.append(
            f"{prefix}{connector}{item.name}"
        )

        if item.is_dir():
            extension = "    " if last else "│   "
            build_tree(item, prefix + extension)


# ============================================================
# COLLECT FILES
# ============================================================

files = []

for path in ROOT_DIR.rglob("*"):

    if not path.is_file():
        continue

    if should_skip(path):
        continue

    if is_binary(path):
        continue

    try:
        size_mb = path.stat().st_size / 1024 / 1024

        if size_mb > MAX_FILE_SIZE_MB:
            continue

    except:
        continue

    files.append(path)

files = sorted(files)

if len(files) > MAX_TOTAL_FILES:
    files = files[:MAX_TOTAL_FILES]

# ============================================================
# OUTPUT
# ============================================================

build_tree(ROOT_DIR)

total_size = 0
total_tokens = 0

with open(OUTPUT_FILE, "w", encoding="utf-8") as out:

    out.write("# Project Dump\n\n")

    out.write("## Summary\n\n")

    out.write(f"- Root: `{ROOT_DIR}`\n")
    out.write(f"- Files Included: {len(files):,}\n")
    out.write(f"- Max File Size: {MAX_FILE_SIZE_MB} MB\n")
    out.write(f"- Chunk Size: {CHUNK_SIZE:,} chars\n\n")

    out.write("---\n\n")

    out.write("## Directory Structure\n\n")

    out.write("```text\n")
    out.write("\n".join(tree_lines))
    out.write("\n```\n\n")

    out.write("---\n\n")

    for idx, path in enumerate(files, start=1):

        print(
            f"[{idx}/{len(files)}] {path.relative_to(ROOT_DIR)}",
            flush=True
        )

        try:
            content = path.read_text(
                encoding="utf-8",
                errors="replace"
            )
        except:
            continue

        size = path.stat().st_size
        tokens = estimate_tokens(content)

        total_size += size
        total_tokens += tokens

        rel = path.relative_to(ROOT_DIR)

        out.write(f"# FILE: `{rel}`\n\n")

        out.write("| Metric | Value |\n")
        out.write("|----------|----------|\n")
        out.write(f"| Size | {size:,} bytes |\n")
        out.write(f"| Lines | {content.count(chr(10)) + 1:,} |\n")
        out.write(f"| Tokens | {tokens:,} |\n")
        out.write(f"| SHA256 | `{sha256(path)}` |\n\n")

        lang = detect_language(path)

        chunks = list(chunk_text(content, CHUNK_SIZE))

        for chunk_num, chunk in enumerate(chunks, start=1):

            if len(chunks) > 1:
                out.write(
                    f"## Chunk {chunk_num}/{len(chunks)}\n\n"
                )

            out.write(f"```{lang}\n")
            out.write(chunk)
            out.write("\n```\n\n")

        out.write("---\n\n")

    out.write("# Final Statistics\n\n")
    out.write(f"- Total Files: {len(files):,}\n")
    out.write(f"- Total Size: {total_size:,} bytes\n")
    out.write(f"- Estimated Tokens: {total_tokens:,}\n")

print(f"\nCreated: {OUTPUT_FILE}")