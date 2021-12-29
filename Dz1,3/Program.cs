using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dz1_3
{
    class Program
    {
        static int m1 = 5, m2 = 6, k = 2;
        static bool hasNextComObj(List<int> s, int m)
        {
            for (int i = s.Count - 1; i > 0; i--)
                if (s[i] != s[i - 1] + 1) return true;
            if (s[s.Count - 1] == m - 1) return false;
            return true;
        }

        static void NextComObj(List<int> s, int m)
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
        public static void NextPlacementsRepet(List<string> ReArr)//perestnovka
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
        public static bool hasNextPlacementsRepet(List<string> ReArr)
        {
            int index = ReArr.Count - 1;
            while (index > 0 && (alf.IndexOf(ReArr[index]) < alf.IndexOf(ReArr[index - 1])))
                index--;
            if (index == 0) return false;
            else return true;
        }
        public static List<string> alf = new List<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
