using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dz1_1
{
    class Program
    {
        static bool hasNextComObj(List<int> s)
        {
            for (int i = s.Count - 1; i > 0; i--)
                if (s[i] != s[i - 1] + 1) return true;
            if (s[^1] == alfSize - 1) return false; //s.Count - 1
            return true;
        }

        static void NextComObj(List<int> s)
        {
            int k = s.Count;
            if (s[k - 1] != (alfSize - 1)) s[k - 1] += 1;
            else
            {
                int index = k - 1;
                while (s[index] == s[index - 1] + 1 && index > 0)
                    index--;
                s[index - 1]++;

                for (int i = index; i < k; i++)
                    s[i] = s[i - 1] + 1;
            }

        }
        static bool hasPlacementsRepetitions(List<string> s)
        {
            for (int i = s.Count - 1; i >= 0; i--)
                if (s[i] != alf[^1]) return true;
            return false;
        }
        static void NextPlacementsRepetitions(List<string> s)
        {
            int index = s.Count - 1;
            while (s[index] == alf[^1] && index > 0)
            {
                s[index] = alf[1];
                index--;
            }
            int ind_in_alf = alf.IndexOf(s[index]);
            s[index] = alf[ind_in_alf + 1];


        }

        public static bool hasNextPermutation(List<string> ReArr)
        {
            int index = ReArr.Count - 1;
            while (index > 0 && (alf.IndexOf(ReArr[index]) < alf.IndexOf(ReArr[index - 1])))
                index--;
            if (index == 0) return false;
            else return true;
        }
        public static void NextPermutation(List<string> ReArr) //перестановки
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

        public static void NextPlacements(List<string> arr, List<string> ReArr, int L)
        {
            for (int i = 0; i < arr.Count; i++)
                arr[i] = ReArr[i];
            for (int i = 0; i < L; i++)
                if (hasNextPermutation(ReArr))
                    NextPermutation(ReArr);
        }
        public static int Factorial(int x)
        {
            if (x == 1 || x == 0) return 1;
            else return x * Factorial(x - 1);
        }

        public static void Print(List<string> slovo, StreamWriter file)
        {
            string s = "";
            for (int i = 0; i < slovo.Count; i++)
                s += slovo[i];
            file.WriteLine(s);
            // Console.WriteLine(s);

        }



        static List<string> alf = new List<string>();
        static int alfSize;

        static void Main(string[] args)
        {
            alf.Add("a");
            alf.Add("b");
            alf.Add("c");
            alf.Add("d");
            alf.Add("e");
            alf.Add("f");
            alf.Add("g");
            alfSize = alf.Count;
            StreamWriter filePlacementsRepetitions = new StreamWriter(@"PlacementsRepetitions .txt");//для размещений с повторениями по к элементов
            StreamWriter filePermutation = new StreamWriter(@"Permutation.txt");//для перестановок
            StreamWriter filePlacements = new StreamWriter(@"Placements.txt");//для размещений по к элементов
            StreamWriter fileSubset = new StreamWriter(@"Subset.txt");//для подмножеств
            //построение всех размещений с повторениями по к элементов
            List<string> arrange = new List<string>();
            for (int i = 0; i < alfSize; i++)
            {
                arrange.Add("");
                for (int j = 0; j < arrange.Count; j++)
                    arrange[j] = alf[0];
                Print(arrange, filePlacementsRepetitions);
                while (hasPlacementsRepetitions(arrange))
                {
                    NextPlacementsRepetitions(arrange);
                    Print(arrange, filePlacementsRepetitions);
                }

            }
            filePlacementsRepetitions.Close();

            //построение всех перестановок
            List<string> perest = new List<string>();
            for (int i = 0; i < alfSize; i++)
                perest.Add(alf[i]);
            Print(perest, filePermutation);
            while (hasNextPermutation(perest))
            {
                NextPermutation(perest);
                Print(perest, filePermutation);
            }
            filePermutation.Close();

            //построение всех размещений по к элементов
            arrange = new List<string>();
            for (int j = 0; j < alfSize; j++)
            {
                arrange.Add("");
                perest = new List<string>();
                for (int i = 0; i < alfSize; i++)
                    perest.Add(alf[i]);
                NextPlacements(arrange, perest, Factorial(alfSize - arrange.Count));
                Print(arrange, filePlacements);
                while (hasNextPermutation(perest))
                {
                    NextPlacements(arrange, perest, Factorial(alfSize - arrange.Count));
                    Print(arrange, filePlacements);
                }

            }
            filePlacements.Close();
        }
    }
}
