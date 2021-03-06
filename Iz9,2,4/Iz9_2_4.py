from math import *
# 9.2.4. Сколько существует эйлеровых графов из 9 вершин и 12 ребер?
def fac(n):
    if n == 0:
        return 1
    return fac(n-1) * n

def sum_for(p,x):
    s=0
    for i in range(p+1):
        s+=comb(p,i)*pow((1-x)/(1+x),i*(p-i))
    return s
def w(p,x):
    if p<3:
        return 1
    return 1/pow(2,p)*pow((1+x),comb(p,2))*sum_for(p,x)

def WWW(p,y):
    s=0
    for i in range(1,y+1):
        s+=(w(i,p)*pow(y,i))/fac(i)
    return s
def u(x,y):
    return log(1+WWW(x,y))

print(int(u(9,12)))