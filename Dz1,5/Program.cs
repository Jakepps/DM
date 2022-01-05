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
            alf.Add("a");
            alf.Add("b");
            alf.Add("c");
            alf.Add("d");
            alf.Add("e");
            alf.Add("f");

            List<string> placements1 = new List<string>();
            List<string> placements2 = new List<string>();
            k1 = 3;
            for (int i = 0; i < m1 - k1; i++)
                placements1.Add("");
            for (int i = 0; i < m2 - k1; i++)
                placements2.Add("");


            List<int> sochet1 = new List<int>();
            List<int> sochet2 = new List<int>();
            for (int i = 0; i < k1; i++)
            {
                sochet1.Add(i);
                sochet2.Add(i);
            }
            sochet1[k1 - 1] = k1 - 2;
            sochet2[k1 - 1] = k1 - 2;
            for (int i = 0; i < m1; i++)
                word1.Add("");
            for (int i = 0; i < m2; i++)
                word2.Add("");

            file1.WriteLine("Все слова длины 4, в которых больше 2-x букв а:");
            file2.WriteLine("Все слова длины 7, в которых больше 2-x букв а:");

            while (k1 <= 7)
            {
                if (k1 <= 4)
                {
                    for (int i = 0; i < k1; i++)
                        sochet1[i] = i;
                    sochet1[k1 - 1] = k1 - 2;
                    while (hasNextComObj(sochet1, m1))
                    {
                        NextComObj(sochet1, m1, k1);
                        for (int i = 0; i < placements1.Count; i++)
                            placements1[i] = "b";

                        for (int i = 0; i < m1; i++)
                            word1[i] = "";
                        Connect(sochet1, word1, 0, m1);
                        if (placements1.Count != 0)
                            ConnectArr(placements1, word1, m1);
                        Print(word1, file1, m1);
                        while (hasNextPlacementsRepet(placements1, m1, k1))
                        {
                            NextPlacementsRepet(placements1, m1, k1);
                            for (int i = 0; i < m1; i++)
                                word1[i] = "";
                            Connect(sochet1, word1, 0, m1);
                            if (placements1.Count != 0)
                                ConnectArr(placements1, word1, m1);
                            Print(word1, file1, m1);
                        }
                    }
                }

                for (int i = 0; i < k1; i++)
                    sochet2[i] = i;
                sochet2[k1 - 1] = k1 - 2;
                while (hasNextComObj(sochet2, m2))
                {
                    NextComObj(sochet2, m2, k1);
                    for (int i = 0; i < placements2.Count; i++)
                        placements2[i] = "b";

                    for (int i = 0; i < m2; i++)
                        word2[i] = "";
                    Connect(sochet2, word2, 0, m2);
                    if (placements2.Count != 0)
                        ConnectArr(placements2, word2, m2);
                    Print(word2, file2, m2);
                    while (hasNextPlacementsRepet(placements2, m2, k1))
                    {
                        NextPlacementsRepet(placements2, m2, k1);
                        for (int i = 0; i < m2; i++)
                            word2[i] = "";
                        Connect(sochet2, word2, 0, m2);
                        if (placements2.Count != 0)
                            ConnectArr(placements2, word2, m2);
                        Print(word2, file2, m2);
                    }
                }
                sochet1.Add(0);
                sochet2.Add(0);
                if (placements1.Count != 0)
                    placements1.RemoveAt(placements1.Count - 1);
                if (placements2.Count != 0)
                    placements2.RemoveAt(placements2.Count - 1);
                k1++;
            }
            file1.Close();
            file2.Close();
        }
    }
}
