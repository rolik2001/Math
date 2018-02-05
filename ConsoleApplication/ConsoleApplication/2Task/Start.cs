using System;

namespace ConsoleApplication._2Task
{
    public class Start
    {
       public static int SizeOfField = 10;
       public static int[,] Field = 
       {
           {1,0,1,1,0,1,1,0,0,1},
           {1,1,1,0,0,0,0,1,1,0},
           {1,1,0,1,1,1,0,1,1,1},
           {0,1,1,1,1,0,0,0,0,0},
           {1,0,0,0,0,1,1,0,1,1},
           {1,0,0,0,0,0,0,0,0,1},
           {1,1,1,0,0,0,1,1,0,0},
           {1,0,0,0,0,1,1,0,0,0},
           {1,1,0,0,1,0,1,0,0,0},
           {1,0,0,1,0,0,1,0,1,0}
       };
       public static Random random = new Random();
       public static int Itteration = 10;
        
        public static void  StartWork()
        {
            
//            GenerateField();
            WriteInConsole();
            int i = 0;
            while (i<Itteration)
            {
                Game();
                WriteInConsole();
                i++;
            }
                
        }

        private static void Game()
        {
            for (int index1 = 0; index1 < SizeOfField; index1++)
            for (int index2 = 0; index2 < SizeOfField; index2++)
            {
                int amount = NumberOfNeighbors(index1, index2);
                if(Field[index1,index2] == 1)
                    if (amount <= 1)
                        Field[index1, index2] = 0;
                    else if (amount >= 4)
                        Field[index1, index2] = 0;
                else if (Field[index1,index2] ==0)
                        if (amount == 3)
                            Field[index1, index2] = 1;
            }
        }

        private static int NumberOfNeighbors(int index1, int index2)
        {
            int amountOfNeighbors = 0;
            if ((index1 - 1) >= 0 && (index2 - 1) >= 0) // 1 
                amountOfNeighbors = Check(index1-1,index2-1,amountOfNeighbors);
            if((index1-1) >= 0) // 2
                amountOfNeighbors = Check(index1-1,index2,amountOfNeighbors);
            if((index1-1) >= 0 && (index2+1) <= 9) // 3 
                amountOfNeighbors = Check(index1-1,index2+1,amountOfNeighbors);
            if((index2-1) >= 0) // 4
                amountOfNeighbors = Check(index1,index2-1,amountOfNeighbors);
            if((index2+1) <= 9) // 6 
                amountOfNeighbors = Check(index1,index2+1,amountOfNeighbors);
            if((index1+1) <= 9 && (index2-1) >= 0) // 7
                amountOfNeighbors = Check(index1+1,index2-1,amountOfNeighbors);
            if((index1+1) <= 9) // 8
                amountOfNeighbors = Check(index1+1,index2,amountOfNeighbors);       
            if((index1+1) <= 9 && (index2+1) <= 9) // 9 
                amountOfNeighbors = Check(index1+1,index2+1,amountOfNeighbors);
           return amountOfNeighbors;           
         
        }

        private static int Check(int i, int j, int all)
        {
            if (Field[i, j] == 1)
                all = all + 1;       
            return all;
        }


        private static void WriteInConsole()
        {
            for (int i = 0; i < SizeOfField; i++)
            {
                for (int j = 0; j < SizeOfField; j++)
                    Console.Write(" "+Field[i,j]);
                Console.WriteLine();
            }
            Console.WriteLine("_____________________________________");
        }

        public static void GenerateField()
        {
            Field = new int[SizeOfField, SizeOfField];
            for (int i = 0; i < SizeOfField; i++)
                for (int j = 0; j < SizeOfField; j++)
                    Field[i,j] = random.Next(0,2);
        }
        
    }
}