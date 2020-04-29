var users = [{name: "Michael", age:37}, {name: "John", age:30}, {name: "David", age:27}];

//print John's age
console.log("John's age is: " + users[1].age);

//print First object
console.log(users[0].name);

//print Name and age of each user using for loop
for(var i = 0; i < users.length; i++) {
    console.log(users[i]);
}
