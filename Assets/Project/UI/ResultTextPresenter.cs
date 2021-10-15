using JetBrains.Annotations;
using System;
using TMPro;

namespace Project.UI
{
    [UsedImplicitly]
    public sealed class ResultTextPresenter
    {
        public TMP_Text text;
        public GameHandler handler;
  
        public ResultTextPresenter(TMP_Text text, GameHandler handler)
        {
            if (text == null )
                throw new ArgumentNullException("result text not set");

            this.text = text;
            this.handler = handler;

            handler.resultText = this.text;
        }
    }
}