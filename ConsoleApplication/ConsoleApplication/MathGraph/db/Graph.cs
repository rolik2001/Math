using System.Collections.Generic;

namespace ConsoleApplication.MathGraph.db
{
    public class Graph
    {
        public string Id;
        public string Type;
        public List<string> Field;
        public List<string> PreviousId;

        public Graph(string id, string type, List<string> field, List<string> previousId)
        {
            Id = id;
            Type = type;
            Field = field;
            PreviousId = previousId;
        }
    }
}