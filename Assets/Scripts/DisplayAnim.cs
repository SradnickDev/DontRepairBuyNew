using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisplayAnim : MonoBehaviour
{
    public UnityEvent OnBrokenDisplay;

    public void InvokeOnBrokenDisplay()
    {
        OnBrokenDisplay?.Invoke();
    }
}
