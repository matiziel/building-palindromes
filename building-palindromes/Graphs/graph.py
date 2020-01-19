import matplotlib.pyplot as plt
from math import sqrt , exp

X1 = []
Y1 = []

with open("../building-palindromes/ResultsBetterNaive.txt", "r") as file:
    while True:
        s1 = file.readline()
        if len(s1) == 0:
            break
        s2 = file.readline()
        if len(s2) == 0:
            break
        X1.append(int(s1))
        Y1.append(float(s2))

X2 = []
Y2 = []
with open("../building-palindromes/ResultsKmp.txt", "r") as file:
    while True:
        s1 = file.readline()
        if len(s1) == 0:
            break
        s2 = file.readline()
        if len(s2) == 0:
            break
        X2.append(int(s1))
        Y2.append(float(s2))

plt.plot(X2, Y2, label = 'Modified KMP')
plt.plot(X1, Y1, label = 'Quite better naive')

plt.ylabel('Czas')
plt.xlabel('Wielkość danych')

plt.title("Porownanie")
plt.legend()

plt.show()