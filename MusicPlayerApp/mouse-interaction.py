from pynput.mouse import Listener
import time

# Define the path for the log file
log_file_path = "mouse_activity_log.txt"

# Function to write data to the log file
def write_to_log(data):
    with open(log_file_path, "a") as log_file:
        log_file.write(data + "\n")

# Function to handle mouse events
def on_move(x, y):
    write_to_log(f"Mouse moved to ({x}, {y})")

def on_click(x, y, button, pressed):
    action = "Pressed" if pressed else "Released"
    write_to_log(f"Mouse {action} at ({x}, {y}) with button {button}")

def on_scroll(x, y, dx, dy):
    write_to_log(f"Mouse scrolled at ({x}, {y}) with delta ({dx}, {dy})")

# Start listening to mouse events
with Listener(on_move=on_move, on_click=on_click, on_scroll=on_scroll) as listener:
    try:
        # Run the listener in the background
        listener.join()
    except KeyboardInterrupt:
        # Stop the listener on keyboard interrupt
        listener.stop()

# Add code here to run after the application is closed
