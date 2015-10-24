# -*- coding: utf-8 -*-
"""
Created on Sat Oct 24 09:45:04 2015

@author: nitehack
"""


dias=int(input())

for n in range(dias):
    ingredientes=[]
    ingredient=input()
    ingredient=ingredient.split()
    for i in ingredient:
        ingredientes.append(int(i))
    tacos_disp=ingredientes[0]
    comida=ingredientes[1:4]
    
    pcomida=[]
    tacos=0
    encontrado=False
    while not encontrado:
        ind_max=comida.index(max(comida))
        comida[ind_max]-=1
        pcomida=comida[:]
        pcomida[ind_max]=-1
        ind_max=pcomida.index(max(pcomida))
        if comida[ind_max]!=0:
            comida[ind_max]-=1
            tacos=tacos+1
        else:
            encontrado=True
    
    if tacos>tacos_disp:
        creados=tacos_disp
    else:
        creados=tacos
    
    print(creados)

    
        





    