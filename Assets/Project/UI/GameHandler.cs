using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

namespace Project.UI
{
    public class GameHandler : MonoBehaviour
    {
        [HideInInspector]
        public string timeRemaining;
        private HTMLReq req;
        private ResultMatrix matrix;
        private string[] options = { "rock", "paper", "scissors" };
        private string[] _result;
        public TMP_Text resultText;

        public bool reset;

        [Inject]
    public void Init(HTMLReq req, ResultMatrix matrix)
        {
            this.req = req;
            this.matrix = matrix;
           
        }
     
    public void countDown(int x, string s)
        {
            StartCoroutine(req.SendRequest("http://www.randomnumberapi.com/api/v1.0/random?min=0&max=2&count=1"));
            StartCoroutine(waitForSeconds(x, s));
        }
    public IEnumerator waitForSeconds(int x, string s)
        {
            while (x >= 0)
            {
                timeRemaining = x.ToString();
                yield return new WaitForSeconds(1);
                x--;
            }
            RevealSymbols(s);
            StartCoroutine(delay(0.5f, true));
        }
    public void RevealSymbols(string s)
        {
            SymbolHolder.instance.ChangePlayerSymbol(s);

            if (int.TryParse(req.result[1].ToString(), out int ind))
            {
                SymbolHolder.instance.ChangeOpponentSymbol(options[int.Parse(req.result[1].ToString())]);
                _result = new string[] {  s, options[int.Parse(req.result[1].ToString())] } ;

            }
            else
            {
                int xc = Random.Range(0, 2);
                SymbolHolder.instance.ChangeOpponentSymbol(options[xc]);
                _result = new string[] {  s,  options[xc]};
            }
        }

    public IEnumerator delay(float x, bool y)
        {
            yield return new WaitForSeconds(x);

            if (y)
                showWinner();

            else
            {
                timeRemaining = "";
                resultText.text = "Result";
                SymbolHolder.instance.ChangePlayerSymbol("question_mark");
                SymbolHolder.instance.ChangeOpponentSymbol("question_mark");
                reset = true;
            }
                
        }
    public void showWinner()
        {
            resultText.text = matrix.returnResult(_result);
            resetGame();
        }
    public void resetGame()
        {
            StartCoroutine(delay(2f, false));
        }
    }
}



