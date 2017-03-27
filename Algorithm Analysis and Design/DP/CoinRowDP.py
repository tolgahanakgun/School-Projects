'''
Created on 6 Haz 2016

@author: TOLGAHAN
'''
import time
lst = [0]*100
lst[0]=0
lst[1]=5
def coinDPWithR(coins, n):
    if n==0:
        return 0
    if n==1:
        return coins[0]
    if lst[n] != 0:
        return lst[n]
    else:
        return max(coins[n]+coinDPWithR(coins, n-2),coinDPWithR(coins,n-1))

def coinDP(coins, n):
    for i in range(2,n+1):
        lst[i] = max(coins[i]+lst[i-2],lst[i-1])
    return lst[n]

start_time = time.clock()
print coinDP([5,1,2,10,6,2], 5)
print '{:.30f}'.format(time.clock()-start_time)
start_time = time.clock()
print coinDPWithR([5,1,2,10,6,2], 5)
print '{:.30f}'.format(time.clock()-start_time)