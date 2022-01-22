import pyautogui
import keyboard
import time
import socket



HOST = '127.0.0.1'
PORT = 65432       

Server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

server_address = ('localhost', 10000)
Server.connect(server_address)


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


while True:
	try:
		message = 'This is the message.  It will be repeated.'
		Server.sendall(message)

		# Look for the response
		amount_received = 0
		amount_expected = len(message)

		while amount_received < amount_expected:
			data = sock.recv(16)
			amount_received += len(data)
	finally:
		sock.close()
