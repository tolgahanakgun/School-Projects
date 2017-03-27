'''
Created on 2 Haz 2016

@author: TOLGAHAN
'''
'''
def fib(x):
    a=0
    b=1
    c=1
    for i in range(2,x):
        a=b
        b=c
        c=a+b
    return c
print fib(10)
'''
fibs=[None]*100
fibs[0]=0
fibs[1]=1
def fib(x):
    for i in range(2,x+1):
        fibs[i]=fibs[i-1]+fibs[i-2]
    return fibs[x]
print fib(10)