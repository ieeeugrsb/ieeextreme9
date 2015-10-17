#!/bin/python
# -*- coding: utf-8 -*-
############################################################################
#  solution.py: Example solution to a problem.                             #
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
def main():
    # Get data from the standard input
    entry = input()
    char_count = {}

    # Count each char    
    for ch in entry:
        if not ch in char_count:
            char_count[ch] = 0
            
        char_count[ch] += 1
    
    # Check for each letter if there are an even count or just one odd.
    is_palindrome = True
    any_odd = False
    for ch in char_count:
        if char_count[ch] % 2 != 0:
            if not any_odd:
                any_odd = True
            else:
                is_palindrome = False
                break
    
    print("YES" if is_palindrome else "NO", end="")


if __name__ == '__main__':
    main()