#!/usr/bin/env bash
set -e

echo "Installing graphical dependencies..."
sudo apt-get update -y
sudo apt-get install -y xvfb x11vnc fluxbox websockify novnc

echo "Starting virtual screen..."
get_pid_on_port() {
	# return PID of process listening on given port (TCP), or empty
	if command -v lsof >/dev/null 2>&1; then
		lsof -ti TCP:$1 || true
	else
		ss -ltnp 2>/dev/null | grep -E ":$1" | sed -n 's/.*pid=\([0-9]*\),.*/\1/p' || true
	fi
}

# If services from a previous run are still listening, kill them so the script can restart cleanly
for p in 5900 6080; do
	pid=$(get_pid_on_port $p)
	if [ -n "$pid" ]; then
		echo "Port $p in use by PID $pid — killing it to free the port"
		sudo kill -9 $pid || true
		sleep 0.25
	fi
done

Xvfb :1 -screen 0 1024x768x24 &
export DISPLAY=:1
fluxbox &

echo "Routing screen to browser..."
# start or restart x11vnc
x11vnc -display :1 -nopw -forever -shared -rfbport 5900 &
# start or restart websockify (noVNC)
websockify --web=/usr/share/novnc 6080 localhost:5900 &

echo "========================================="
echo "Aetherbourne is ready!"
echo "Go to your 'Ports' tab in VS Code."
echo "Click the 'Aetherbourne' port link."
echo "========================================="

echo "Building and launching Aetherbourne..."
cd /workspaces/Aetherbourne/Aetherbourne
if dotnet build Aetherbourne.csproj; then
	# run in background so the script continues to serve the GUI
	DISPLAY=${DISPLAY:-:1} dotnet run --project Aetherbourne.csproj &> /workspaces/Aetherbourne/aetherbourne.log &
	echo "Aetherbourne started (logs: /workspaces/Aetherbourne/aetherbourne.log)"
else
	echo "dotnet build failed. See output above." >&2
	exit 1
fi
