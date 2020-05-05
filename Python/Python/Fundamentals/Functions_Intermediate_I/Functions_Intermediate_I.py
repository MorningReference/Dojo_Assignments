import random
def randInt(min= 0, max= 100):
    if min > max:
        print("Your minimum exceeds the maximum! Try again")
        return
    if max < 0:
        print("Re-enter a maximum greater than 0! Try again")
    num = random.random() * max + min
    return round(num)
print(randInt()) 		    # should print a random integer between 0 to 100
print(randInt(max=50)) 	    # should print a random integer between 0 to 50
print(randInt(min=50)) 	    # should print a random integer between 50 to 100
print(randInt(min=50, max=500))    # should print a random integer between 50 and 500
print(randInt(min=200, max=20)) #should print "Your minimum exceeds the maximum! Try again"
print(randInt(max = -1)) #should print "Re-enter a maximum greater than 0! Try again"