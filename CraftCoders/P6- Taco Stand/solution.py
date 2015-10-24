#!/bin/python
# -*- coding: utf-8 -*-


def calculo(a,b,c):
    resultado = 0
    if a<b and a!=0:
        resultado += a #hechos
        b = b-a
        a = 0

    elif a==b and a!=0:
        resultado += a
        a = 0
        b = 0
    elif a>b and b!=0:
        resultado +=(a-b) #hechos
        a = a-(a-b) #quedan
        b = b-(a-b)



    if a<c and a!=0:
        resultado +=a #hechos
        c = c-a
        a = 0

    elif a==c and c!=0:
        resultado += a
        a = 0
        c = 0
    elif a>c and c!=0:
        resultado +=(a-c) #hechos
        a = a-(a-c) #quedan
        c = c-(a-c)



    if c<b and c!=0:
        resultado +=c #hechos
        b = b-c
        c = 0

    elif c==b and c!=0:
        resultado += c
        c = 0
        b = 0
    elif c>b and b!=0:
        resultado +=(c-b) #hechos
        c = c-(c-b) #quedan
        b = b-(c-b)
    return resultado

def main():
    dias = int(input())
    contando = 0
    salida_final = []
    while (contando<dias):
        s,n,r,b = input().split(" ")
        posibles = calculo(int(n),int(r),int(b))
        contando+=1
        if posibles>int(s):
            salida_final.append(s)
        else:
            salida_final.append(posibles)

    for f in salida_final:
        print(f)

if __name__ == '__main__':
    main()
