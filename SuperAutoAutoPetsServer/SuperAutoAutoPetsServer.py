import socket
import sys

print("server")


host = "127.0.0.1"
port = 9012

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

server.bind((host, port))

server.listen(1)

TeamPets = [["none", 0,0, "none", 0],["none", 0,0,"none",0],["none", 0,0,"none",0],["none", 0,0,"none",0],["none", 0,0,"none", 0]]

turn = 0

currPetshop = [["none"],["none"],["none"],["none"],["none"]]
currFoodShop = [["none"],["none"]]


uiDictTrans = {
    0 : "a",
    1 : "s",
    2 : "d",
    3 : "f",
    4 : "g"
}

commSocket = None
# messages received should be in format 
# Code content
# CSU = current state update 
# CSU TeamSlot1Name attack Defence, teamslot2name attack Defence,teamslot3name attack Defence, teamslot4name attack Defence, teamslot5name attack Defence
# AHU = Attack Heath Update 
# AHU attack1 heath1, attack 2 health 2, attack 3 health 3, attack 4 health 4, attack 5 health 5
# SAU = pet1 pet2 pet3 pet4 pet5
# SFU = foodshop1 foodshop2 
def receivemessage(message):
    if(message[0:3] == "CSU"):
        messageinfo = message.split()
        updateCurrentPets(messageinfo[:][1:16])
    if(message[0:3] == "AHU"):
        messageinfo = message.split()
        updateAttackHeath(messageinfo[:][1:11])
    if(message[0:3] == "SAU"):
        print(message)
        messageinfo = message.split()
        updateShopPets(messageinfo[:][1:6])
    if(message[0:3] == "SFU"):
        print(message)
        messageinfo = message.split()
        updateFoodShop(messageinfo[:][1:3])
    if(message[0:3] == "PAS"):
        print(message)
        pass


def updateFoodShop(SFU):
    currFoodShop[0] = SFU[0]
    currFoodShop[1] = SFU[1] 

def updateShopPets(SAU):
    currPetshop[0] = SAU[0]
    currPetshop[1] = SAU[1]
    currPetshop[2] = SAU[2]
    currPetshop[3] = SAU[3]
    currPetshop[4] = SAU[4]

def updateAttackHeath(ahuString1through10):
    ahu = ahuString1through10
    TeamPets[0] = [TeamPets[0][0], ahu[0], ahu[1]]
    TeamPets[1] = [TeamPets[1][0], ahu[2], ahu[3]]
    TeamPets[2] = [TeamPets[2][0], ahu[4], ahu[5]]
    TeamPets[3] = [TeamPets[3][0], ahu[6], ahu[7]]
    TeamPets[4] = [TeamPets[4][0], ahu[8], ahu[9]]


def updateCurrentPets(CSUString1through15):
    csu = CSUString1through15
    TeamPets[0] = [csu[0], int(csu[1]), int(csu[2])];
    TeamPets[1] = [csu[3], int(csu[4]), int(csu[5])];
    TeamPets[2] = [csu[6], int(csu[7]), int(csu[8])];
    TeamPets[3] = [csu[9], int(csu[10]), int(csu[11])];
    TeamPets[4] = [csu[12], int(csu[13]), int(csu[14])];


#debugging function
def printCurrentTeam():
    for pets in TeamPets:
        print(f"{pets[0]} : {pets[1]} Attack / {pets[2]} Health")

#sends end turn and waits for game to update
def endTurn():
    sendMessage("END")
    receivemessage(commSocket.recv(1024).decode("utf-8"))

#possible messages BUY, AHU, SAU, CSU {current state upate}, END, RER
def sendMessage(message):
    commSocket.send(message.encode("utf-8"))


while commSocket == None:
    commSocket, address = server.accept()
    print(f"Connected to {address}")


while True:
    #print(f"ending turn {turn}")
    #endTurn()
    #turn += 1
    #sendMessage("SAU") #update the pets
    #receivemessage(commSocket.recv(1024).decode("utf-8"))

    
    #sendMessage("SFU") #upate the food shop
    #receivemessage(commSocket.recv(1024).decode("utf-8"))
    #print(currPetshop)
    #print(currFoodShop)
    break;

commSocket.close()