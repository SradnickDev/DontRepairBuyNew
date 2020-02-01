using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Scanner : MonoBehaviour
{
    private BoxCollider m_collider;

    private void Awake()
    {
        m_collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var product = other.gameObject.GetComponent<Product>();
        if(product == null) return;
        
        Cashier.AddScore(product.Points);
    }
}
