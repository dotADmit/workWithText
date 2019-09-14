using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workWithText
{
    class Program
    {
        struct WordDuplicate
        {
            public int indexOf;
            public int lenght;
            public int colour;
        }
        static void Main(string[] args)
        {
            string userText = @"В нашей команде есть программист   Иван.
Иван умеет разрабатывать мобильные и веб приложения.
Каждый программист в нашей команде программирует на языке С#.
Однако Иван знает ещё язык PHP....";


            string[] textToArray = getArrayFromText(userText);

            List<string> duplicateList = getListOfDuplicates(textToArray);

            List<WordDuplicate> wordsDupList = getListOfDuplicatesDescription(userText, duplicateList);

            printTextWithColoredCopiesView(userText, wordsDupList);

            Console.ReadLine();

        }
        static string[] getArrayFromText(string userText)
        {
            return userText.Split(new char[] { ' ', ',', '.', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        }
        static List<string> getListOfDuplicates(string[] wordsFromUserText)
        {
            List<string> duplicateList = new List<string>();
            for (int i = 0; i < wordsFromUserText.Length - 1; i++)
            {
                for (int k = i + 1; k < wordsFromUserText.Length; k++)
                {
                    if (wordsFromUserText[i] == wordsFromUserText[k] && !duplicateList.Contains(wordsFromUserText[i]))
                    {
                        duplicateList.Add(wordsFromUserText[i]);
                    }
                }
            }
            return duplicateList;
        }
        static List<WordDuplicate> getListOfDuplicatesDescription(string userText, List<string> duplicateList)
        {
            List<WordDuplicate> wordsDupList = new List<WordDuplicate>();

            for (int i = 0; i < duplicateList.Count; i++)
            {
                int findIndex = 0;
                while (findIndex != -1)
                {
                    findIndex = userText.IndexOf(duplicateList[i], findIndex);
                    if (findIndex > -1)
                    {
                        wordsDupList.Add(new WordDuplicate()
                        {
                            indexOf = findIndex,
                            lenght = duplicateList[i].Length,
                            colour = i + 1
                        });
                        findIndex += 1;
                    }
                }
            }
            return wordsDupList;
        }
        static void printTextWithColoredCopiesView(string userText, List<WordDuplicate> wordsDupList)
        {
            int countResetColour = 0;

            for (int i = 0; i<userText.Length; i++)
            {
                for (int l = 0; l<wordsDupList.Count; l++)
                {
                    if (i == wordsDupList[l].indexOf)
                    {
                        Console.ForegroundColor = (ConsoleColor) wordsDupList[l].colour;
                        countResetColour = i + wordsDupList[l].lenght;
                        break;
                    }
}
                if (i == countResetColour)
                {
                    Console.ResetColor();
                }
                Console.Write(userText[i]);
            }
        }
}
}
