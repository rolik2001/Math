using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using ConsoleApplication.MathGraph.db;
using Firebase.Database;
using Firebase.Database.Query;


namespace ConsoleApplication.MathGraph
{
        public class CreateGraph
        {
            private static List<Node> _listNode = new List<Node>();
            private static Random _random = new Random();
            private static Node MainNode = new Node("0", "X",new List<string>{"-","-","-","-","-","-","-","-","-"});
            public static ChildQuery Firebase = new FirebaseClient("https://makerspacetest-cc9df.firebaseio.com/").Child("Graph");


            public static void Start()
            {
              _listNode.Add(MainNode);
              CreateX(MainNode);
//                while (_listNode.Count > 0)
//                {
//                    CreateX(_listNode.First());
//                    _listNode.RemoveAt(0);
//                }
            }

            private static void CreateX(Node parentNode)
            {
                List<string> field = new List<string>(parentNode.Field);
                List<int> emptyPosition = EmptyPosition(parentNode.Field);
                for (int i = 0; i < emptyPosition.Count; i++)
                {
                    var fieldTemp = new List<string>(field);
                    fieldTemp[emptyPosition[i]] = parentNode.Type;
                    var node = new Node(_random,parentNode.Type,fieldTemp);
                    _listNode.Add(node);
                    parentNode.PreviousId.Add(node.Id);
                    var graph = new Graph(node.Id, node.Type, node.Field, node.PreviousId);
                    var dino = Firebase.PostAsync(graph);
                    CreateX(node);
                }
            }

            private static List<int> EmptyPosition(List<string> field)
            {
                List<int> empty  = new List<int>();
                for (int i = 0; i < field.Count; i++)
                {
                    if(field[i] == "-")
                        empty.Add(i);
                }

                return empty;
            }
        }
    }