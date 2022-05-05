from __future__ import absolute_import
from __future__ import division
from __future__ import print_function
import socket
import time
import numpy as np
import abc
import tensorflow as tf
import numpy as np
import random as rn
from tf_agents.agents.reinforce import reinforce_agent
from tf_agents.drivers import py_driver
from tf_agents.environments import py_environment
from tf_agents.environments import tf_environment
from tf_agents.environments import tf_py_environment
#from tf_agents.environments import utils
from tf_agents.specs import array_spec
from tf_agents.environments import wrappers
from tf_agents.environments import suite_gym
from tf_agents.trajectories import time_step as ts
from rl.agents import DQNAgent
from rl.policy import BoltzmannQPolicy
from rl.memory import SequentialMemory
from tensorflow import keras
from keras.layers import Dense, Activation
from keras.models import Sequential, load_model
from tensorflow.keras.optimizers import Adam 
from utils import plotLearning



host = "127.0.0.1"
port = 1025

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

server.bind((host, port))

server.listen(1)
commSocket = None

inputArray = np.zeros((3,5,5), dtype=np.int32)


while commSocket == None:
    print("waiting to connect...")
    commSocket, address = server.accept()
    print(f"Connected to {address}")


def sendMessage(message):
    commSocket.send(message.encode("utf-8"))


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
            shape=(), dtype=np.int32, minimum=0, maximum=35, name='action')
        self._observation_spec = array_spec.BoundedArraySpec(
            shape=inputArray.shape, dtype=np.int32, minimum=-2,maximum= 400, name='observation')
        self._state = inputArray
        self._episode_ended = False

    def action_spec(self):
        return self._action_spec
    
    def observation_spec(self):
        return self._observation_spec

    def rewardCalc(self):
        avgTeam = 0.0
        numEmpty = 0
        for y in range(5):
            if self._state[0,y,0] == 0:
                numEmpty += 1
            for z in range(1,3):
                avgTeam += self._state[0,y,z]
        avgTeam = avgTeam/10.0
        #current turn * 5 + average team attack/hp * 10 + wins * 20 - numEmpty * 5
        reward = (self._state[2,3,0] * 5) + (avgTeam * 10) + (self._state[2,2,1] * 20) - (numEmpty * 5)
        return reward
    
    def _reset(self):
        self._state = np.zeros((3,5,5))
        self._episode_ended = False
        sendMessage("RESTART")
        receive355array(commSocket.recv(1024).decode("utf-8"))
        self._state = inputArray
        return ts.restart(self._state)

    def _step(self, action):
        if self._episode_ended:
            # The last action ended the episode. Ignore the current action and start
            # a new episode.
            return self.reset()

        # Make sure episodes don't go on forever.
        if action == 35:
            sendMessage("6 4")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 34:
            sendMessage("6 3")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 33:
            sendMessage("6 2")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 32:
            sendMessage("6 1")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 31:
            sendMessage("6 0")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray

        elif action == 30:
            sendMessage("5 4")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 29:
            sendMessage("5 3")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 28:
            sendMessage("5 2")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 27:
            sendMessage("5 1")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 26:
            sendMessage("5 0")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray

        elif action == 25:
            sendMessage("4 4")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 24:
            sendMessage("4 3")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 23:
            sendMessage("4 2")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 22:
            sendMessage("4 1")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 21:
            sendMessage("4 0")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray

        elif action == 20:
            sendMessage("3 4")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 19:
            sendMessage("3 3")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 18:
            sendMessage("3 2")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 17:
            sendMessage("3 1")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 16:
            sendMessage("3 0")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray

        elif action == 15:
            sendMessage("2 4")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 14:
            sendMessage("2 3")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 13:
            sendMessage("2 2")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 12:
            sendMessage("2 1")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 11:
            sendMessage("2 0")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray

        elif action == 10:
            sendMessage("1 4")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 9:
            sendMessage("1 3")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 8:
            sendMessage("1 2")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 7:
            sendMessage("1 1")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 6:
            sendMessage("1 0")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray

        elif action == 5:
            sendMessage("0 4")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 4:
            sendMessage("0 3")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 3:
            sendMessage("0 2")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 2:
            sendMessage("0 1")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
        elif action == 1:
            sendMessage("0 0")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray


        elif action == 0:
            sendMessage("PAS")
            receive355array(commSocket.recv(1024).decode("utf-8"))
            self._state = inputArray
                
        else:
            raise ValueError('something went wrong was given action outside of range')

        #if lives <= 0 or wins >= 10
        if self._state[2,2,0] <= 0 or self._state[2,2,1] >= 10:
            self._episode_ended = True;
            return ts.termination(self._state, self.rewardCalc())
        else:
            if(self._state[2,2,2] == 1): #round end
                partial = self.rewardCalc()
            elif self._state[2,3,1] == 1: #this means the last action was a pass
                partial = -1 # there should be a mild punishment for passing
            else:
                partial = 0
            return ts.transition(self._state, reward=partial, discount=1.0)





#the model is a instantiation of https://github.com/philtabor/Youtube-Code-Repository/blob/master/ReinforcementLearning/DeepQLearning/ddqn_keras.py with my parameters hard coded in
class ReplayBuffer(object):
    def __init__(self, max_size, input_shape, n_actions):
        self.mem_size = max_size
        self.discrete = True
        self.state_memory = np.zeros((self.mem_size, input_shape))
        self.new_state_memory = np.zeros((self.mem_size, input_shape))
        self.action_memory = np.zeros((self.mem_size, n_actions), dtype=np.int32)
        self.reward_memory = np.zeros(self.mem_size, dtype=np.float32)
        self.terminal_memory = np.zeros(self.mem_size, dtype=np.float32)
        self.mem_cntr = 0

    def store_transition(self, state, action, reward, state_, done):
        index = self.mem_cntr % self.mem_size
        self.state_memory[index] = state
        self.new_state_memory[index] = state_
        self.reward_memory[index] = reward
        self.terminal_memory[index] = 1 - int(done)

        actions = np.zeros(self.action_memory.shape[1])
        actions[action] = 1.0
        self.action_memory[index] = actions

        self.mem_cntr += 1

    def sample_buffer(self, batch_size):
        max_mem = min(self.mem_cntr, self.mem_size)
        batch = np.random.choice(max_mem,batch_size)
        states = self.state_memory[batch]
        states_ = self.new_state_memory[batch]
        rewards = self.reward_memory[batch]
        actions = self.action_memory[batch]
        terminal = self.terminal_memory[batch]

        return states, states_, rewards, actions, terminal

def build_dqn(lr, n_actions, input_dims, fcl_dims, fc2_dims):
    model = Sequential([
            Dense(fcl_dims, input_shape=(input_dims,)),
            Activation('relu'),
            Dense(fc2_dims),
            Activation('relu'),
            Dense(n_actions)
        ])

    model.compile(optimizer=Adam(lr=lr), loss='mse')

    return model


class Agent(object):
    def __init__(self, alpha, gamma, n_actions, epsilon, batch_size, input_dims, epsilon_dec=0.996, epsilon_min=0.01, mem_size=10000,fname='dqn_model.h5'):
        self.action_space = [i for i in range(n_actions)]
        self.n_actions = n_actions
        self.gamma = gamma
        self.epsilon = epsilon
        self.epsilon_dec = epsilon_dec
        self.epsilon_min = epsilon_min
        self.batch_size = batch_size
        self.model_file = fname
        
        self.memory = ReplayBuffer(mem_size, input_dims, n_actions)

        self.q_eval = build_dqn(alpha,n_actions,input_dims,256,256)

    def remember(self, state, action, reward, new_state,done):
        self.memory.store_transition(state,action,reward, new_state, done)

    def choose_action(self, state):
        state = state[np.newaxis, :]
        rand = np.random.random()
        if rand < self.epsilon:
            action = np.random.choice(self.action_space)
        else:
            actions = self.q_eval.predict(state)
            action = np.argmax(actions)

        return action

    def learn(self):
        if self.memory.mem_cntr < self.batch_size:
            return
        state, new_state,reward, action , done = self.memory.sample_buffer(self.batch_size)

        action_values = np.array(self.action_space, dtype=np.int32)
        action_indices = np.dot(action, action_values)

        q_eval = self.q_eval.predict(state)

        q_next = self.q_eval.predict(new_state)

        q_target = q_eval.copy()

        batch_index = np.arange(self.batch_size, dtype=np.int32)    

        q_target[batch_index, action_indices] = reward + \
                                  self.gamma*np.max(q_next, axis=1)*done

        self.q_eval.fit(state,q_target,verbose=0)

        self.epsilon = self.epsilon*self.epsilon_dec if self.epsilon > self.epsilon_min else self.epsilon_min


    def save_model(self):
        self.q_eval.save(self.model_file)

    def load_model(self):
        self.q_eval = load_model(self.model_file)


def main():

    env = AutoPetsEnv()
    #utils.validate_py_environment(env, episodes=15)

    learnInput = input("(L)earn or (T)est: ")

    learn = True;

    n_games = 30000

    if learnInput.upper() == "T":
        learn = False;
        n_games = int(input("number games"))
    
    if learn:
        agent = Agent(gamma= .99,epsilon = 1.0, alpha=0.0005,input_dims=75, n_actions=36, mem_size=10000,batch_size=64)
    else:
        agent = Agent(gamma= .99,epsilon = 0,epsilon_min=0.00, alpha=0,input_dims=75, n_actions=36, mem_size=10000,batch_size=64)
    
    if learnInput.upper() != "LEARN OVERRIDE":
        agent.load_model()

    scores = []
    eps_history = []

    if learn:
        for i in range(n_games):
            done = False
            score = 0
            observation = (env.reset().observation).flatten()
            while not done:
                action = agent.choose_action(observation)
                timestep  = env.step(action)
                observation_ = timestep.observation.flatten()
                reward = timestep.reward
                done = timestep.is_last()
                score += reward
                agent.remember(observation,action,reward,observation_,done)
                observation = observation_
                agent.learn()

            eps_history.append(agent.epsilon)
            scores.append(score)

            avg_score = np.mean(scores[max(0,i-100): (i+1)])
            if i % 10 == 0 and i > 0:
                print("episode ", i, " score %.2f " % score, "Average_score %.2f" % avg_score)
                agent.save_model()





        filename = "autopetsmodel.png"
        x = [i+1 for i in range(n_games)]
        plotLearning(x,scores,eps_history, filename)

    else:
        while n_games > 0:
            done = False
            observation = (env.reset().observation).flatten()
            while not done:
                action = agent.choose_action(observation)
                timestep  = env.step(action)
                observation_ = timestep.observation.flatten()
                done = timestep.is_last()
                observation = observation_
            n_games -= 1
        


    while True:
        print("fell Through")
        input("")





if __name__ == "__main__":
    main()





