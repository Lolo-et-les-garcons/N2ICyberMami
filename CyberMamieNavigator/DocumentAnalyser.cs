using System;
using System.Collections.Generic;

using Gecko;

namespace CyberMamieNavigator
{
    public class DocumentAnalyser
    {
        public DocumentAnalyser()
        {

        }


        public List<string> Analyse(GeckoDocument document)
        {
            List<string> testVocal = new List<string>;

            foreach(GeckoNode node in document.Body.ChildNodes)
            {
                if (node.NodeType == NodeType.Element)
                {
                    Console.WriteLine(node.NodeName + " " + node.TextContent);
                    testVocal.Add(node.TextContent);
                }
                
            }
            return testVocal;
        }

        public bool BaliseValable(GeckoNode node)
        {

            if (NodeType.Element == node.NodeType)
            {
                switch (node.NodeName)
                {
                    case "BUTTON":
                    case "A":
                        return true;
                    default: return false;
                }
            }
            return false;
        }
    }
}
