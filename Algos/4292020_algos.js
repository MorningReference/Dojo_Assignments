var zeros = [3,4,0,3,0,6,7,0,8];

function zerothingy(arr) {
    var newArr = [];
    var counter=0;

    for(var i=0;i<arr.length;i++)
    {
        if(arr[i]>0){
            newArr.push(arr[i]);
        }
        else if(arr[i] == 0){
            counter++;
        }
        
    }
    for(var j=0;j<counter;j++) {
        newArr.push(0);
    }   
    return newArr;
}