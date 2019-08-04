using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowStart.Functions
{
    static class CsharpHelpers
    {
        public static void simpleCollection() {
            var salmos = new List<string>
            {
                "Abhinav",
                "Pinky",
                "Abhinav",
                "Pinky",
                "Abhinav",
                "Pinky",
                "Abhinav",
            };
            salmos.Add(DateTime.Now.ToString());

            foreach (var doc in salmos) {
                Console.WriteLine(doc);
            }
        }
    }
}
