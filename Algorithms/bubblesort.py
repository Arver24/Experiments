def bubblesort(input):
    sorted = False
    pass_count = 1
    while not sorted:
        print(f"pass no: {pass_count}")
        any_swapping = False
        for i in range(1, len(input)):
            if input[i - 1] > input[i]:
                temp = input[i]
                input[i] = input[i - 1]
                input[i - 1] = temp
                any_swapping = True
            print(input)
        if not any_swapping:
            sorted = True
        pass_count += 1
    return input


arr = [5, 4, 3, 2, 1]
out = bubblesort(arr)
# print(out)
