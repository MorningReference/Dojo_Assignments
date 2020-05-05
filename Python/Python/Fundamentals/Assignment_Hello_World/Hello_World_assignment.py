# 1. TASK: print "Hello World"
print( "Hello World" )

# 2. print "Hello Noelle!" with the name in a variable
name = "Aric"
print( "Hello", name + "!" )	# with a comma
print( "Hello " + name + "!" )	# with a +

# 3. print "Hello 42!" with the number in a variable
name = 77
print( "Hello", name, "!" )	# with a comma
# print( "Hello" + name + "!" )	# with a +	-- this one should give us an error!

name = "77"
# NINJA BONUS: Figure out how to resolve the error from above, without changing the + sign to a comma
print( "Hello " + name + "!" )

# 4. print "I love to eat sushi and pizza." with the foods in variables
fave_food1 = "soon doo boo"
fave_food2 = "bossam"
print( "I love to eat {} and {}.".format(fave_food1, fave_food2) ) # with .format()
print( f"I love to eat {fave_food1} and {fave_food2}." ) # with an f string
