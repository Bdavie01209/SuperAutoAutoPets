import pyautogui
import keyboard
import time
import socket
import cv2
import numpy as np
#import matplotlib.pyplot as plt
#import pytesseract

print("client")

time.sleep(3) # this could be removed instead just opening the server first

host = "127.0.0.1"
port = 9012     
#pytesseract.pytesseract.tesseract_cmd = "path to tesseract"

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

server.bind((host, port))

open = True

server.listen(1)
commSocket = None


while commSocket == None:
    print("waiting to connect...")
    commSocket, address = server.accept()
    print(f"Connected to {address}")




uiDictShop = {
	'0':(520, 700), #shop1
	'1':(700,700), #shop2
	'2':(820, 700), #shop3
	'3':(950, 700), #shop4
	'4':(1100, 700), #shop5

	'5' :(1250, 700), #shopf2
	'6' : (1400, 700), #shopf1
	}

uiDictAnimals = {
	'0':(530, 450), #team1
	'1':(650, 450), #team2
	'2':(800, 450), #team3
	'3':(950,450), #team4
	'4':(1100, 450), #team5
	}

uidict = {
	'1':(520, 700), #shop1
	'2':(700,700), #shop2
	'3':(820, 700), #shop3
	'4':(950, 700), #shop4
	'5':(1100, 700), #shop5


	'6':(1250, 700), #shopf2
	'7':(1400, 700), #shopf1


	'a':(530, 450), #team1
	's':(650, 450), #team2
	'd':(800, 450), #team3
	'f':(950,450), #team4
	'g':(1100, 450), #team5

	'r': (230, 1000), # roll 
	'w': (1000,1000), # freeze
	'e': (1600, 1000) # end turn
		  }

petlistpngs = {
	"kangaroocenter.PNG",
	"mammothcenter.PNG",
	"monkeycenter.PNG",
	"mosquitocenter.PNG",
	"ottercenter.PNG",
	"oxcenter.PNG",
	"peacockcenter.PNG",
	"penguincenter.PNG",
	"pigcenter.PNG",
	"ratcenter.PNG",
	"roostercenter.PNG",
	"sheepcenter.PNG",
	"shrimpcenter.PNG",
	"skunkcenter.PNG",
	"snailcenter.PNG",
	"spidercenter.PNG",
	"swancenter.PNG",
	"turtlecenter.PNG",
	"antcenter.PNG",
	"badgercenter.PNG",
	"beavercenter.PNG",
	"bisoncenter.PNG",
	"blowfishcenter.PNG",
	"bunnycenter.PNG",
	"camelcenter.PNG",
	"crabcenter.PNG",
	"cricketcenter.PNG",
	"deercenter.PNG",
	"dodocenter.PNG",
	"dogcenter.PNG",
	"dolphincenter.PNG",
	"duckcenter.PNG",
	"elephantcenter.PNG",
	"fishcenter.PNG",
	"flamingocenter.PNG",
	"giraffecenter.PNG",
	"hedgehogcenter.PNG",
	"hippocenter.PNG",
	"horsecenter.PNG",
	}

foodListPngs = {
	"meat.PNG",
	#"pear.PNG",
	"salad.PNG",
	"apple.PNG",
	"can.PNG",
	"cupcake.PNG",
	"garlic.PNG",
	"honey.PNG"
}

#these locations were found on a 1080 x 1920 screen with an assistant program that tracks locations
shopBoxesPets = [((475,630),(600, 775)),((605, 630 ),(730, 775)),((750,630),(875, 775)),((900,630),(1025, 775)),((1030,630),(1155, 775))]
shopBoxesFoods = [((1175,630),(1300, 775)),((1315, 630 ),(1430, 775))]


#should search the shop space and return the current pets in the shop
def shopPetsFind():
	returnlist = ["None"] * 5

	for pets in petlistpngs:
		a = pyautogui.locateAllOnScreen(pets, region=(475, 630, 680, 145), confidence=0.9) 

		if a != None:
			petname = pets
			if "center.PNG" in petname:
				petname = petname[:-10]
			for matches in a:
				locationfound = pyautogui.center(matches)
				currpostion = 0
				for rectangles in shopBoxesPets:
					if pointinrectangle(rectangles[0],rectangles[1], locationfound):
						returnlist[currpostion] = petname;
					currpostion += 1
	return returnlist

def pointinrectangle(tl,br,p):
	if(p[0] > tl[0] and p[0] < br[0] and p[1] < br[1] and p[1] > tl[1]):
		return True
	else:
		return False


def shopFoodFind():
	returnlist = ["None"] * 2

	for foods in foodListPngs:
		a = pyautogui.locateAllOnScreen(foods, region=(1175, 630, 350, 145), confidence=0.99) 

		if a != None:
			foodname = foods[:-4]
			for matches in a:
				locationfound = pyautogui.center(matches)
				currpostion = 0
				for rectangles in shopBoxesFoods:
					if pointinrectangle(rectangles[0],rectangles[1], locationfound):
						returnlist[currpostion] =  foodname
					currpostion += 1
	return returnlist


def click2spots(spot1, spot2):
	Click(spot1)
	Click(spot2)

def Click(spot):
	pyautogui.click(spot)
	time.sleep(.5)

def buyslot(shoppos, slotalpha):
	click2spots(uiDictShop[shoppos], uiDictAnimals[slotalpha])



def checkWin():
	print("waiting for Win/Lose/Draw")
	return keyboard.read_key()




# buy message comes in as shopops, slotAlpha it should only be shoppos slotalpha by the time it reaches here
def buy(message):
	buyslot(message[0], message[1])
	return "PAS"

def sellthenbuy(message):
	click2spots(uiDictAnimals[message[1]], uidict['w'])
	return buy(message)

def endTurn():
	Click(uidict['e'])
	time.sleep(1)
	Click((1200,700))
	TurnDone = False
	while TurnDone != True:
		try:
			loc = pyautogui.locateOnScreen("endturnscreen.PNG", confidence=0.97)
			if loc != None:
				Click(loc)
				time.sleep(2)
				Click((1600,200))
				TurnDone = True
		except:
			pass
	return checkWin()

def reroll():
	Click(uidict['r'])
	x = createSAU() + " " + createSFU()
	print(x)
	return x


def sendMessage(message):
    commSocket.send(message.encode("utf-8"))

#SAU should be in format "pet1 pet2 pet3 ...
def createSAU():
	petShopStrings = shopPetsFind()
	returnString = ""
	first = True
	for petStrings in petShopStrings:
		if first:
			returnString = petStrings
			first = False
		else:
			returnString = returnString + " " + petStrings
	print(returnString)
	return returnString

#SFU should be in format "food1 food2"
def createSFU():
	foodShopStrings = shopFoodFind()
	returnString = ""
	for foodstrings in foodShopStrings:
		returnString = "".join((returnString, " " , foodstrings))
	print(returnString)
	return returnString
	

def receivemessage(message):
	print(message)
	if message[0:3] == "RER": #Reroll
		sendMessage(reroll())
	elif message[0:3] == "FSU":
		x = createSAU() + " " + createSFU()
		print(x)
		sendMessage(x)
	elif message[0:3] == "END":
		sendMessage(endTurn())
	elif message[0:3] == "BUY":
		messageinfo = message.split()
		sendMessage(buy(messageinfo[:][1:3]))
	elif message[0:3] == "OVR":
		messageinfo = message.split()
		sendMessage(sellthenbuy(messageinfo[:][1:3]))
	elif message[0:3] == "CLO":
		open = False
		commSocket.Close()
		



while open:
	receivemessage(commSocket.recv(1024).decode("utf-8"))