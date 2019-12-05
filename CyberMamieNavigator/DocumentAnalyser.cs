using System;
using System.Collections.Generic;

using Gecko;
using Gecko.DOM;

namespace CyberMamieNavigator
{

    public class VoiceAction
    {
        public string type;
        public event Action action;

        public void Fire()
        {
            action?.Invoke();
        }
    }

    public class DocumentAnalyser
    {
        public DocumentAnalyser()
        {

        }


        public List<VoiceAction> Analyse(GeckoDocument document)
        {
            List<VoiceAction> testVocal = new List<VoiceAction>();

            foreach(GeckoNode node in document.Body.ChildNodes)
            {
                if (BaliseValable(node))
                {
                    /*Console.WriteLine(node.NodeName + " " + node.TextContent);
                    testVocal.Add(node.TextContent);*/

                    VoiceAction action = new VoiceAction();
                    action.type = node.TextContent;

                    if (node.NodeName == "BUTTON")
                    {
                        action.action += () =>
                        {
                            /*GeckoButtonElement button = new GeckoButtonElement(node.GetEventTarget().CastToGeckoElement());

                            Console.WriteLine("event : " + button.TextContent);
                            button.Click();*/


                        };
                    }

                    testVocal.Add(action);
                }
                
            }

            foreach(VoiceAction s in testVocal)
            {;
                Console.WriteLine(s.type);

                s.Fire();
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
                    case "LABEL":
                        return true;
                    default: return false;
                }
            }
            return false;
        }
    }
}
