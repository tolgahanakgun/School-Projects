'''
Created on 31 May 2016

@author: TOLGAHAN
'''
def fib(x):
    if x == 0:
        return 0
    if x == 1:
        return 1
    else:
        return fib(x-1) + fib(x-2)
print fib(50)