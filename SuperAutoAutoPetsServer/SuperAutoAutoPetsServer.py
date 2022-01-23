
import socket
import sys

host = "127.0.0.1"
port = 9012

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

server.bind((host, port))

server.listen(1)

print("the server has been opened")

TeamPets = [["none", 0,0],["none", 0,0],["none", 0,0],["none", 0,0],["none", 0,0]]

#this heuristic while not perfect will mean the ai will generally try and put its strongest units towards the front
slotweights = [.8],[.95],[.95],[1.0],[1.25]

turn = 0

currGold = 10;

currCans = 0

currPetshop = [["none", False],["none", False],["none", False],["none",False],["none", False]]


currFoodShop = [["none"],["none"]]



petListT1 = {
    "ant" : (2,1),
    "beaver" : (2,2),
    "cricket" : (1,2),
    "duck" : (1,2),
    "fish" : (2,3),
    "horse" : (2,1),
    "mosquito" : (2,2),
    "otter" : (1,2),
    "pig" : (3,1)
    }
def findT1Value():
    for pets in petListT1:


petListT2 = {
    "crab" : (3,3),
    "dodo" : (2,3),
    "elephant" : (3,5),
    "flamingo" : (3,1),
    "hedgehog" : (3,2),
    "peacock" : (1,5),
    "rat" : (4,5),
    "shrimp" : (2,3),
    "spider" : (2,2),
    "swan" : (3,3)
    }

petListT3 = {
    "badger" : (5,4),
    "blowfish" : (3,5),
    "camel" : (2,5),
    "dog" : (2,2),
    "giraffe" : (2,5),
    "kangaroo" : (1,2),
    "ox" : (1,4),
    "bunny" : (3,2),
    "sheep" : (2,2),
    "snail" : (2,2),
    "turtle" : (1,2)
    }
petListT4 = {
    "bison" : (6,6),
    "deer" : (1,1),
    "dolphin" : (4,6),
    "hippo" : (4,7),
    "parrot" : (5,3),
    "penguin" : (1,2),
    "rooster" : (5,3),
    "skunk" : (3,6),
    "squirrel" : (2,5),
    "whale" : (2,6),
    "worm" : (2,2)
    }
petListT5 = {
    "cow" : (4,6),
    "crocodile" : (8,4),
    "monkey" : (1,2),
    "rhino" : (5,8),
    "scorpion" : (1,1),
    "seal" : (3,8),
    "shark" : (4,4),
    "turkey" : (3,4)
    }
petListT6 = {
    "boar" : (8,6),
    "cat" : (4,5),
    "dragon" : (6,8),
    "fly" : (5,5),
    "gorilla" : (6,9),
    "leopard" : (10,4),
    "mammoth" : (3,10),
    "snake" : (6,6),
    "tiger" : (4,3)
    }




commSocket = None
# messages received should be in format 
# Code content
# CSU = current state update 
# CSU TeamSlot1Name attack Defence, teamslot2name attack Defence,teamslot3name attack Defence, teamslot4name attack Defence, teamslot5name attack Defence
# AHU = Attack Heath Update 
# AHU attack1 heath1, attack 2 health 2, attack 3 health 3, attack 4 health 4, attack 5 health 5
# SAU = pet1 frozen/unfrozen pet2 frozen/unfrozen pet3 frozen/unfrozen pet4 frozen/unfrozen pet5 frozen/unfrozen
# SFU = foodshop1 frozen/unfrozen foodshop2 frozen/unfrozen 
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
        updateShopPets(messageinfo[:][1:11])
    if(message[0:3] == "SFU"):
        print(message)
        messageinfo = message.split()
        updateFoodShop(messageinfo[:][1:11])
    if(message[0:3] == "PAS"):
        pass


def updateFoodShop(SFU):
    currFoodShop[0] = [SFU[0], SFU[1]] 
    currFoodShop[1] = [SFU[2], SFU[3]] 

def updateShopPets(SAU):
    currPetshop[0] = [SAU[0], SAU[1]]
    currPetshop[1] = [SAU[2], SAU[3]]
    currPetshop[2] = [SAU[4], SAU[5]]
    currPetshop[3] = [SAU[6], SAU[7]]
    currPetshop[4] = [SAU[8], SAU[9]]

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



def printCurrentTeam():
    for pets in TeamPets:
        print(f"{pets[0]} : {pets[1]} Attack / {pets[2]} Health")

#possible messages BUY, AHU, SAU, CSU, END FRE, RER
def sendMessage(message):
    commSocket.send(message.encode("utf-8"))


while commSocket == None:
    commSocket, address = server.accept()

    print(f"Connected to {address}")
    sendMessage("connection successfull this is the client")

    print(commSocket.recv(1024).decode("utf-8"))

    sendMessage("SAU")



    receivemessage(commSocket.recv(1024).decode("utf-8"))

    sendMessage("SFU")

    receivemessage(commSocket.recv(1024).decode("utf-8"))





commSocket.close()






# the actual ai is below


def decidemove():
    #update the pet shop
    sendMessage("SAU")
    receivemessage(commSocket.recv(1024).decode("utf-8"))

    #update the food shop
    sendMessage("SFU")
    receivemessage(commSocket.recv(1024).decode("utf-8"))