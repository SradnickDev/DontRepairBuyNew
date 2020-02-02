using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public ScoreData score;
    Animator anim;
    public GameObject[] buyingList;
    public int[] prices;
    bool ready = true;
    AudioSource source;
    int currentItems;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finger") && ready)
        {
            ready = false;
            BuySomething();
        }
    }
    public void BuySomething()
    {
        anim.SetTrigger("touch");
        source.Play();
        StartCoroutine(Sleep());
        if (currentItems >= buyingList.Length) return;
        else if (score.Amount >= prices[currentItems])
        {
            buyingList[currentItems].SetActive(true);
            score.RemoveScore(prices[currentItems]);
            currentItems++;
        }
    }

    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(0.7f);
        ready = true;
    }
}
