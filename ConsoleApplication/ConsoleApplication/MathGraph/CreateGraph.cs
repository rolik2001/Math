using System;
using System.Collections.Generic;

namespace ConsoleApplication.MathGraph
{
        public class CreateGraph
        {
            private static List<Node> _listNode = new List<Node>();
            private static Random _random = new Random();
        
            public static void Start()
            {
                var startNode = new Node(_random);
                _listNode.Add(startNode);
                for (var i = 0; i < 9; i++)
                {
                    CreateX();
                }
            }

            private static void CreateX()
            {
//            var x = new Node();
            }
        }
    }