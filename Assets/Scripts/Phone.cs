using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    Animator anim;
    public GameObject[] buyingList;
    public int[] prices;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BuySomething();
        }
    }
    public void BuySomething()
    {
        anim.Play("Phone");
    }
}
