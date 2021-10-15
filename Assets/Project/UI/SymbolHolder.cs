using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class SymbolHolder : MonoBehaviour
    {
        private static SymbolHolder Instance;
        public static SymbolHolder instance { get { return Instance; } }

        public Dictionary<string, Texture2D> keyValuePairs;
        public Sprite opponentImage;
        public Sprite playerImage;


        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
            }
            Instance = this;
        }
        public void Start()
        {
            Object[] objects = Resources.LoadAll("Sprites", typeof(Texture2D));


            keyValuePairs = new Dictionary<string, Texture2D>()
            {
                ["rock"] = (Texture2D)objects[2],
                ["paper"] = (Texture2D)objects[0],
                ["scissors"] = (Texture2D)objects[3],
                ["question_mark"] = (Texture2D)objects[1]
            };
        }

        public void ChangePlayerSymbol(string symbol)
        {
            playerImage = MakeSprite(keyValuePairs[symbol]);
        }
        public void ChangeOpponentSymbol(string symbol)
        {
            opponentImage = MakeSprite(keyValuePairs[symbol]);
        }

        public Sprite MakeSprite(Texture2D tex)
        {
            return Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f,0.5f));
        }
    }

