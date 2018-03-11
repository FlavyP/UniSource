'''
Write a program to check that a given character is in a given string.
It will ask the user to enter a string and a character to search.
Use linear search for this program where you loop through all the characters.
'''
def findCharInWord(char, word):
    for c in word:
        if c == char:
            return "Found char " + char + " in word " + word;
    return "Could not find char " + char + " in word " + word;

word = input("Input a word - ")
char = input("Char to find - ")
print (findCharInWord(char, word))
