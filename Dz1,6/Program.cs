using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dz1_6
{
    class Program
    {
        int iter = 0;
        StreamWriter fileOtvet = new StreamWriter(@"Otvet6.txt");
        private int pod6(int i, string prefix, int k)
        {
            int newI= i + 1;
            //int iter = 0;
            if (i == 7)
            {
                if (k == 3)
                {
                    foreach (string p in alf)
                    {
                        if (!prefix.Contains(p)){
                            iter++;
                            fileOtvet.Write(prefix + p + "\n");
                        }
                    }
                }
                else
                {
                    foreach (string p in alf)
                    {
                        if (prefix.Contains(p))
                        {
                            iter++;
                            fileOtvet.Write(prefix + p + "\n");
                        }
                    }
                }
            }
            else if(i-k==4 && i>=4 && i <= 6)
            {
                foreach(string p in alf)
                {
                    if (!prefix.Contains(p))
                    {
                        int newPref = prefix + char;
                    }
                }
            }
        }
        static List<string> alf = new();
        static int alfSize;
        static void Main(string[] args)
        {
            alf.Add("a");
            alf.Add("b");
            alf.Add("c");
            alf.Add("d");
            alf.Add("e");
            alf.Add("f");
            alfSize = alf.Count;
            

        }
    }
}
