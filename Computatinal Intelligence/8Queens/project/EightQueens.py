'''
Created on 21 Mar 2017

@author: TOLGAHAN
'''

import copy
from optparse import OptionParser
from board import board
        
class queens:
    def __init__(self, numruns, verbocity, passedboard=None):
        self.restart=0
        self.totalruns = numruns
        self.totalsucc = 0
        self.totalnumsteps = 0
        self.verbocity = verbocity
        i = 1
        while i != numruns+1:
            self.mboard = board(passedboard)
            self.cost = self.calc_cost(self.mboard)
            self.hill_solution()
            if(self.cost==0):
                if self.verbocity == True:
                    print "===================="
                    print "BOARD",i
                    print "===================="
                    print self.mboard
                i+=1
            else:
                self.restart+=1
                if self.verbocity == True:
                    print "===================="
                    print "BOARD"," Burada tikandi",str(self.restart)," kez restart atti"
                    print "===================="

    def hill_solution(self):
        while True:
            currViolations = self.cost
            self.getlowercostboard()
            if currViolations == self.cost:
                return
            self.totalnumsteps += 1
            if self.verbocity == True:
                print "Board Violations", self.calc_cost(self.mboard)
                print self.mboard
        if currViolations==0:
            self.totalsucc += 1
            print "##########################"
        return self.cost
    
    def calc_cost(self, tboard):
        cost = 0
        for i in range(0,8):
            for j in range(i+1,8):
                if tboard.board[i] == tboard.board[j]:
                    cost += 1
                offset = j - i
                if tboard.board[i] == tboard.board[j] - offset or tboard.board[i] == tboard.board[j] + offset:
                    cost +=1
        return cost
    
    def getlowercostboard(self):
        lowcost = self.calc_cost(self.mboard)
        lowestavailable = self.mboard
        #move one queen at a time, the optimal single move by brute force
        for q_col in range(0,8):
            #get the lowest cost by moving this queen
            for m_row in range(0,8):
                if self.mboard.board[q_col] != m_row:
                    #try placing the queen here and see if it's any better
                    tryboard = copy.deepcopy(self.mboard)
                    tryboard.board[q_col] = m_row
                    thiscost = self.calc_cost(tryboard)
                    if thiscost < lowcost:
                        lowcost = thiscost
                        lowestavailable = tryboard
        self.mboard = lowestavailable
        self.cost = lowcost
        
    def printstats(self):
        print "Total Solution Count: ", self.totalruns
        print "Total Restart Count: ", self.restart
    
if __name__ == "__main__":
    parser = OptionParser()
    
    parser.add_option("-q", "--quiet", dest="verbose",
                   action="store_false", default=True,
                   help="Don't print all the moves... wise option if using large numbers")
      
    parser.add_option("-n", dest="numrun", help="Number of random Boards", default=1,
                   type="int")
    (options, args) = parser.parse_args()

    mboard = queens(verbocity=options.verbose, numruns=options.numrun)
    mboard.printstats()