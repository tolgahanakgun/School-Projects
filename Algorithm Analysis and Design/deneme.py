'''
Created on 2 Haz 2016

@author: TOLGAHAN
'''
'''
a = [5]*10
b = [7]*10
c = a + b
print c[8:11]
'''
'''
import sys
#print sys.getrecursionlimit()
sys.setrecursionlimit(1200)
def F(n):
    if n == 0: return 1
    else: return F(n-1)*n
print F(1100)
print len(str(F(1100)))
print F(81)
print len(str(F(81)))
'''

a = [[1,2,3]*5]
print a