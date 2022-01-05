using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dz1_5
{
    class Program
    {
        public static int m1 = 4, m2 = 7;
        public static int k1;
        static bool hasNextComObj(List<int> s, int m)
        {
            for (int i = s.Count - 1; i > 0; i--)
                if (s[i] != s[i - 1] + 1) return true;
            if (s[s.Count - 1] == m - 1) return false;
            return true;
        }

        static void NextComObj(List<int> s, int m, int k)
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
        static bool hasNextPlacementsRepet(List<string> s, int m, int k)
        {
            for (int i = m - k - 1; i >= 0; i--)
                if (s[i] != alf[alf.Count - 1]) return true;
            return false;
        }
        static void NextPlacementsRepet(List<string> s, int m, int k)
        {
            int index = m - k - 1;
            while (s[index] == alf[alf.Count - 1] && index > 0)
            {
                s[index] = alf[1];
                index--;
            }
            int ind_in_alf = alf.IndexOf(s[index]);
            s[index] = alf[ind_in_alf + 1];

        }

        public static void Connect(List<int> sochet, List<string> word, int j, int m)
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
        public static List<string> word1 = new List<string>();
        public static List<string> word2 = new List<string>();
        public static StreamWriter file1 = new StreamWriter(@"Dz5_1.txt");//для размещений с повторениями
        public static StreamWriter file2 = new StreamWriter(@"Dz5_2.txt");
        static void Main(string[] args)
        {


        }
    }
}
