//
//  Test.cs
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
using System.Collections;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace Solution.Tests
{
    [TestFixture]
    public class SolutionTests
    {
        protected string TestSolution(string input)
        {
            // Save the standard input and output for restoring later.
            var stdIn = Console.In;
            var stdOut = Console.Out;

            // Redirect the output writing to a StringBuilder.
            var output = new StringBuilder();
            var redirectedOutput = new StringWriter(output);
            Console.SetOut(redirectedOutput);

            // Redirect the input reading from the string.
            var redirectedInput = new StringReader(input);
            Console.SetIn(redirectedInput);

            // Call our program.
            MainClass.Main();

            // Restore input and output.
            Console.SetIn(stdIn);
            Console.SetOut(stdOut);

            // Return output
            return output.ToString();
        }

        [Test, TestCaseSource("PublicCases")]
        public string TestPublicCases(string input)
        {
            return TestSolution(input);
        }

        public IEnumerable PublicCases
        {
            get
            {
                yield return new TestCaseData("2\nHello\nWorld").Returns("Hello.World");
            }
        }
    }
}

