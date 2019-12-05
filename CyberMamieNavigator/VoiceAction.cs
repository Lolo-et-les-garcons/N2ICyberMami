using System;


namespace CyberMamieNavigator
{
    public class VoiceAction
    {
        public string label;
        public event Action task;

        public void Fire()
        {
            task?.Invoke();
        }
    }
}
