import unittest

class MathDojo:
    def __init__(self):
        self.result = 0
    def add(self, num, *nums):
        if num == None:
            return False
        elif type(num) != int:
            return False
        else:
            self.result += num
            for x in nums:
                if x == None:
                    return False
                elif type(x) != int:
                    return False
                else:
                    self.result += x
            return self
    def subtract(self, num, *nums):
        if num == None:
            return False
        elif type(num) != int:
            return False
        else:
            self.result -= num
            for x in nums:
                if x == None:
                    return False
                elif type(x) != int:
                    return False
                else:
                    self.result -= x
            return self
        

class mathDojoTest(unittest.TestCase):
    def testBlank(self):
        self.assertFalse(self.md.add(1,2,None))
    def testInputString(self):
        self.assertFalse(self.md.subtract(3, 'this is a string', 5))
    def testFunctionality(self):
        self.assertEqual(self.md.add(1,2,4).subtract(1,2,3).result, 1)
    def setUp(self):
        self.md = MathDojo()
    def tearDown(self):
        print("running tearDown tasks")

if __name__ == '__main__':
    unittest.main()