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
#pytesseract.pytesseract.tesseract_cmd = r"C:\Users\blake\AppData\Local\Programs\Tesseract-OCR\tesseract.exe"
Server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

Server.connect((host, port))

turn = 1;

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
	"camelcenter.PNG",
	"camelfrozen.PNG",
	"crabcenter.PNG",
	"crabfrozen.PNG",
	"cricketcenter.PNG",
	"cricketfrozen.PNG",
	"deercenter.PNG",
	"deerfrozen.PNG",
	"dodocenter.PNG",
	"dodofrozen.PNG",
	"dogcenter.PNG",
	"dogfrozen.PNG",
	"dolphincenter.PNG",
	"dolphinfrozen.PNG",
	"duckcenter.PNG",
	"duckfrozen.PNG",
	"elephantcenter.PNG",
	"elephantfrozen.PNG",
	"fishcenter.PNG",
	"fishfrozen.PNG",
	"flamingocenter.PNG",
	"flamingofrozen.PNG",
	"giraffecenter.PNG",
	"giraffefrozen.PNG",
	"hedgehogcenter.PNG",
	"hedgehogfrozen.PNG",
	"hippocenter.PNG",
	"hippofrozen.PNG",
	"horsecenter.PNG",
	"horsefrozen.PNG",
	"kangaroocenter.PNG",
	"kangaroofrozen.PNG",
	"mosquitocenter.PNG",
	"mosquitofrozen.PNG",
	"ottercenter.PNG",
	"otterfrozen.PNG",
	"oxcenter.PNG",
	"oxfrozen.PNG",
	"peacockcenter.PNG",
	"peacockfrozen.PNG",
	"penguincenter.PNG",
	"penguinfrozen.PNG",
	"pigcenter.PNG",
	"pigfrozen.PNG",
	"ratcenter.PNG",
	"ratfrozen.PNG",
	"roostercenter.PNG",
	"roosterfrozen.PNG",
	"sheepcenter.PNG",
	"sheepfrozen.PNG",
	"shrimpcenter.PNG",
	"shrimpfrozen.PNG",
	"skunkcenter.PNG",
	"skunkfrozen.PNG",
	"snailcenter.PNG",
	"snailfrozen.PNG",
	"spidercenter.PNG",
	"spiderfrozen.PNG",
	"swancenter.PNG",
	"swanfrozen.PNG",
	"turtlecenter.PNG",
	"turtlefrozen.PNG",
	"antcenter.PNG",
	"antfrozen.PNG",
	"badgercenter.PNG",
	"badgerfrozen.PNG",
	"beavercenter.PNG",
	"beaverfrozen.PNG",
	"bisoncenter.PNG",
	"bisonfrozen.PNG",
	"blowfishcenter.PNG",
	"blowfishfrozen.PNG",
	"bunnycenter.PNG",
	"bunnyfrozen.PNG",
	"monkeycenter.PNG",
	"monkeyfrozen.PNG",
	"mammothcenter.PNG",
	"mammothfrozen.png"

	}

foodListPngs = {
	"meat.PNG",
	"meatfrozen.PNG",
	"pear.PNG",
	"pearfrozen.PNG",
	"pill.PNG",
	"pillfrozen.PNG",
	"salad.PNG",
	"saladfrozen.PNG",
	"apple.PNG",
	"applefrozen.PNG",
	"can.PNG",
	"canfrozen.PNG",
	"cupcake.PNG",
	"cupcakefrozen.PNG",
	"garlic.PNG",
	"garlicfrozen.PNG",
	"honey.PNG",
	"honeyfrozen.PNG"
}

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



def findattackandhealthofposisition(position):
	if position == 0:
		attack = pyautogui.screenshot("attack.png", region =(486, 490, 50, 50))
		health = pyautogui.screenshot("health.png", region =(550, 490, 40, 50))
	elif position == 1:
		attack = pyautogui.screenshot("attack.png", region =(621, 490, 50, 50))
		health = pyautogui.screenshot("health.png", region =(693, 490, 40, 50))
	elif position == 2:
		attack = pyautogui.screenshot("attack.png", region =(621, 490, 50, 50))
		health = pyautogui.screenshot("health.png", region =(693, 490, 40, 50))
	elif position == 3:
		attack = pyautogui.screenshot("attack.png", region =(621, 490, 50, 50))
		health = pyautogui.screenshot("health.png", region =(693, 490, 40, 50))
	elif position == 4:
		attack = pyautogui.screenshot("attack.png", region =(621, 490, 50, 50))
		health = pyautogui.screenshot("health.png", region =(693, 490, 40, 50))	

	health, attack = HealthAndAttack()
	return attack, health


def HealthAndAttack():
	attackimg = cv2.imread("attack.png", cv2.IMREAD_GRAYSCALE)
	healthimg = cv2.imread("health.png", cv2.IMREAD_GRAYSCALE)
	
	healthimg = cv2.copyMakeBorder(healthimg, 50, 50, 50, 50, cv2.BORDER_CONSTANT, value=[0, 0, 0])

	attackimg = cv2.threshold(attackimg, 100, 255, cv2.THRESH_BINARY_INV+cv2.THRESH_OTSU)[1]
	attackimg = cv2.resize(attackimg, (0,0), fx=1.45, fy=1.45) 

	healthimg = cv2.threshold(healthimg, 100, 255, cv2.THRESH_BINARY_INV+cv2.THRESH_OTSU)[1]
	healthimg = cv2.resize(healthimg, (0,0), fx=1.45, fy=1.45)

	attack = pytesseract.image_to_string(attackimg, lang='eng', \
           config='--psm 10 --oem 3 -c tessedit_char_whitelist=0123456789')
	health = pytesseract.image_to_string(healthimg, lang='eng', \
           config='--psm 10 --oem 3 -c tessedit_char_whitelist=0123456789')

	cv2.imwrite("greyhp.png", healthimg)
	cv2.imwrite("greyattack.png", attackimg)

	if attack == "":
		attack = 0
	if health == "":
		health = 0
	return health, attack

def click2spots(spot1, spot2):
	pyautogui.click(spot1)
	pyautogui.click(spot2)

def click(spot):
	pyautogui.click(spot)

def clickdic(Keypressed):
	try:
		pyautogui.click(uidict[Keypressed])
		return True;
	except:
		return False;

def buyslot(shoppos, slotalpha):
	click2spots(uidict[shoppos], uidict[slotalpha])

def reset():
	turn = 1

# buy message comes in as BUY shopops, slotAlpha it should only be shoppos slotalpha by the time it reaches here
def buy(message):
	buyslot(message[0], message[1])
	return "PAS"


def endTurn():
	click(uidict['e'])
	time.sleep(1)
	click((1200,700))
	if(turn == 1):
		click(uidict['1'])
		click(uidict['a'])
		click(uidict['e'])
	TurnDone = False
	while TurnDone != True:
		try:
			loc = pyautogui.locateOnScreen("endturnscreen.PNG", confidence=0.97)
			if loc != None:
				pyautogui.click(loc)
				time.sleep(2)
				pyautogui.click((1600,200))
				TurnDone = True
		except:
			pass
	return "PAS"

def reroll():
	click(uidict['r'])
	return createSAU()


def sendMessage(message):
    Server.send(message.encode("utf-8"))

#SAU should be in format "SAU pet1 f/UF pet2 F/UF pet3 f/UF...
def createSAU():
	petShopStrings = shopPetsFind()
	returnString = "SAU "
	for petStrings in petShopStrings:
		returnString = "".join((returnString, " " , petStrings))
	print(returnString)
	return returnString

#SFU should be in format "SFU food1, food2"
def createSFU():
	foodShopStrings = shopFoodFind()
	returnString = "SFU "
	for foodstrings in foodShopStrings:
		returnString = "".join((returnString, " " , foodstrings))
	print(returnString)
	return returnString
	

def createAHU():
	returnString = "AHU "
	attack0, health0 = findattackandhealthofposisition(0)
	attack1, health1 = findattackandhealthofposisition(1)
	attack2, health2 = findattackandhealthofposisition(2)
	attack3, health3 = findattackandhealthofposisition(3)
	attack4, health4 = findattackandhealthofposisition(4)
	returnString = "".join((returnString, str(attack0), " ", str(health0), " ", str(attack1), " ", str(health1), " ", str(attack2), " ", str(health2), " ", str(attack3), " ", str(health3), " ", str(attack4), " ", str(health4)))

	return returnString

def receivemessage(message):
	if message[0:3] == "AHU": #attack health update
		sendMessage(createAHU())
	if message[0:3] == "SAU": #Shop Animals Update
		sendMessage(createSAU())
	if message[0:3] == "SFU": #Shop Animals Update
		sendMessage(createSFU())
	if message[0:3] == "RER": #Reroll
		sendMessage(reroll())
	if message[0:3] == "BUY":
		messageinfo = message.split()
		sendMessage(buy(messageinfo[:][1:3]))
	if message[0:3] == "END":
		sendMessage(endTurn())



while True:
	receivemessage(Server.recv(1024).decode("utf-8"))