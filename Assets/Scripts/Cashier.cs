using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Cashier : MonoBehaviour
{
    [ReadOnly]
    public static int Score;

    
    public static void AddScore(int score)
    {
        Score += score;
    }

    void Update()
    {
        Debug.Log(Score);
    }
}
