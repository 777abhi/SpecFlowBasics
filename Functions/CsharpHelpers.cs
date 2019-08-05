using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowStart.Functions
{
    static class CsharpHelpers
    {

        static List<string> salmos;

        public static void simpleCollection()
        {
             salmos = new List<string>
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

        }
        internal static void simpleCollectionAdd(string newElement)
        {
             salmos = new List<string>
            {
                "Abhinav",
                "Pinky"
            };
            salmos.Add(newElement);
            
        }

        internal static void simpleCollectionView(string newElement)
        {
            int testResult = 0;
            
            foreach (var doc in salmos)
            {
                Console.WriteLine(doc);
                if (doc.Equals(newElement)){
                    testResult = 1;
                    break;
                }
                   
            }

            if (testResult == 0) {
                throw new Exception("Test Failed, new element not found : "+newElement);
            }

        }
    }
    }
