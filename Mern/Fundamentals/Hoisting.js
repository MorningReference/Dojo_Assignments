// 1
// Given
console.log(hello);
var hello = 'world';

// var hello;
// console.log(hello);
//

//2
// Given
var needle = 'haystack';
test();
function test() {
  var needle = 'magnet';
  console.log(needle);
}

// var needle;
// function test() {
//     var needle;
//     needle = 'magnet';
//     console.log(needle);
// }
// needle = 'haystack';
// test();

//3
// Given
var brendan = 'super cool';
function print() {
  brendan = 'only okay';
  console.log(brendan);
}
console.log(brendan);

// var brendan;
// function print() {           // does not run since the function is not called
//     brendan = 'only okay';
//     console.log(brendan);
// }
// brendan = 'super cool';
// console.log(brendan);       // console logs brendan global variable 'super cool'

//4
// Given
var food = 'chicken';
console.log(food);
eat();
function eat() {
  food = 'half-chicken';
  console.log(food);
  var food = 'gone';
}

// var food;
// function eat() {
//     var food;
//     food = 'half-chicken';
//     console.log(food);
//     food = 'gone';
// }
// food = 'chicken';
// console.log(food);   // console logs chicken first,
// eat();               // then console logs half-chicken

//5
// Given
mean();
console.log(food);
var mean = function () {
  food = 'chicken';
  console.log(food);
  var food = 'fish';
  console.log(food);
};
console.log(food);

// var mean;
// mean(); // type error
// console.log(food); // reference exception error
// mean = function() {
//     var food;
//     food = "chicken";
//     console.log(food);
//     food = "fish";
//     console.log(food);
// }
// console.log(food); // reference exception error

//6
// Given
console.log(genre);
var genre = 'disco';
rewind();
function rewind() {
  genre = 'rock';
  console.log(genre);
  var genre = 'r&b';
  console.log(genre);
}
console.log(genre);

// var genre;
// console.log(genre); //undefined
// function rewind() {
//     var genre;
//     genre = "rock";
//     console.log(genre);
//     genre = "r&b";
//     console.log(genre);
// }
// rewind(); // console logs rock, then r&b
// genre = "disco";
// console.log(genre); // disco

//7
// Given
dojo = 'san jose';
console.log(dojo);
learn();
function learn() {
  dojo = 'seattle';
  console.log(dojo);
  var dojo = 'burbank';
  console.log(dojo);
}
console.log(dojo);

// function learn() {
//     var dojo;
//     dojo = "seattle";
//     console.log(dojo);
//     dojo = "burbank";
//     console.log(dojo);
// }
// dojo = "san jose";
// console.log(dojo); // console log san jose
// learn(); //console log seattle then burbank
// console.log(dojo); // console log san jose again

//8
// Given
console.log(makeDojo('Chicago', 65));
console.log(makeDojo('Berkeley', 0));
function makeDojo(name, students) {
  const dojo = {};
  dojo.name = name;
  dojo.students = students;
  if (dojo.students > 50) {
    dojo.hiring = true;
  } else if (dojo.students <= 0) {
    dojo = 'closed for now';
  }
  return dojo;
}

// function makeDojo(name, students){
//     const dojo;
//     dojo = {};
//     dojo.name = name;
//     dojo.students = students;
//     if(dojo.students > 50){
//         dojo.hiring = true;
//     }
//     else if(dojo.students <= 0){
//         dojo = "closed for now"; // immutable object
//     }
//     return dojo;
// }
// console.log(makeDojo("Chicago", 65));
// console.log(makeDojo("Berkeley", 0));
