using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Zenject;
using UnityEngine;
using System;

public class PlayerInputOptions
{
    public static string[] symbols = {"rock", "paper", "scissors", "question_mark" };
    // Start is called before the first frame update
    public PlayerInputOptions()
    {
     
    }

    public bool CheckInput(string j)
    {
        j = j.ToLower();
        for (int x = 0; x < symbols.Length - 1; x++)
        {
            if (symbols[x] == j)
            {
                return true;
            }
        } return false;
    }
}
