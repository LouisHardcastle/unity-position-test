using JetBrains.Annotations;
using TMPro;
using System;
using Zenject;
using UnityEngine.EventSystems;

namespace Project.UI
{
    [UsedImplicitly]
    public sealed class PlayerInputPresenter : IInitializable, ITickable
    {

        private HTMLReq Requester;
        public TMP_InputField field;
        private PlayerInputOptions options;
        private GameHandler timer;

        public PlayerInputPresenter(TMP_InputField field, PlayerInputOptions options, GameHandler timer)
        {
            if(field == null ||  options == null || timer == null)
                throw new ArgumentNullException("playerInput not set");
            this.field = field;
            this.options = options;
            this.timer = timer;
          
        }

        public void Initialize()
        {
            field.onEndEdit.AddListener(delegate { OnValueEnter(); });
            field.onSelect.AddListener(delegate { OnClick(); });
        }

        public void OnClick()
        {
            field.text = "";
        }
        public void OnValueEnter()
        {
            if (options.CheckInput(field.text))
            {
              
                field.interactable = false;
                timer.countDown(3, field.text.ToLower());
    
                
            } else { field.text = "Please input a valid symbol"; }
        }

        public void Reset()
        {
            field.text = "";
            field.interactable = true;
            timer.reset = false;
        }

        public void Tick()
        {
           if(timer.reset == true)
            {
                Reset();
            }
        }
    }
}