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
                if (s[i] != alf[alf.Count - 1]) return true;
            return false;
        }
        static void NextPlacementsRepetitions(List<string> s)
        {
            int index = s.Count - 1;
            while (s[index] == alf[alf.Count - 1] && index > 0)
            {
                s[index] = alf[1];
                index--;
            }
            int ind_in_alf = alf.IndexOf(s[index]);
            s[index] = alf[ind_in_alf + 1];


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
            StreamWriter fileArrangeRepeat = new StreamWriter(@"PlacementsRepetitions .txt");//для размещений с повторениями по к элементов
            //построение всех размещений с повторениями по к элементов
            List<string> arrange = new List<string>();
            for (int i = 0; i < alfSize; i++)
            {
                arrange.Add("");
                for (int j = 0; j < arrange.Count; j++)
                    arrange[j] = alf[0];
                Print(arrange, fileArrangeRepeat);
                while (hasPlacementsRepetitions(arrange))
                {
                    NextPlacementsRepetitions(arrange);
                    Print(arrange, fileArrangeRepeat);
                }

            }
            fileArrangeRepeat.Close();

        }
    }
}
