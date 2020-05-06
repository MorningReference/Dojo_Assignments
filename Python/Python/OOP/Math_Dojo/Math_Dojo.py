class MathDojo:
    def __init__(self):
        self.result = 0
    def add(self, num, *nums):
        self.result += num
        for x in nums:
            self.result += x
        return self
    def subtract(self, num, *nums):
        self.result -= num
        for x in nums:
            self.result -= x
        return self
# create an instance:
md = MathDojo()
# to test:
x = md.add(2).add(2,5,1).subtract(3,2).result
print(x)	# should print 5
# run each of the methods a few more times and check the result!

y = md.add(5,10).add(20,30).add(60,70).result
print(y)

z = md.subtract(1,2,3,4,5,6,7,8,9).subtract(20).subtract(23,64,3).result
print(z)
