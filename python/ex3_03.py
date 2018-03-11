'''
Using the imperative coding style, implement a function groupList
that given a list (list) and a group length (glength),
returns a list of lists with length glength. Example:

list = [1, 2,3,4,5,6]
groupList(list, 2) gives [ [1, 2], [3, 4], [5,6] ]
groupList(list, 3) gives [ [1, 2, 3], [4, 5, 6] ]
'''

def groupList(list, glength):
    groupedLists = []
    genList = []
    for index in range(0, len(list)):
        genList.append(list[index])
        if((index+1) % glength == 0):
            groupedLists.append(genList)
            genList = []
    return groupedLists;

defList = [1, 2, 3, 4, 5, 6]
groupedLists = groupList(defList, 2)
print(groupedLists)
