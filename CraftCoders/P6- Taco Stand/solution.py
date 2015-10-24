#!/bin/python
# -*- coding: utf-8 -*-



def main():
    dias = int(input())
    for n in range(dias):
        ingredientes = [int(i) for i in input().split()]
        tacos_disp = ingredientes[0]
        comida = ingredientes[1:4]
        
        tacos = 0
        encontrado = False
        while not encontrado and tacos < tacos_disp:
            comida.sort()
            comida[-1] -= 1
            
            if comida[-2] != 0:
                comida[-2] -= 1
                tacos += 1
            else:
                encontrado=True
        
        print(tacos)

if __name__ == '__main__':
    main()
