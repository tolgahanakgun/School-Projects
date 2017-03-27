'''
Created on 5 Haz 2016

@author: TOLGAHAN
'''
import sys
costs = [
         [9,2,7,8],
         [6,4,3,7],
         [5,8,1,8],
         [7,6,9,4]
         ]
costs1 = []
costs1.extend(costs)
jobs = [None]*4
for i,row in enumerate(costs):
    minIndex=row.index(min(row))
    jobs[minIndex] = i
    for i in range(0,4):
        costs[i][minIndex] = sys.maxint
print jobs
a=0
for i in range(0,4):
    a+=costs1[i][jobs[i]]
print a
print costs1