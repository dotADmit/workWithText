using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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





            string[] textToArray = userText.Split(new char[] { ' ', ',', '.', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> duplicateList = new List<string>();

            List<WordDuplicate> wordsDupList = new List<WordDuplicate>();


            for (int i = 0; i < textToArray.Length - 1; i++)
            {
                for (int k = i + 1; k < textToArray.Length; k++)
                {
                    if (textToArray[i] == textToArray[k] && !duplicateList.Contains(textToArray[i]))
                    {
                        duplicateList.Add(textToArray[i]);
                    }
                }
            }

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

            int countResetColour = 0;

            for (int i = 0; i < userText.Length; i++)
            {
                for (int l = 0; l < wordsDupList.Count; l++)
                {
                    if (i == wordsDupList[l].indexOf)
                    {
                        ConsoleColor myColor = (ConsoleColor)wordsDupList[l].colour;
                        Console.ForegroundColor = myColor;
                        countResetColour = i + wordsDupList[l].lenght;
                        break;
                    }
                }
                if (i == countResetColour)
                {
                    Console.ResetColor();
                }
                Console.Write(userText[i]);
                Thread.Sleep(100);
            }

            //for (int i = 0; i < arrText.Length; i++)
            //{
            //    Console.ResetColor();
            //    for (int k = 0; k < lDublicate.Count; k++)
            //    {
            //        if (arrText[i] == lDublicate[k])
            //        {
            //            ConsoleColor myColor = (ConsoleColor)k + 3;
            //            Console.ForegroundColor = myColor;
            //        }
            //    }
            //    Console.Write(arrText[i] + " ");
            //}




            Console.ReadLine();

        }
    }
}
