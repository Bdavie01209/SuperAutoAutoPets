import pyautogui
import keyboard
import time
import socket
import cv2
import numpy as np
import matplotlib.pyplot as plt
import pytesseract



time.sleep(1)

host = "127.0.0.1"
port = 9012     
pytesseract.pytesseract.tesseract_cmd = r"C:\Users\blake\AppData\Local\Programs\Tesseract-OCR\tesseract.exe"
Server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

Server.connect((host, port))

print(Server.recv(1024).decode("utf-8"))

def findattackandhealthofposisition(position):
	if position == 0:
		attack = pyautogui.screenshot("attack.png", region =(486, 490, 40, 40))
		health = pyautogui.screenshot("health.png", region =(550, 490, 40, 40))
	elif position == 1:
		attack = pyautogui.screenshot("attack.png", region =(621, 490, 40, 40))
		health = pyautogui.screenshot("health.png", region =(693, 490, 40, 40))	




	health, attack = HealthAndAttack()
	return attack, health


def HealthAndAttack():
		attackimg = cv2.imread("attack.png", cv2.IMREAD_GRAYSCALE)
		healthimg = cv2.imread("health.png", cv2.IMREAD_GRAYSCALE)
		attack = pytesseract.image_to_string(attackimg, lang='eng', \
           config='--psm 10 --oem 3 -c tessedit_char_whitelist=0123456789')
		health = pytesseract.image_to_string(healthimg, lang='eng', \
           config='--psm 10 --oem 3 -c tessedit_char_whitelist=0123456789')

		return health, attack



findattackandhealthofposisition(0)






uidict = {
	'1':(520, 700), #shop1
	'2':(700,700), #shop2
	'3':(820, 700), #shop3
	'4':(950, 700), #shop4
	'5':(1100, 700), #shop5


	'r':(1250, 700), #shopf2
	't':(1400, 700), #shopf1


	'a':(530, 450), #team1
	's':(650, 450), #team2
	'd':(800, 450), #team3
	'f':(950,450), #team4
	'g':(1100, 450), #team5

	'q': (230, 1000), # roll 
	'w': (1000,1000), # freeze
	'e': (1600, 1000) # end turn
		  }

def click2spots(spot1, spot2):
	pyautogui.click(spot1)
	pyautogui.click(spot2)



def clickdic(Keypressed):
	try:
		pyautogui.click(uidict[Keypressed])
		return True;
	except:
		return False;


def buyslot1():
	click2spots(uidict['1'], uidict['a'])


def sendMessage(message):
    Server.send(message.encode("utf-8"))


def createCSU():
	returnString = "AHU "

	return returnString

def receivemessage(message):
    print(message[0:3])
    if(message[0:3] == "AHU"):
		sendMessage(createCSU().encode("utf-8"))


while True: