import numpy as np
from sklearn.metrics import accuracy_score
from sklearn.metrics import confusion_matrix
from sklearn.neighbors import KNeighborsClassifier

# The credit approval training and test data taken from :
# https://onlinecourses.science.psu.edu/stat857/node/215#TB_inline?height=300&width=700&inlineId=myOnPageContent1
# read training data from cvs file
data=np.loadtxt(open("training.csv", "rb"), delimiter=",", skiprows=1, usecols=range(2,22))
# read training data results from cvs file
result=np.loadtxt(open("training.csv", "rb"), delimiter=",", skiprows=1, usecols=range(1,2))
# read test data from cvs file
test_data=np.loadtxt(open("test.csv", "rb"), delimiter=",", skiprows=1, usecols=range(2,22))
# read test data results from cvs file
test_result=np.loadtxt(open("test.csv", "rb"), delimiter=",", skiprows=1, usecols=range(1,2))
# instantiate the KNN from cvs file
# distance metric chosen according to the information on :
# http://scikit-learn.org/stable/modules/generated/sklearn.neighbors.DistanceMetric.html
neigh = KNeighborsClassifier(n_neighbors=5, weights = 'distance', metric='canberra')
# train the system
neigh.fit(data, result)

# print the results
acc = accuracy_score(neigh.predict(test_data), test_result)
print "\nSystem success rate : %",acc*100
# print the confusion matrix
print "\nConfusion matrix :\n",confusion_matrix(test_result, neigh.predict(test_data), [0, 1])