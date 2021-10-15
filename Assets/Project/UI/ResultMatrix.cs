using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultMatrix 
{
    public string[,] results = {
    { "rock", "rock" } , //tie
    { "paper", "paper" } , //tie
    { "scissors", "scissors" } , //tie

    { "scissors", "rock" } , //lose
    { "rock", "paper" } , //lose
    { "paper", "scissors" } , //lose
    
    { "paper", "rock" } , //win
    { "scissors", "paper" } , //win
    { "rock", "scissors" }  //win


    };

    public string returnResult(string[] x)
    {
        for (int i = 0; i < 3; i++)
        {
            if (x[0] == results[i, 0] && x[1] == results[i, 1])
            {
                return "tie";
            }
        }
        for (int i = 3; i < 6; i++)
        {
            if (x[0] == results[i, 0] && x[1] == results[i, 1])
            {
                return "lose";
            }
        }
        for (int i = 6; i < 9; i++)
        {
            if (x[0] == results[i, 0] && x[1] == results[i, 1])
            {
                return "win";
            }
        }

        return "fuck"; 
    }
};




