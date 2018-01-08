using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApplication.MathGraph.db;
using Firebase.Database;
using Firebase.Database.Query;


namespace ConsoleApplication.MathGraph
{
    public class CreateGraph
    {
        private static List<Node> _listNode = new List<Node>();
        private static Random _random = new Random();

        private static Node MainNode =
            new Node("0", "X", new List<string> {"-", "-", "-", "-", "-", "-", "-", "-", "-"});

        public static ChildQuery Firebase =
            new FirebaseClient("https://test-a011b.firebaseio.com/").Child("Graphs");

        private static int[][] combination =
        {
            new int[] {1, 2, 3}, new int[] {4, 5, 6}, new int[] {7, 8, 9}, new int[] {1, 4, 7}, new int[] {2, 5, 8},
            new int[] {3, 6, 9}, new int[] {1, 5, 9}, new int[] {7, 5, 3}
        };

        public static void Start()
        {
            _listNode.Add(MainNode);
            CreateX(MainNode);
//            test();
//            Console.WriteLine("Key for the new dinosaur: {dino.Key}");  
        }

        private static void CreateX(Node parentNode)
        {
            List<string> field = new List<string>(parentNode.Field);
            List<int> emptyPosition = EmptyPosition(parentNode.Field);
            for (int i = 0; i < emptyPosition.Count; i++)
            {
                var fieldTemp = new List<string>(field);
                fieldTemp[emptyPosition[i]] = parentNode.Type;
                var node = new Node(_random, parentNode.Type, fieldTemp);
                _listNode.Add(node);
                parentNode.PreviousId.Add(node.Id);
                var graph = new Graph(node.Id, node.Type, node.Field, node.PreviousId);
                var dino = Firebase.PostAsync(graph);
                if (!IsWin(node.Field, node.Type))
                    CreateX(node);
            }
        }

        private static List<int> EmptyPosition(List<string> field)
        {
            List<int> empty = new List<int>();
            for (int i = 0; i < field.Count; i++)
            {
                if (field[i] == "-")
                    empty.Add(i);
            }

            return empty;
        }

        private static bool IsWin(List<string> field, string type)
        {
            string win = type + type + type;
            bool res = false;
            for (int i = 0; i < combination.Length; i++)
            {
                if (field[combination[i][0]] + field[combination[i][1]] + field[combination[i][0]] == type)
                    res = true;
            }

            return res;
        }

        private static void test()
        {
            try
            {
                var firebase = new FirebaseClient("https://makerspacetest-cc9df.firebaseio.com/");
                var dino =  firebase
                    .Child("Graph")
                    .PostAsync(new Graph());
            
                Console.WriteLine("Key for the new dinosaur: " + dino.Result.Key);  

//            await firebase.Child("Graph").Child("t-rex").PutAsync("teset");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            

        }
    }
}