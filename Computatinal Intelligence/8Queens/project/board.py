'''
Created on 21 Mar 2017

@author: TOLGAHAN
'''

import random

class board:
    def __init__(self, list=None):
        if list == None:
            self.board = [random.randint(0,7) for i in range(0,8)]
            
    #TODO raise errors if board is not right format or dimension
    #define how to print the board
    def __str__(self):
        b = [[0 for i in range(0,8)] for j in range(0,8)]
        for i in range(0,8):
            b[self.board[i]][i] = 'X'
        mstr = ""
        for i in range(0,8):
            for j in range(0,8):
                mstr = mstr + str(b[i][j]) + " "
            mstr+='\n'
        return (mstr)