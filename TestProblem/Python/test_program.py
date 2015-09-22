# -*- coding: utf-8 -*-
import unittest
import time
import subprocess

class ProgramTest(unittest.TestCase):
    
    @classmethod
    def setUpClass(cls):
        cls.inputs = ["1\nhello world", "2\ntest1\ntest2"]
        cls.outputs = ["hello world\n", "test1.test2\n"]
        cls.num = 2
        print()
    
    def test_examples(self):
        for i in range(self.num):
            with self.subTest('Test Case: %d' % i):
                self.run_example(i)
        
    def run_example(self, num):
        # Start time counter
        startTime = time.time()
        
        # Start program
        actual_output = subprocess.check_output(["python", "program.py"],
                                                input=self.inputs[num],
                                                stderr=subprocess.STDOUT,
                                                shell=True,
                                                universal_newlines=True)
        # Get end time and show time.
        endTime = time.time() - startTime
        print("+ Test case %s: %.3f" % (num, endTime))        
        
        # Check output
        self.assertEqual(actual_output, self.outputs[num])

    def setUp(self):
        self.startTime = time.time()

    def tearDown(self):
        t = time.time() - self.startTime
        print("%s: %.3f" % (self.id(), t))
        
        
if __name__ == '__main__':
    unittest.main()