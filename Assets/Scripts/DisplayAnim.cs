using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DisplayAnim : MonoBehaviour
{
    public Image m_crack;
    public Sprite m_crack2;
    public Sprite m_crack3;
    public UnityEvent OnBrokenDisplay;

    public void InvokeOnBrokenDisplay()
    {
        OnBrokenDisplay?.Invoke();
    }

    public void UseCrack2()
    {
        m_crack.sprite = m_crack2;
    }
    
    public void UseCrack3()
    {
        m_crack.sprite = m_crack3;
    }
}
