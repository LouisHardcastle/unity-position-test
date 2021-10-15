using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Project.UI
{
    internal sealed class UIInstaller : MonoInstaller<UIInstaller>
    {
        [SerializeField] private TMP_InputField playerInput;
        
        [SerializeField] private Image playerSymbol;
        [SerializeField] private Image opponentSymbol;
        
        [SerializeField] private TMP_Text countdownText;
        [SerializeField] private TMP_Text resultText;

        [SerializeField] private GameHandler timer;
        [SerializeField] private SymbolHolder holder;
        
        
        
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerInputPresenter>().AsSingle().WithArguments(playerInput, new PlayerInputOptions(), timer).NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerSymbolPresenter>().AsSingle().WithArguments(playerSymbol, holder).NonLazy();
            Container.BindInterfacesAndSelfTo<OpponentSymbolPresenter>().AsSingle().WithArguments(opponentSymbol, holder).NonLazy();
            Container.BindInterfacesAndSelfTo<CountdownPresenter>().AsSingle().WithArguments(countdownText, timer).NonLazy();
            Container.BindInterfacesAndSelfTo<ResultTextPresenter>().AsSingle().WithArguments(resultText, timer).NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerInputOptions>().AsSingle().NonLazy();
            Container.Bind<HTMLReq>().AsSingle().NonLazy();
            Container.Bind<ResultMatrix>().AsSingle().NonLazy();
 
       
        }
    }
}