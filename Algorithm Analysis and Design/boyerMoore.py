# Boyer Moore String Search implementation in Python
# Ameer Ayoub <ameer.ayoub@gmail.com>

# Generate the Bad Character Skip List
def generateBadCharShift(term):
    skipList = {}
    for i in range(0, len(term)-1):
        skipList[term[i]] = len(term)-i-1
    return skipList

# Generate the Good Suffix Skip List
def findSuffixPosition(badchar, suffix, full_term):
    for offset in range(1, len(full_term)+1)[::-1]:
        flag = True
        for suffix_index in range(0, len(suffix)):
            term_index = offset-len(suffix)-1+suffix_index
            if term_index < 0 or suffix[suffix_index] == full_term[term_index]:
                pass
            else:
                flag = False
        term_index = offset-len(suffix)-1
        if flag and (term_index <= 0 or full_term[term_index-1] != badchar):
            return len(full_term)-offset+1

def generateSuffixShift(key):
    skipList = {}
    buff = ""
    for i in range(0, len(key)):
        skipList[len(buff)] = findSuffixPosition(key[len(key)-1-i], buff, key)
        buff = key[len(key)-1-i] + buff
    return skipList
    
# Actual Search Algorithm
def BMSearch(haystack, needle):
    goodSuffix = generateSuffixShift(needle)
    badChar = generateBadCharShift(needle)
    i = 0
    indeks = 0
    while i < len(haystack)-len(needle)+1:
        j = len(needle)
        indeks += 1
        while j > 0 and needle[j-1] == haystack[i+j-1]:
            j -= 1
            indeks += 1
        if j > 0:
            badCharShift = badChar.get(haystack[i+j-1], len(needle))
            goodSuffixShift = goodSuffix[len(needle)-j]
            if badCharShift > goodSuffixShift:
                i += badCharShift
            else:
                i += goodSuffixShift
        else:
            print indeks
            return i
    print indeks
    return -1

if __name__ == "__main__":
    block = ''.join(['0'*1000])
    print BMSearch(block, "01010")
    
    for x,y in generateSuffixShift("01010").iteritems():
        if int(x) == 0:
            continue
        print x,y
    print

    """a = stack()
    for item in generateBadCharShift("barber"):
        a.append(item)
        #print item
    for i in range(0,len(a)-1
    ):
        print a.pop()
    """