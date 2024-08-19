def bubblesort(input):
    for i in range(1, len(input)):
        if input[i - 1] > input[i]:
            temp = input[i - 1]
            input[i - 1] = input[i]
            input[i] = temp
        print(input)
    return input


arr = [5, 4, 3, 2, 1]
out = bubblesort(arr)
print(out)
