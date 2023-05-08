# from textblob import TextBlob
from googletrans import Translator
from unidecode import unidecode


def tr2en(produces):

    line = produces.readline()
    translator = Translator()

    tranlatedFile = open("translatedFile.csv", "w")

    while line:

        splittedLine = line.split(',')

        produce = splittedLine[0] 
        kind = splittedLine[1].strip()

        print(produce + "," + kind )


        if produce:
            translatedProduce = translator.translate(produce, dest='en', src='tr')
        if kind:
            translatedKind = translator.translate(kind, dest='en', src='tr')


        if kind == None or kind == "":
            print(produce + "," + kind )
    
            tranlatedFile.write(translatedProduce.text + ","+ "\n")

        elif produce and kind:
            print(produce + "," + kind )

            tranlatedFile.write(translatedProduce.text + "," + translatedKind.text+"\n")

        line = produces.readline()

def clearTypos():
    
    file = open("translatedFile.txt", "r")

    codeFile = open("Code.csv", "w")


    line = file.readline()

    while line:

        splittedLine = line.split(',')

        splittedLine[0] = splittedLine[0].replace(" ","_")
        produce = splittedLine[0].strip()


        splittedLine[1] = splittedLine[1].replace(" ","_")
        splittedLine[1] = splittedLine[1].replace("'","_")
        splittedLine[1] = splittedLine[1].replace("II.","Second")
        splittedLine[1] = splittedLine[1].replace("I.","First")
        splittedLine[1] = splittedLine[1].replace("1.", "First")
        splittedLine[1] = splittedLine[1].replace("2.", "Second")

        if( not splittedLine[1].find("of") != -1) :
            splittedLine[1] = splittedLine[1].replace("0", "Zero")
            splittedLine[1] = splittedLine[1].replace("1", "One")
            splittedLine[1] = splittedLine[1].replace("2", "Two")
            splittedLine[1] = splittedLine[1].replace("3", "Three")
            splittedLine[1] = splittedLine[1].replace("4", "Four")
            splittedLine[1] = splittedLine[1].replace("5", "Five")
            splittedLine[1] = splittedLine[1].replace("6", "Six")
            splittedLine[1] = splittedLine[1].replace("7", "Seven")
            splittedLine[1] = splittedLine[1].replace("8", "Eight")
            splittedLine[1] = splittedLine[1].replace("9", "Nine")



        kind = splittedLine[1].strip()

        line = file.readline()

        print(unidecode((produce + "_" + kind).upper()))


        codeFile.write(unidecode((produce + "_" + kind+"\n").upper()))
        



if __name__ == "__main__":
    produces = open(file='Produce.csv')
    tr2en(produces) # writes tranlatedFile.txt
    clearTypos()