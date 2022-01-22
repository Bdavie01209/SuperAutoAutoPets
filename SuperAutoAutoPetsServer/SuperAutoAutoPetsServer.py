
import socket
import sys

host = "127.0.0.1"
port = 9012

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

server.bind((host, port))

server.listen(1)

print("the server has been opened")

TeamPets = [["none", 0,0],["none", 0,0],["none", 0,0],["none", 0,0],["none", 0,0]]

turn = 0

currGold = 10;

currPetshop = [["none", 0,0],["none", 0,0],["none", 0,0],["none", 0,0],["none", 0,0]]

currFoodShop = [["none"],["none"]]

commSocket = None
# messages received should be in format 
# Code content
# CSU = current state update 
# CSU TeamSlot1Name attack Defence, teamslot2name attack Defence,teamslot3name attack Defence, teamslot4name attack Defence, teamslot5name attack Defence
# AHU = Attack Heath Update 
# AHU = attack1 heath1, attack 2 health 2, attack 3 health 3, attack 4 health 4, attack 5 health 5
def receivemessage(message):
    print(message[0:3])
    if(message[0:3] == "CSU"):
        messageinfo = message.split()
        updateCurrentPets(messageinfo[:][1:16])
    if(message[0:3] == "AHU"):



def updateCurrentPets(CSUString1through15):
    csu = CSUString1through15
    TeamPets[0] = [csu[0], int(csu[1]), int(csu[2])];
    TeamPets[1] = [csu[3], int(csu[4]), int(csu[5])];
    TeamPets[2] = [csu[6], int(csu[7]), int(csu[8])];
    TeamPets[3] = [csu[9], int(csu[10]), int(csu[11])];
    TeamPets[4] = [csu[12], int(csu[13]), int(csu[14])];



def printCurrentTeam():
    for pets in TeamPets:
        print(f"{pets[0]} : {pets[1]} Attack / {pets[2]} Health")

def sendMessage(message):
    commSocket.send(message.encode("utf-8"))


while commSocket == None:
    commSocket, address = server.accept()

    print(f"Connected to {address}")
    sendMessage("connection successfull")




    printCurrentTeam()
    commSocket.close()

