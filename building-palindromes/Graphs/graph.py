import matplotlib.pyplot as plt
from math import sqrt , exp

X1 = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
Y1 = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
X2 = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
Y2 = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
Q1 = [0, 0, 0, 0, 1, 0, 0, 0, 0, 0]
Q2 = [0, 0, 0, 0, 1, 0, 0, 0, 0, 0]

LENGTH = 10

for k in range(10):
    with open("results/ResultsBetterNaive{0}.txt".format(k), "r") as file:
        i = 0
        while True:
            s1 = file.readline()
            if len(s1) == 0:
                break
            s2 = file.readline()
            if len(s2) == 0:
                break
            X1[i] += int(s1)
            Y1[i] += float(s2)
            i += 1


    with open("results/ResultsKmp{0}.txt".format(k), "r") as file:
        i = 0
        while True:
            s1 = file.readline()
            if len(s1) == 0:
                break
            s2 = file.readline()
            if len(s2) == 0:
                break
            X2[i] += int(s1)
            Y2[i] += float(s2)
            i += 1

for i in range(len(X1)):
    X1[i] /= LENGTH
    Y1[i] /= LENGTH
    X2[i] /= LENGTH
    Y2[i] /= LENGTH
    if i < 9:
        Q1[i] = Y1[i] / X1[i] ** 2 
        Q1[i] *= X1[4] ** 2 / Y1[4]
        Q2[i] = Y2[i] / X2[i] ** 3 
        Q2[i] *= X2[4] ** 3 / Y2[4]


print (Q1)
print (Q2)


# plt.plot(X2, Y2, label = 'Modified KMP')
# plt.plot(X1, Y1, label = 'Quite better naive')

# plt.ylabel('Czas')
# plt.xlabel('Wielkość danych')

# plt.title("Quite better naive")
# plt.legend()

# plt.show()