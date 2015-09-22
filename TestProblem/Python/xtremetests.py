#!/bin/python
# -*- coding: utf-8 -*-
############################################################################
#  xtremetests.py: Test framework for IEEEXtreme.                          #
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
import unittest
import time
import sys
import os

PROGRAM = ''

# For patching the standard input and standard output with the test case
class PatchStd(object):    
    def __init__(self, inputValue):
        self.inputValue = inputValue
        self.bkStdin = sys.stdin
        self.bkStdout = sys.stdout
        self.bkStderr = sys.stderr
        
    def __enter__(self):
        from io import StringIO

        # Monkey-patch stdin, stdout and stderr
        self.stdin = StringIO(self.inputValue)
        self.stdout = StringIO()
        self.stderr = StringIO()
        
        sys.stdin = self.stdin
        sys.stdout = self.stdout
        sys.stderr = self.stderr
        
        return self
        
    def getStdOut(self):
        return self.stdout
        
    def getStdIn(self):
        return self.stdin
        
    def getStdErr(self):
        return self.stderr
        
    def restore(self):
        # Undo the monkey-patch
        sys.stdin = self.bkStdin
        sys.stdout = self.bkStdout
        sys.stderr = self.bkStderr
        
    def __exit__(self, typ, val, traceback):
        self.restore()
        

class ProgramTest(unittest.TestCase):
    
    @classmethod
    def setUpClass(cls):
        cls.inputs = ["1\nhello world\n", "2\ntest1\ntest2\n"]
        cls.outputs = ["hello world\n", "test1.test2\n"]
        cls.num = 2
        cls.programPath = PROGRAM
        
        if not os.path.isfile(cls.programPath):
            raise FileNotFoundError('Cannot find program: ' + cls.programPath)
    
    def test_examples(self):
        for i in range(self.num):
            with self.subTest('Test Case: %d' % i):
                print('Testing ' + str(i))
                self.run_example(self.inputs[i], self.outputs[i])
        
    def run_example(self, theInput, theOutput):
        # Import program (decrapted in 3.4, no other way at the moment)
        from importlib.machinery import SourceFileLoader
        solution = SourceFileLoader("solution", self.programPath).load_module()
        
        # Feed the input
        with PatchStd(theInput) as std:
            # Start time counter
            startTime = time.time()
            
            # Run the program
            solution.main()
            
            # Get end time
            endTime = time.time() - startTime
        
            # Check output
            actual_output = std.getStdOut().getvalue()
            self.assertEqual(actual_output, theOutput)
            
            # Print time (not do before because output is not yet retrieved)
            std.restore()
            print("\tTime: %.3f" % endTime)
            
            # Show errors if any
            errors = std.getStdErr().getvalue()
            if errors != '':
                print("\t" + errors)
        

    def setUp(self):
        self.startTime = time.time()

    def tearDown(self):
        t = time.time() - self.startTime
        print("%s: %.3f" % (self.id(), t))
        
        
if __name__ == '__main__':
    # Set the program path
    if len(sys.argv) > 1:
        PROGRAM = sys.argv[1]
        del sys.argv[1]  # Otherwise unittest tries to load it
        
    unittest.main()