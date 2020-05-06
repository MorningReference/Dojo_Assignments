import unittest
#1. reverseList - Write a function that reverses the values in the list (without creating a temporary listay).
#     Example: reverseList([1,3,5]) should return [5,3,1]
#     Example Test: assertEqual( reverseList([1,3,5]), [5,3,1] )
#     Add at least 3 other test cases
def reverseList(list):
    if len(list) <= 1:
        return False
    for x in range(round(len(list)/2)):
        list[x], list[len(list)-1 -x] = list[len(list)-1 - x], list[x]
    return list

class reverseListTests(unittest.TestCase):
    def testOne(self):
        self.assertEqual(reverseList([1,2,3,4,5]), [5,4,3,2,1])
    def testTwo(self):
        self.assertFalse(reverseList([1]))
    def testThree(self):
        self.assertNotEqual(reverseList([1,2,3,4,5]), [1,2,3,4,5])
    def setUp(self):
        print("Running setUp now!")

    def tearDown(self):
        print("running tearDown tasks")

if __name__ == '__main__':
    unittest.main()

#2. isPalindrome - Write a function that checks whether the given word is a palindrome (a word that spells the same backward).
#     Example: isPalindrome("racecar") should return True
#     Example Test: assertEqual( isPalindrome("racecar"), True ) or assertTrue( isPalindrome("racecar"))
#     Example Test: assertFalse( isPalindrome("rabcr") ).
#     Add at least 5 other test cases
def isPalindrome(string):
    if string == None:
        return False
    elif type(string) != str:
        return False
    elif len(string) <= 1:
        return False
    else:
        newStr = string[::-1]
        if newStr == string:
            return True
        else:
            return False

class isPalindromeTest(unittest.TestCase):
    def testLengthString(self):
        self.assertFalse(isPalindrome('a'))
    def testIsNotNumber(self):
        self.assertFalse(isPalindrome(1))
    def testIsBool(self):
        self.assertIsInstance(isPalindrome('racecar'), bool)
    def testIsNotNone(self):
        self.assertIsNotNone(isPalindrome('racecar'))
    def testBlank(self):
        self.assertFalse(isPalindrome(None))
    def setUp(self):
        print("running setUp!")
    def tearDown(self):
        print("running tearDown tasks")
if __name__ == '__main__':
    unittest.main()

#3. coins - Write a function that determines how many quarters, dimes, nickels, and pennies to give to a customer for a change where you minimize the number of coins you give out.
#     Example: given 87 cents, result should be 3 quarters, 1 dime, 0 nickel and 2 pennies
#     Example Test: assertEqual( coin(87), [3,1,0,2] )
#     Add at least 5 other test cases
def coins(change):
    quarters, dimes, nickles, pennies = 0,0,0,0
    if(change == None):
        return False
    elif(type(change) != int):
        return False
    elif(change <= 0):
        return False
    else:
        while change > 0:
            if change >= 25:
                quarters = round(change/25)
                change %= 25
            elif change >= 10:
                dimes = round(change/10)
                change %= 10
            elif change >= 5:
                nickles = round(change/5)
                change %= 5
            elif change >= 1:
                pennies = change
                change %= change
        return [quarters, dimes, nickles, pennies]

class coinsTest(unittest.TestCase):
    def testIsNotString(self):
        self.assertFalse(coins('this is a string'))
    def testnegativeNum(self):
        self.assertFalse(coins(-1))
    def testBlank(self):
        self.assertFalse(coins(None))
    def testFunctionality(self):
        self.assertEqual(coins(87),[3,1,0,2])
    def testIsNotNone(self):
        self.assertIsNotNone(coins(67))
    def testIsList(self):
        self.assertIsInstance(coins(81), list)
    def setUp(self):
        print("running setUp")
    def tearDown(self):
        print("running tearDown tasks")

if __name__ == '__main__':
    unittest.main()


# BONUS - factorial - Write a recursive function that returns the factorial of a given number. Remember that the factorial of a number is the product of all the numbers between 1 and the given number (eg. 4! = 4*3*2*1).
#     Example: factorial(5) should return 120.
#     Add at least 3 test cases
def factorial(num):
    if num == None:
        return False
    elif type(num) != int:
        return False
    elif num == 1:
        return num
    else:
        return num*factorial(num-1)

class factorialTest(unittest.TestCase):
    def testBlank(self):
        self.assertFalse(factorial(None))
    def testInputString(self):
        self.assertFalse(factorial('this is a string'))
    def testfunctionality(self):
        self.assertEqual(factorial(5), 120)
    def setUp(self):
        print("running setUp")
    def tearDown(self):
        print("running tearDown tasks")

# if __name__ == "__main__":
#     unittest.main()
# BONUS - fibonacci - Write a recursive function that accepts a number, n, and returns the nth Fibonacci number from the sequence. The first two Fibonacci numbers are 0 and 1. Every number after that is calculated by adding the previous 2 numbers from the sequence. (i.e. 0, 1, 1, 2, 3, 5, 8, 13, 21 ...)
#     The sequence starts with fib(0) so fib(5) is actually 5 and fib(4) is 3. https://en.wikipedia.org/wiki/Fibonacci_number
#     Add at least 3 test cases
def fibonacci(n):
    if n == None:
        return False
    elif type(n) != int:
        return False
    elif n < 0:
        return False
    elif n <= 1:
        return n
    else:
        return fibonacci(n-1)+fibonacci(n-2)

class fibonacciTest(unittest.TestCase):
    def testBlank(self):
        self.assertFalse(fibonacci(None))
    def testFunctionality(self):
        self.assertEqual(fibonacci(6), 8)
    def testInputString(self):
        self.assertFalse(fibonacci('this is a string'))
    def testNegativeNum(self):
        self.assertFalse(fibonacci(-1))
    def setUp(self):
        print("running setUp")
    def tearDown(self):
        print("running tearDown tasks")

if __name__ == '__main__':
    unittest.main()