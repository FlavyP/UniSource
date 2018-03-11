'''
Using the imperative way of programming, find even numbers (printEvenNumbers)
given a list of natural numbers:
naturalNumbers = [0,1,2,3,4,5,6,7,8,9]
In order to determine which numbers are even in the list,
you have to explicitly code the loop and check whether
each number is even or not.
'''

def findEvenNumbers(naturalNumbers):
    evenNumbers = []
    for num in naturalNumbers:
        if num % 2 == 0:
            evenNumbers.append(num)
    return evenNumbers;

naturalNumbers = [0,1,2,3,4,5,6,7,8,9]
evenNumbers = findEvenNumbers(naturalNumbers)
print(evenNumbers)
