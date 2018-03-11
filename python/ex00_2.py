'''
Write another program that will ask the user for a “wish” (eg. What do you wish for on your birthday)
and the number of time they want that wish to be displayed.
Then print the wish the number of times specified.
'''
wish = input("What do you wish for?")
wish_no = int(input("How many times did you wish for this?"))
for count in range(wish_no):
    print(count, " - ", wish)
