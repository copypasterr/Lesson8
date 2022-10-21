using System;

namespace Lesson8
{
    internal class Program
    {

        /// <summary>
        /// Sorting the string in alphabetical order
        /// </summary>
        /// <param name="alfStr"></param>
        /// <returns>Sorted string</returns>
        static string Sort(string alfStr)
        {
            char[] wordInChar = alfStr.ToCharArray();
            int[] numArray = new int[alfStr.Length];

            for (int i = 0; i < alfStr.Length; i++)
                numArray[i] = (int)char.ToLower(wordInChar[i]);

            numArray = ArraySort(numArray);

            for (int i = 0; i < alfStr.Length; i++)
                wordInChar[i]= (char)numArray[i];

            string resultStr = new string(wordInChar);

            return resultStr;
        }

        /// <summary>
        /// Сompares String a and b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true, false</returns>
        static bool Compare(string a, string b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) return false;
            }
            return true;
        }

        /// <summary>
        /// Analyze the quantity of letters, digits, Upreg letters, Lowreg letters and symbols
        /// </summary>
        /// <param name="Word"></param>
        static void Analyze(string Word)
        {
            char[] wordInChar = new char[Word.Length];
            wordInChar = Word.ToCharArray();

            int Letters = 0;
            int Digits = 0;
            int UpReg = 0;
            int LowReg = 0;
            int Symbol = 0;

            for (int i = 0; i < Word.Length; i++)
            {
                if (char.IsLetter(wordInChar[i])) Letters++;
                if (char.IsDigit(wordInChar[i])) Digits++;
                if (char.IsUpper(wordInChar[i])) UpReg++;
                if (char.IsLower(wordInChar[i])) LowReg++;
                if (IsSymbol(wordInChar[i])) Symbol++;
            }

            Console.WriteLine($"Letters: {Letters}, \nDigits: {Digits}, \nUp register: {UpReg}, \nLow register: {LowReg}, \nSymbols: {Symbol}");
        }

        /// <summary>
        /// Returns dublicated characters
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static char[] Dublicate(string str)
        {
            int nums = 0;

            for (int i = 0; i < str.Length; i++)
                for (int j = i + 1; j < str.Length; j++)
                    if ((int)char.ToLower(str[i]) == (int)char.ToLower(str[j]))
                        nums++;

            char[] chr = new char[nums];

            nums = 0;

            for (int i = 0; i < str.Length; i++)
                for (int j = i + 1; j < str.Length; j++)
                    if ((int)char.ToLower(str[i]) == (int)char.ToLower(str[j]))
                    {
                        chr[nums] = str[i];
                        nums++;
                    }

            return chr;
        }

        /// <summary>
        /// Сhecks if the character is symbol (additional)
        /// </summary>
        /// <param name="a"></param>
        /// <returns>true, false</returns>
        public static bool IsSymbol(char a)
        {
            if ((int)a >= 33 && (int)a <= 47 || (int)a >= 58 && (int)a <= 64) return true;

            else return false;

        }

        /// <summary>
        /// Sorts values in ascending order (additional)
        /// </summary>
        /// <param name="array"></param>
        /// <returns>Sorted int array</returns>
        static int[] ArraySort(int[] array)
        {
            int buffer;

            for (int externalCycle = 0; externalCycle < array.Length; externalCycle++)
            {
                int minIndex = externalCycle;

                for (int internalCycle = externalCycle + 1; internalCycle < array.Length; internalCycle++)
                {
                    if (array[internalCycle] < array[minIndex])
                        minIndex = internalCycle;
                }

                buffer = array[minIndex];
                array[minIndex] = array[externalCycle];
                array[externalCycle] = buffer;
            }

            return array;
        }

        static void Main(string[] args)
        {
            string a = "Hello";
            string b = "Hello and hi";

            Compare(a, b);

            Console.WriteLine(Sort(b));

            Analyze(a);

            Console.WriteLine(Dublicate(b));

        }

    }
}
