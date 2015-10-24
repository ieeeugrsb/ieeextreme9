#!/bin/python
# -*- coding: utf-8 -*-
############################################################################
#  Copyright (C) 2015 Benito Palacios Sánchez                              #
#                                                                          #
#  This program is free software: you can redistribute it and/or modcify   #
#  it under the terms of the GNU General Public License as published by    #
#  the Free Software Foundation, either version 2 of the License, or       #
#  (at your option) any later version.                                     #
#                                                                          #
#  This program is distributed in the hope that it will be useful,         #
#  but WITHOUT ANY WARRANTY; without even the implied warranty of          #
#  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the            #
#  GNU General Public License for more details.                            #
#                                                                          #
#  You should have received a copy of the GNU General Public License       #
#  along with this program. If not, see <http://www.gnu.org/licenses/>.    #
############################################################################


MAX_TIME = 60
TIME_PER_ROUND = 5
MAX_ROUNDS = MAX_TIME / TIME_PER_ROUND


def play(game, rounds):
    print("Playing... " + str(rounds) + " -> ", end="")
    print(game)
    if rounds >= MAX_ROUNDS:
        return False

    if game[0] == game[1] or game[0] == game[2] or game[1] == game[2]:
        print(rounds)
        return True

    for i in range(3):
        for j in range(i + 1, 3):
            # i vs j
            win = 0
            lose = 0
            if game[i] < game[j]:
                win = i
                lose = j
            else:
                win = j
                lose = i

            print("\tWin: " + str(win))
            print("\tLose: " + str(lose))

            # Update status
            new_game = game[:]
            double = game[win] * 2
            new_game[lose] -= game[win]
            new_game[win] = double

            # Play again
            result = play(new_game, rounds + 1)

            if result:
                return True


def main():
    game = [1, 4, 6]
    result = play(game, 0)

    if not result:
        print("Ok")


if __name__ == '__main__':
    main()
