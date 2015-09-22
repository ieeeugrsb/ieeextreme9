# -*- coding: utf-8 -*-
import unittest

# Import IEEEXtreme test framework
from importlib.machinery import SourceFileLoader
xtremetests = SourceFileLoader("xtremetests", "xtremetests.py").load_module()

class SolutionTest(xtremetests.ProgramTest):
    
    def test_my_custom_test(self):
        self.assertTrue(True)
        
    
if __name__ == '__main__':
    # Set the program path
    xtremetests.PROGRAM = 'solution.py'
        
    unittest.main()