import numpy as np
import pandas as pd
from sklearn.metrics import accuracy_score
from sklearn.neighbors import KNeighborsClassifier

# read training data from excel file
data_columns= pd.read_excel("data.xlsx",parse_cols = 4)
# convert training data to matrix
data=np.array(data_columns.as_matrix())
# read result of training data
result_column= pd.read_excel("data.xlsx",parse_cols = 'F')
# convert results to matrix
result=np.array(result_column.as_matrix())
# convert results vector array to 1-d matrix
result=result.ravel()

# read test data from excel file
test_data_columns= pd.read_excel("data.xlsx",parse_cols = 4, skiprows=10)
# convert test data to matrix
test_data=np.array(test_data_columns.as_matrix())
# read result of test data
test_result_column= pd.read_excel("data.xlsx",parse_cols = 'F', skiprows=10)
# convert test results to matrix
test_result=np.array(test_result_column.as_matrix())
# convert test results vector array to 1-d matrix
test_result=test_result.ravel()

# instantiate KNeighborsClassifier
neigh = KNeighborsClassifier(n_neighbors=3)
# train the system
neigh.fit(data, result)

print "Test Results"
print test_result

print  "\nPredicted Results"
print neigh.predict(test_data)

acc = accuracy_score(neigh.predict(test_data), test_result)
print "\nSistemin basari yuzdesi : %",acc*100