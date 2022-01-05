using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dz1_4
{
    class Program
    {
        static int m1 = 7, m2 = 9, k1 = 2, k2 = 3;
        static bool hasNextComObj(List<int> s, int m)//m-размерность слова
        {
            for (int i = s.Count - 1; i > 0; i--)
                if (s[i] != s[i - 1] + 1) return true;
            if (s[s.Count - 1] == m - 1) return false;
            return true;
        }

        static void NextSochet(List<int> s, int m, int k) //к-размерность сочетания
        {
            if (s[k - 1] != (m - 1)) s[k - 1] += 1;
            else
            {
                int index = k - 1;
                while (s[index] == s[index - 1] + 1 && index > 0)
                    index--;
                s[index - 1]++;
                for (int i = index + 1; i < k; i++)
                    s[i] = s[i - 1] + 1;
            }

        }
        public static void NextPermutation(List<string> ReArr)//perestnovka
        {
            int index = ReArr.Count - 2;
            while (alf.IndexOf(ReArr[index]) > alf.IndexOf(ReArr[index + 1]))
                index--;
            int s = index + 1;
            while (s < ReArr.Count - 1 && (alf.IndexOf(ReArr[s + 1]) > alf.IndexOf(ReArr[index])))
                s++;
            string t = ReArr[index];//поменяли местами полученный и наименьший справа
            ReArr[index] = ReArr[s];
            ReArr[s] = t;

            for (int i = 0; i < (ReArr.Count - index - 1) / 2; i++)
            {
                t = ReArr[ReArr.Count - 1 - i];
                ReArr[ReArr.Count - 1 - i] = ReArr[index + i + 1];
                ReArr[index + i + 1] = t;
            }

        }
        public static bool hasNextPermutation(List<string> ReArr)
        {
            int index = ReArr.Count - 1;
            while (index > 0 && (alf.IndexOf(ReArr[index]) < alf.IndexOf(ReArr[index - 1])))
                index--;
            if (index == 0) return false;
            else return true;
        }

        public static void NextPlacements(List<string> arr, List<string> ReArr, int L)// L - разница между длиной перестановки и длиной и размещения
        {

            for (int i = 0; i < arr.Count; i++)
                arr[i] = ReArr[i];
            for (int i = 0; i < L; i++)
                if (hasNextPermutation(ReArr))
                    NextPermutation(ReArr);
        }
        public static void Connect(List<int> sochet, List<string> word, int j, int m)//объединение слова
        {
            int Index = 0;
            for (int i = 0; i < m; i++)
                if (word[i] == "")
                {
                    if (sochet.IndexOf(Index) != -1)
                        word[i] = alf[j];
                    Index++;
                }
        }

        public static void ConnectArr(List<string> arrange, List<string> word, int m)
        {
            int indexAr = 0;
            for (int i = 0; i < m; i++)
                if (word[i] == "")
                {
                    word[i] = arrange[indexAr];
                    indexAr++;
                }
        }

        public static void Print(List<string> slovo, StreamWriter file, int m)
        {
            string s = "";
            for (int i = 0; i < m; i++)
                s += slovo[i];
            file.WriteLine(s);
        }

        public static List<string> alf = new List<string>();
        public static StreamWriter file1 = new StreamWriter(@"Dz4_1.txt");//для размещений с повторениями
        public static StreamWriter file2 = new StreamWriter(@"Dz4_2.txt");

            
        static void Main(string[] args)
        {


        }
    }
}
