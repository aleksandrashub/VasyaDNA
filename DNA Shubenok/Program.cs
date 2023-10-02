using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Diagnostics.SymbolStore;
using System.IO;

class Program
{
    static void Main()
    {

        Console.WriteLine("Введите ДНК Васи: ");

        string vasyaDNA = Console.ReadLine(); // считываем ДНК Васи

        Console.WriteLine("Введите ДНК существа: ");
        int maxMatch = 0; // переменная для хранения степени родства
        int startPosVasya = 0; // переменная для хранения начальной позиции подстроки в ДНК Васи
        int startPosCreature = 0;// переменная для хранения начальной позиции подстроки в ДНК существа
        string creatureDNA = Console.ReadLine(); // считываем ДНК существа

        while (creatureDNA.Length > 10 || vasyaDNA.Length > 1300)
        {
            if (creatureDNA.Length > 10)
            {
                Console.WriteLine("ДНК существа содержит более чем 1300 символов, введите заново");
                creatureDNA = Console.ReadLine();
            }
            else 
            {

                Console.WriteLine("ДНК Васи содержит более чем 1300 символов, введите заново");
                vasyaDNA = Console.ReadLine();

            }

        }
       
            // перебираем все подстроки ДНК Васи
            for (int i = 0; i < vasyaDNA.Length; i++)
            {
            for (int j = i + 1; j <= vasyaDNA.Length; j++)
            {
                string subVasya = vasyaDNA.Substring(i, j - i); // подстрока из ДНК Васи

                if (RightAlphabet(subVasya) == true && RightAlphabet(creatureDNA) == true) //проверяем нет ли недопустимых символов
                {
                    if (IsAnagram(subVasya, creatureDNA) == true) // проверяем, являются ли подстроки анаграммами
                    {
                        int matchLength = subVasya.Length; // длина подстроки в анаграмме


                        startPosVasya = i + 1;
                        startPosCreature = 1;
                        Console.WriteLine("Cтепень родства: " + matchLength);
                        Console.WriteLine("Начальная позиция подстроки первой ДНК: " + startPosVasya);
                        Console.WriteLine("Начальная позиция подстроки второй ДНК: " + startPosCreature);
                        
                    }


                }
                else
                {
                    Console.WriteLine("Неверный символ был найден");
                    Console.ReadLine();
                }


                       
                }
            }

            Console.ReadLine();//чтобы консоль не закрывалась, как только выведет ответ



        
    }


    static bool RightAlphabet(string s)//метод, проверяющий нет ли в строке лишних символов
    {
        for (int i = 0; i < s.Length; i++)
        {
            
            switch (s[i])
            {
               
                case 'A':

                    break;

                case 'C':

                    break;

                case 'G':

                    break;

                case 'T':

                    break;

                default:
                   
                    return false;
                    break;
                    
                    
            }

       
            


        }
        return true;
    }

    // функция для проверки, являются ли две строки анаграммами
    static bool IsAnagram(string s1, string s2)
    {
        if (s1.Length != s2.Length) // если длины строк не совпадают, то они не могут быть анаграммами
            return false;

        if (s1 == s2) //если порядок совпадает, то строки не могут быть анаграммами
            return false;

       
            int[] count = new int[4]; // создаем массив для подсчета частоты каждой буквы
            for (int i = 0; i < s1.Length; i++)
            {
                switch (s1[i])
                {
                   
                    case 'A':           // увеличиваем счетчик для символа 'A' в первой строке

                        count[0]++;
                        break;
                    case 'C':           // увеличиваем счетчик для символа 'C' в первой строке

                        count[1]++;
                        break;
                    case 'G':           // увеличиваем счетчик для символа 'G' в первой строке

                        count[2]++;
                        break;
                    case 'T':           // увеличиваем счетчик для символа 'T' в первой строке

                        count[3]++;
                        break;

                }

                switch (s2[i])
                {
                    case 'A':           // уменьшаем счетчик для символа 'A' в 2 строке

                        count[0]--;
                        break;
                    case 'C':           // уменьшаем счетчик для символа 'C' в 2 строке

                    count[1]--;
                        break;
                    case 'G':           // уменьшаем счетчик для символа 'G' в 2 строке

                    count[2]--;
                        break;
                    case 'T':           // уменьшаем счетчик для символа 'T' в 2 строке

                    count[3]--;
                        break;


                }

            }

            for (int i = 0; i < 4; i++)
            {
                if (count[i] != 0) // если хотя бы один счетчик не равен нулю, то строки не являются анаграммами
                    return false;
            }


      
       

        return true; // если все проверки прошли успешно, то строки являются анаграммами
    }
}