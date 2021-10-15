using JetBrains.Annotations;
using System;
using UnityEngine.UI;
using Zenject;

namespace Project.UI
{
    public abstract class SymbolPresenter: ITickable
    {
        public SymbolHolder SymbolHolder;
        public Image image;
        protected SymbolPresenter(Image image, SymbolHolder symbolHolder)
        {

        }
        public virtual void Tick()
        {
            
        }
    }

    [UsedImplicitly]
    public sealed class PlayerSymbolPresenter : SymbolPresenter
    {
        public PlayerSymbolPresenter(Image image, SymbolHolder holder) : base(image, holder)
        {
            if (holder == null)
                throw new ArgumentNullException("PlayerSymbolPresenters holder not set");
            this.SymbolHolder = holder;
            this.image = image;
        }
        public override void Tick()
        {
            this.image.sprite = SymbolHolder.playerImage;
        }
    }

    [UsedImplicitly]
    public sealed class OpponentSymbolPresenter : SymbolPresenter
    {
        public OpponentSymbolPresenter(Image image, SymbolHolder holder) : base(image, holder)
        {
            if (image == null || holder == null)
                throw new ArgumentNullException("OpponentSymbolPresenters not set");
            this.SymbolHolder = holder;
            this.image = image;

        }
        public override void Tick()
        {
            this.image.sprite = SymbolHolder.opponentImage;
        }
    }
}