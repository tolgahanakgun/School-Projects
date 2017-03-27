'''
Created on 31 May 2016

@author: TOLGAHAN
'''
def coin(coins,x):
    if x == 0:
        return 0
    if x == 1:
        return coins[1]
    return max(coins[x] + coin(coins,x-2), coin(coins,x-1))
a = [0,5,1,2,10,6,2]
print coin(a,6)