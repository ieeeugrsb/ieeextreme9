//
//  Program.cs
//
//  Author:
//       Benito Palacios Sánchez (aka pleonex) <benito356@gmail.com>
//
//  Copyright (c) 2015 Benito Palacios Sánchez (c) 2015
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Linq;

namespace CSharp
{
    class MainClass
    {
        public static void Main()
        {
            int numLines = Convert.ToInt32(Console.ReadLine());
            string[] lines = new string[numLines];
           
            for (int i = 0; i < numLines; i++)
                lines[i] = Console.ReadLine();

            string result = lines.Aggregate((working, next) => working + "." + next);
            Console.Write(result);
        }
    }
}
