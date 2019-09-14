using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workWithText
{
    class Program
    {
        struct Word
        {
            public int indexOf;
            public int lenght;
            public int colour;
        }
        static void Main(string[] args)
        {
            string text = @"В нашей команде есть программист   Иван.
Иван умеет разрабатывать мобильные и веб приложения.
Каждый программист в нашей команде программирует на языке С#.
Однако Иван знает ещё язык PHP....";





            string[] arrText = text.Split(new char[] { ' ', ',', '.', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> lDublicate = new List<string>();

            List<Word> dublicateList = new List<Word>();


            for (int i = 0; i < arrText.Length - 1; i++)
            {
                for (int k = i + 1; k < arrText.Length; k++)
                {
                    if (arrText[i] == arrText[k] && !lDublicate.Contains(arrText[i]))
                    {
                        lDublicate.Add(arrText[i]);
                    }
                }
            }

            for (int i = 0; i < lDublicate.Count; i++)
            {
                int findIndex = 0;
                while (findIndex != -1)
                {
                    findIndex = text.IndexOf(lDublicate[i], findIndex);
                    if (findIndex > -1)
                    {
                        dublicateList.Add(new Word()
                        {
                            indexOf = findIndex,
                            lenght = lDublicate[i].Length,
                            colour = i + 1
                        });
                        findIndex += 1;
                    }
                }
            }

            for (int i = 0; i < text.Length; i++)
            {
                for (int l = 0; l < dublicateList.Count; l++)
                {
                    if (i == dublicateList[l].indexOf)
                    {
                        ConsoleColor myColor = (ConsoleColor)dublicateList[l].colour;
                        Console.ForegroundColor = myColor;
                        for (int m = i; m < dublicateList[l].lenght + i; m++)
                        {
                            Console.Write(text[m]);
                        }
                        i += dublicateList[l].lenght;
                        Console.ResetColor();
                        continue;
                    }
                }

                Console.Write(text[i]);
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
