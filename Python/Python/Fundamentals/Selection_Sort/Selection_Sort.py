def selectionSort(arr):
    count = 0
    minimumIndex = 0
    for x in range(0, len(arr), 1):
        minimum = float('inf')
        for y in range(count, len(arr), 1):
            if arr[y] < minimum:
                minimum = arr[y]
                minimumIndex = y
                print(arr[y], y)
        arr[x], arr[minimumIndex] = arr[minimumIndex], arr[x]
        count += 1

    return arr

arr = [8,3,4,7,2,0,1,5,6]

print(selectionSort(arr))