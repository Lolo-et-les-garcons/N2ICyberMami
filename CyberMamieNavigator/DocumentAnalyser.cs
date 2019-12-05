using System;
using System.Collections.Generic;

using Gecko;
using Gecko.DOM;

namespace CyberMamieNavigator
{
    public class DocumentAnalyser
    {
        private List<VoiceAction> actions;

        public DocumentAnalyser()
        {
            actions = new List<VoiceAction>();
        }

        public void Analyse(GeckoDocument document)
        {
            actions.Clear();

            AddVoiceActions(document, "button");
            AddVoiceActions(document, "a");
        }

        public List<VoiceAction> GetVoiceActions()
        {
            return actions;
        }

        public void AddVoiceActions(GeckoDocument document, string tagName)
        {
            foreach (GeckoElement element in document.GetElementsByTagName(tagName))
            {
                VoiceAction action = new VoiceAction();
                action.label = element.TextContent.Trim();

                if(tagName == "button")
                {
                    action.task += () =>
                    {
                        GeckoButtonElement button = new GeckoButtonElement(element.DomObject);
                        button.Click();
                    };
                }

                if(tagName == "a")
                {
                    action.task += () =>
                    {
                        GeckoAnchorElement anchor = new GeckoAnchorElement(element.DomObject);
                        anchor.Click();
                    };
                }

                actions.Add(action);
            }
        }

        public string[] GetLabels()
        {
            List<string> labels = new List<string>();
            foreach(VoiceAction va in actions)
            {
                labels.Add(va.label);
            }
            return labels.ToArray();
        }

        public VoiceAction FindByName(string s)
        {
            foreach(VoiceAction va in actions)
            {
                if (s == va.label) return va;
            }
            return null;
        }


    }
}
