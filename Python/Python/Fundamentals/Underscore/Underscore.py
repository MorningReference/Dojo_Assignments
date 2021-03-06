class Underscore:
    def map(self, iterable, callback):
        for x in range(0, len(iterable), 1):
            iterable[x] = callback(iterable[x])
        return iterable
    def find(self, iterable, callback):
        for x in range(0, len(iterable), 1):
            if(callback(iterable[x])):
                return iterable[x]
    def filter(self, iterable, callback):
        newArr = []
        for x in range(0, len(iterable), 1):
            if(callback(iterable[x])):
                newArr.append(iterable[x])
        return newArr
    def reject(self, iterable, callback):
        count = 0
        for x in range(0, len(iterable), 1):
            x -= count
            if(callback(iterable[x])):
                iterable.pop(x)
                count += 1
        return iterable

# you just created a library with 4 methods!
# let's create an instance of our class
_ = Underscore() # yes we are setting our instance to a variable that is an underscore
evens = _.filter([1, 2, 3, 4, 5, 6], lambda x: x % 2 == 0)
print(evens)
# should return [2, 4, 6] after you finish implementing the code above
print(_.map([1,2,3], lambda x: x*2)) # should return [2,4,6]
print(_.find([1,2,3,4,5,6], lambda x: x>4)) # should return the first value that is greater than 4
print(_.filter([1,2,3,4,5,6], lambda x: x%2==0)) # should return [2,4,6]
print(_.reject([1,2,3,4,5,6], lambda x: x%2==0)) # should return [1,3,5]