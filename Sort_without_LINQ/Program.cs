using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Введите количество слов:");
        int countWords = Convert.ToInt32(Console.ReadLine());
        //исходный массив
        string[] words = new string[countWords];
        //массив для записи слов к-е уже вывели
        string[] wordsSorted = new string[countWords];
        int[] countRepeat = new int[countWords];
        //переменная для подсчета вхождений
        int countRepeats = 0;

        //ввод слов с клавиатуры
        for (var i = 0; i < words.Length; i++)
        {
            Console.WriteLine($"Введите слово №{i+1}");
            words[i] = Console.ReadLine();
        }
        for (var i = 0; i < words.Length; i++)
        {
            for (var j = words.Length - 1; j >= 0; j--)
            {
                if (words[i] == words[j])
                {
                    countRepeats++;
                }
                countRepeat[i] = countRepeats;
            }
            countRepeats = 0;
        }

        string temp;
        int tempTwo;

        //сортировка по к-ву
        for (int i = 0; i < words.Length - 1; i++)
        {
            for (int j = i + 1; j < words.Length; j++)
            {
                if (countRepeat[i] < countRepeat[j])
                {
                    temp = words[i];
                    words[i] = words[j];
                    words[j] = temp;
                    tempTwo = countRepeat[i];
                    countRepeat[i] = countRepeat[j];
                    countRepeat[j] = tempTwo;
                }
            }
        }

        //сортировка по алфавиту
        for (int i = 0; i < words.Length - 1; i++)
        {
            for (int j = i + 1; j < words.Length; j++)
            {
                if ((words[i] .CompareTo(words[j]) > 0) && countRepeat[i] == countRepeat[j])
                {
                    temp = words[i];
                    words[i] = words[j];
                    words[j] = temp;
                    tempTwo = countRepeat[i];
                    countRepeat[i] = countRepeat[j];
                    countRepeat[j] = tempTwo;
                }
            }
        }
        Console.WriteLine("Результат:");
        //подсчет и вывод
        for (var i = 0; i < words.Length; i++)
        {
            //определяем выводили для этого слова к-во или нет
            bool needShowLog = true;
            for (var j = wordsSorted.Length - 1; j >= 0; j--)
            {
                if (words[i] == wordsSorted[j])
                {
                    needShowLog = false;
                    break;
                }
            }

            //если такого слова нет в массиве wordsFinished- тогда нужно его обработать
            if (needShowLog)
            {
                for (var j = wordsSorted.Length - 1; j >= 0; j--)
                {
                    if (wordsSorted[j] == null)
                    {
                        wordsSorted[j] = words[i];
                        break;
                    }
                }
                Console.WriteLine($"{words[i]}-{countRepeat[i]}");
            }
        }
    }
}