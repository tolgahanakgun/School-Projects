'''
Created on 7 Haz 2016

@author: TOLGAHAN
'''
x=0
def FindMax(lst,m,n):
    global x
    x+=1
    if n-m==1:
        return m
    a = FindMax(lst, m, (m+n)/2)
    b = FindMax(lst, (m+n)/2, n)
    return a if lst[a]>lst[b] else b
a=[0,12,48,5,87,10,45,5,8,10,11,14,15,74,14,32,87,77,78,14,43,65,123,86,71,3,74]
print FindMax(a, 0, len(a)-1)
print x