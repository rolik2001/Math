using System;

namespace ConsoleApplication.MathGraph
{
    public class Node
        {
            public string Id;
            public string Type;
            public int Position;
        
            public Node(string id)
            {
                Id = id;
            }

            public Node(Random random)
            {
                Random r = random;
                int len = random.Next(2, 10);
                string[] consonants =
                {
                    "a","b", "c", "d", "e", "f", "g", "h", "j","i", "k", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t","u", "v",
                    "w", "x","y","z"
                };
                string[] vowels = {"1","2","3","4","5","6","7","8","9"};
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
            
                Console.WriteLine(Name);   
                Id = Name ;
            }
        }
    }


