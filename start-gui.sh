#!/usr/bin/env bash
set -e

echo "Installing graphical dependencies..."
sudo apt-get update -y
sudo apt-get install -y xvfb x11vnc fluxbox websockify novnc

echo "Starting virtual screen..."
Xvfb :1 -screen 0 1024x768x24 &
export DISPLAY=:1
fluxbox &

echo "Routing screen to browser..."
x11vnc -display :1 -nopw -forever -shared -rfbport 5900 &
websockify --web=/usr/share/novnc 6080 localhost:5900 &

echo "========================================="
echo "GUI Environment is active!"
echo "Go to your 'Ports' tab in VS Code."
echo "Change the visibility of Port 6080 to PUBLIC."
echo "========================================="
