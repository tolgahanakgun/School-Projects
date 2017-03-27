'''
Created on 5 Haz 2016

@author: TOLGAHAN
'''
items = [[0,0],[2,12],[1,10],[3,20],[2,15]]
c=5
dpt = [[0 for x in range(c+1)] for y in range(len(items))]
for i  in range(1,len(items)):
    for j in range(1,c+1):
        if j-items[i][0] >= 0:
            dpt[i][j] = max( dpt[i-1][j], items[i][1] + dpt[i-1][j-items[i][0]])
        else:
            dpt[i][j] = dpt[i-1][j]
for row in enumerate(dpt):
    print row
remC=c
lst = list()
for i  in range(len(items)-1,0,-1):
    if dpt[i][remC] == dpt[i-1][remC]:
        pass
    else:
        lst.append(i)
        remC=remC-items[i][0]
print lst
a=0
for i in lst:
    a+=items[i][1]
    print a