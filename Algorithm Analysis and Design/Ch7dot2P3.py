'''
Created on 2 Haz 2016

@author: TOLGAHAN
'''
i=0
lst = ''.join(['0']*1000)
x = "01010"
for num in range(4,999,2):
    y=num
    for ind in range(4,0,-1):
        if num+5 > 1000:
            break
        i=i+1
        if lst[y] != x[ind]:
            break
        y=num-1
print
print i
print len(lst)