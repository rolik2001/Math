using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ConsoleApplication.MathGraph
{
    public class Node
    {
        public string Id;
        public string Type;
        public List<string> Field;
        public List<string> PreviousId;

        public Node(string id, string type, List<string> field)
        {
            Id = id;
            Type = type;
            Field = field;
            PreviousId = new List<string>();
        }


        public Node(Random random,string type, List<string> field)
        {
            Id = GenerateId(random);
            Type = SetType(type);
            Field = field;
            PreviousId = new List<string>();
        }

        public string GenerateId(Random random)
        {
            Random r = random;
            int len = random.Next(2, 10);
            string[] consonants =
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "j", "i", "k", "m", "l", "n", "p", "q", "r", "s", "sh", "zh",
                "t", "u", "v",
                "w", "x", "y", "z"
            };
            string[] vowels = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2;
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }
            return Name;
        }

        public string SetType(string type)
        {
            string res = String.Empty;
            if (type == "X")
                res = "O";
            else if (type == "O")
                res = "X";
            
            return res;
        }
    }
}