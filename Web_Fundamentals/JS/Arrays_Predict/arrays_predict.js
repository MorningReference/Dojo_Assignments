//Predict 1:

var sum = 0;
for(var i = 1; i < 6; i++) {
    sum += i;
    console.log("Num: " + i);
    console.log("Sum: " + sum);
}

//Num: 1, Sum: 1, Num: 2, Sum: 3, Num: 3, Sum: 6, Num: 4, Sum: 10, Num: 5, Sum: 15

//Predict 2:

var arr = [7,3,8,4,2,0,1];
for(var i = 0; i < arr.length; i++){ 
    if(arr[i] % 2 == 0){
        console.log(arr[i]);
    } 
    else{
        console.log("That is odd!");
    }
}

//That is odd!, That is odd!, 8, 4, 2, 0, That is odd!

//Predict 3:
var arr = [1,3,8,-5,0,-2,4,-1];
var newArr = [];
for(var i = 0; i< arr.length; i++){
    if(arr[i] < 0){
        newArr.push(arr[i]);
        arr[i] = arr[i] * -1;
    }
    else if(arr[i] == 0){
        arr[i] = "Zero";
    }
    else{
        arr[i] = arr[i] * -1;
    }
}
console.log(arr);
console.log(newArr);

//[-1, -3, -8, 5, Zero, 2, -4, 1], [-5, -2, -1]