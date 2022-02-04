from __future__ import absolute_import
from __future__ import division
from __future__ import print_function
import socket
import time
import numpy as np
import abc
import tensorflow as tf
import numpy as np

from tf_agents.environments import py_environment
from tf_agents.environments import tf_environment
from tf_agents.environments import tf_py_environment
from tf_agents.environments import utils
from tf_agents.specs import array_spec
from tf_agents.environments import wrappers
from tf_agents.environments import suite_gym
from tf_agents.trajectories import time_step as ts

host = "127.0.0.1"
port = 1025

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

server.bind((host, port))

server.listen(1)
commSocket = None

echo = False

inputArray = np.zeros((3,5,5))

print(inputArray.shape)

while commSocket == None:
    commSocket, address = server.accept()
    print(f"Connected to {address}")


def sendMessage(message):
    commSocket.send(message.encode("utf-8"))

valid1commands = {1,2,3,4,5,6,7,8}
valid2commands = {1,2,3,4,5}
valid3commands = {1,2}

inputSize = 3*5*5

def receive355array(Message):
    MessageArrayX = Message.split("|")
    for x in range(3):
        MessageArrayY = MessageArrayX[x].split(".")
        for y in range(5):
            MessageArrayZ = MessageArrayY[y].split(" ")
            for z in range(5):
                inputArray[x,y,z] = int(MessageArrayZ[z])


class AutoPetsEnv(py_environment.PyEnvironment):

  def __init__(self):
    self._action_spec = array_spec.BoundedArraySpec(
        shape=(), dtype=np.int32, minimum=0, maximum=36, name='action')
    self._observation_spec = array_spec.BoundedArraySpec(
        shape=(3,5,5), dtype=np.int32, minimum=0, name='observation')
    self._state = np.zeros((3,5,5))
    self._episode_ended = False

    def action_spec(self):
        return self._action_spec
    
    def observation_spec(self):
        return self._observation_spec
    
    def _reset(self):
        self._state = np.zeros((3,5,5))
        self._episode_ended = False
        sendMessage("restart")
        receive355array(Message)
        slef.state = inputArray
        return ts.restart(self._state)

    def determine_reward(self):
        reward = self._state[2,2,0]
        avgTeam = 0.0
        for y in range(5):
            for z in range(1,3):
                avgTeam += self._state[0,y,z]
        avgTeam = avgTeam/10.0

    def _step(self, action):
        if self._episode_ended:
          # The last action ended the episode. Ignore the current action and start
          # a new episode.
          return self.reset()

        # Make sure episodes don't go on forever.
        if action == 35:
            sendMessage("6 4")
            receive355array(Message)
            slef.state = inputArray
        elif action == 34:
            sendMessage("6 3")
            receive355array(Message)
            slef.state = inputArray
        elif action == 33:
            sendMessage("6 2")
            receive355array(Message)
            slef.state = inputArray
        elif action == 32:
            sendMessage("6 1")
            receive355array(Message)
            slef.state = inputArray
        elif action == 31:
            sendMessage("6 0")
            receive355array(Message)
            slef.state = inputArray

        elif action == 30:
            sendMessage("5 4")
            receive355array(Message)
            slef.state = inputArray
        elif action == 29:
            sendMessage("5 3")
            receive355array(Message)
            slef.state = inputArray
        elif action == 28:
            sendMessage("5 2")
            receive355array(Message)
            slef.state = inputArray
        elif action == 27:
            sendMessage("5 1")
            receive355array(Message)
            slef.state = inputArray
        elif action == 26:
            sendMessage("5 0")
            receive355array(Message)
            slef.state = inputArray

        elif action == 25:
            sendMessage("4 4")
            receive355array(Message)
            slef.state = inputArray
        elif action == 24:
            sendMessage("4 3")
            receive355array(Message)
            slef.state = inputArray
        elif action == 23:
            sendMessage("4 2")
            receive355array(Message)
            slef.state = inputArray
        elif action == 22:
            sendMessage("4 1")
            receive355array(Message)
            slef.state = inputArray
        elif action == 21:
            sendMessage("4 0")
            receive355array(Message)
            slef.state = inputArray

        elif action == 20:
            sendMessage("3 4")
            receive355array(Message)
            slef.state = inputArray
        elif action == 19:
            sendMessage("3 3")
            receive355array(Message)
            slef.state = inputArray
        elif action == 18:
            sendMessage("3 2")
            receive355array(Message)
            slef.state = inputArray
        elif action == 17:
            sendMessage("3 1")
            receive355array(Message)
            slef.state = inputArray
        elif action == 16:
            sendMessage("3 0")
            receive355array(Message)
            slef.state = inputArray

        elif action == 15:
            sendMessage("2 4")
            receive355array(Message)
            slef.state = inputArray
        elif action == 14:
            sendMessage("2 3")
            receive355array(Message)
            slef.state = inputArray
        elif action == 13:
            sendMessage("2 2")
            receive355array(Message)
            slef.state = inputArray
        elif action == 12:
            sendMessage("2 1")
            receive355array(Message)
            slef.state = inputArray
        elif action == 11:
            sendMessage("2 0")
            receive355array(Message)
            slef.state = inputArray

        elif action == 10:
            sendMessage("1 4")
            receive355array(Message)
            slef.state = inputArray
        elif action == 9:
            sendMessage("1 3")
            receive355array(Message)
            slef.state = inputArray
        elif action == 8:
            sendMessage("1 2")
            receive355array(Message)
            slef.state = inputArray
        elif action == 7:
            sendMessage("1 1")
            receive355array(Message)
            slef.state = inputArray
        elif action == 6:
            sendMessage("1 0")
            receive355array(Message)
            slef.state = inputArray

        elif action == 5:
            sendMessage("0 4")
            receive355array(Message)
            slef.state = inputArray
        elif action == 4:
            sendMessage("0 3")
            receive355array(Message)
            slef.state = inputArray
        elif action == 3:
            sendMessage("0 2")
            receive355array(Message)
            slef.state = inputArray
        elif action == 2:
            sendMessage("0 1")
            receive355array(Message)
            slef.state = inputArray
        elif action == 1:
            sendMessage("0 0")
            receive355array(Message)
            slef.state = inputArray


        elif action == 0:
            sendMessage("PAS")
            receive355array(Message)
            slef.state = inputArray
                
        else:
          raise ValueError('something went wrong was given action outside of range')

        if self._state[2,2,0] <= 0:
          reward = self.determin_reward()
          return ts.termination(self._state, reward)
        else:
          return ts.transition(self._state, reward=0.0, discount=1.0)




while True:
    message = commSocket.recv(1024).decode()


