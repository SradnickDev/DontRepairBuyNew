using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;
    public AudioClip[] clips;
    AudioSource source;

    public Vector3 scaleRate = new Vector3(0.2f, 0.2f, 0.2f);

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Healthy"))
        {
            EatHealthy(other.gameObject);
        }
        else if (other.CompareTag("Unhealthy"))
        {
            EatUnhealthy(other.gameObject);
        }
        else if (other.CompareTag("Coffee"))
        {
            DrinkCoffee(other.gameObject);
        }
    }

    public void EatHealthy(GameObject product)
    {
        leftHand.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        rightHand.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        source.PlayOneShot(clips[0]);
        if (product.GetComponent<OVRGrabbable>().grabbedBy != null)
        {
            product.GetComponent<OVRGrabbable>().grabbedBy.ForceRelease(product.GetComponent<OVRGrabbable>());
        }
        Destroy(product);
    }

    public void EatUnhealthy(GameObject product)
    {
        
        leftHand.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        rightHand.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        source.PlayOneShot(clips[0]);
        if (product.GetComponent<OVRGrabbable>().grabbedBy != null)
        {
            product.GetComponent<OVRGrabbable>().grabbedBy.ForceRelease(product.GetComponent<OVRGrabbable>());
        }
        Destroy(product);
    }

    public void DrinkCoffee(GameObject product)
    {

        if (product.GetComponent<OVRGrabbable>().grabbedBy != null)
        {
            product.GetComponent<OVRGrabbable>().grabbedBy.ForceRelease(product.GetComponent<OVRGrabbable>());
        }
        Destroy(product);
    }
}
