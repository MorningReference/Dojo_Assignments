# Loop through the array
# Nest another loop to check if the value in the index before this is smaller or larger
# If it's larger, swap those two values

def insertionSort(arr):
    for x in range(1, len(arr), 1):
        for y in range(x, 0, -1):
            if arr[y] < arr[y-1]:
                arr[y-1], arr[y] = arr[y], arr[y-1]
    return arr

arr = [6,5,3,1,8,7,2,4]

print(insertionSort(arr))