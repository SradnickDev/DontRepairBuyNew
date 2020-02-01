using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using TMPro;

public class Clock : MonoBehaviour
{
    public int time = 20;
    float counter;
    TextMeshPro text;
    AudioSource source;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshPro>();
        source = GetComponent<AudioSource>();
    }

    public void StartCountdown()
    {
        counter = time;
        StartCoroutine(Countdown(time));
    }

    IEnumerator Countdown(int n)
    {
        for (int i = 0; i < n; i++)
        {
            yield return new WaitForSeconds(1);
            counter--;
            source.Play();
            if(counter > 9)
                text.text = "00:" + counter.ToString();
            else
                text.text = "00:0" + counter.ToString();
        }
    }
}
