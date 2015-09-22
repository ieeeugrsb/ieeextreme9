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
    num_lines = int(input())
    lines = []
    for i in range(num_lines):
        lines.append(input())
    
    # Show the result in the standard output
    print('.'.join(lines))


if __name__ == '__main__':
    main()