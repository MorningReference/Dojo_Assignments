function bubbleSort(arr){
    var counter = 1;
    while(counter > 0) {
        counter = 0;

        for(var i = 0; i <arr.length-1;  i++){
            if(arr[i] > arr[i+1]){
                var swap = arr[i +1];
                arr[i+1] = arr[i];
                arr[i] = swap
                counter++;
            }

        }
    }
    return arr;
}