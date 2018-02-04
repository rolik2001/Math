using System;
using System.Collections.Generic;

namespace ConsoleApplication._2Task
{
    public class Start
    {
       public static int[,] FieldList = new int[10,10];
       public static Random random = new Random();
       public static int Itteration = 10;
        
        public static void  StartWork()
        {
            GenerateField();
            FieldList[0,0] = 1;
            Show();
            int i = 0;
            while (i<Itteration)
            {
                StartGame();
                Show();
                i++;
            }
        }

        private static void StartGame()
        {
            for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
            {
                int amount = NumberOfNeighbors(i, j);
                if(FieldList[i,j] == 1)
                    if (amount <= 1)
                        FieldList[i, j] = 0;
                    else if (amount >= 4)
                        FieldList[i, j] = 0;
                else if (FieldList[i,j] ==0)
                        if (amount == 3)
                            FieldList[i, j] = 1;
            }
        }

        private static int NumberOfNeighbors(int i, int j)
        {
            int all = 0;
            if((i-1) >= 0 && (j-1) >= 0) // 1 
                if (FieldList[i - 1, j - 1] == 1)
                    all = all + 1;
            if((i-1) >= 0) // 2
                if (FieldList[i - 1, j] == 1)
                    all = all + 1;       
            if((i-1) >= 0 && (j+1) <= 9) // 3 
                if (FieldList[i - 1, j + 1] == 1)
                    all = all + 1;
            if((j-1) >= 0) // 4
                if (FieldList[i, j - 1] == 1)
                    all = all + 1;
            if((j+1) <= 9) // 6 
                if (FieldList[i, j + 1] == 1)
                    all = all + 1;
            if((i+1) <= 9 && (j-1) >= 0) // 1 
                if (FieldList[i+1, j - 1] == 1)
                    all = all + 1;
            if((i+1) <= 9) // 2
                if (FieldList[i + 1, j] == 1)
                    all = all + 1;       
            if((i+1) <= 9 && (j+1) <= 9) // 3 
                if (FieldList[i + 1, j + 1] == 1)
                    all = all + 1;
           return all;           
         
        }

        private static void Show()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                    Console.Write(" "+FieldList[i,j]);
                Console.WriteLine();
            }
            Console.WriteLine("_____________________________________");
        }

        public static void GenerateField()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    FieldList[i,j] = random.Next(0,2);
        }
        
    }
}