import socket
import time
import numpy

host = "127.0.0.1"
port = 1025

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

server.bind((host, port))

server.listen(1)
commSocket = None

echo = False

while commSocket == None:
    commSocket, address = server.accept()
    print(f"Connected to {address}")


def sendMessage(message):
    commSocket.send(message.encode("utf-8"))

valid1commands = {1,2,3,4,5,6,7,8}
valid2commands = {1,2,3,4,5}
valid3commands = {1,2}

inputSize = 3*5*5

while True:
    message = commSocket.recv(1024).decode()

    if(echo):
        sendMessage(message)
    print(message)