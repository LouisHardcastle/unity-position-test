using JetBrains.Annotations;
using TMPro;
using Zenject;
using System;



namespace Project.UI
{
    [UsedImplicitly]
    public sealed class CountdownPresenter : ITickable
    {
        public int j;
        public TMP_Text text;
        public GameHandler textString;

        public CountdownPresenter(TMP_Text text, GameHandler textString)
        {
            if (text == null || textString == null)
                throw new ArgumentNullException("countdown text not set");

            this.text = text;
            this.textString = textString;
        }

   

        public void Tick()
        {
            text.text = textString.timeRemaining;
        }
    }
}