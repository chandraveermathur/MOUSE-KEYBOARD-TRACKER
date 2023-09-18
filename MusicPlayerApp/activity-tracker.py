from pynput.mouse import Listener as MouseListener
from pynput.keyboard import Listener as KeyListener
import os
import time

# Create a folder named 'mouse-logs' if it doesn't exist
log_folder = "mouse-logs"
os.makedirs(log_folder, exist_ok=True)

# Generate a new log file with a unique name using timestamp
log_file_path = os.path.join(log_folder, f"mouse_activity_log_{int(time.time())}.txt")

# Function to write data to the log file
def write_to_log(data):
    with open(log_file_path, "a") as log_file:
        log_file.write(f"{time.strftime('%Y-%m-%d %H:%M:%S')} - {data}\n")

# Function to handle mouse events
def on_move(x, y):
    write_to_log(f"Mouse moved to ({x}, {y})")

def on_click(x, y, button, pressed):
    action = "Pressed" if pressed else "Released"
    write_to_log(f"Mouse {action} at ({x}, {y}) with button {button}")

def on_scroll(x, y, dx, dy):
    write_to_log(f"Mouse scrolled at ({x}, {y}) with delta ({dx}, {dy})")

# Function to handle keyboard events
def on_press(key):
    try:
        write_to_log(f"Key pressed: {key.char}")
    except AttributeError:
        write_to_log(f"Special key pressed: {key}")

def on_release(key):
    pass

# Start listening to mouse and keyboard events
with MouseListener(on_move=on_move, on_click=on_click, on_scroll=on_scroll) as mouse_listener, \
     KeyListener(on_press=on_press, on_release=on_release) as key_listener:

    # Run the listeners in the background
    mouse_listener.join()
    key_listener.join()
