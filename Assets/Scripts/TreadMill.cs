using System;
using UnityEngine;

public class TreadMill : MonoBehaviour
{
    [SerializeField] private float m_scrollSpeed = 0.5f;
    
    [SerializeField] private Vector3 m_dir;
    [SerializeField] private float m_pullForce;
    [SerializeField] private ForceMode m_forceMode;
    [SerializeField] private MeshRenderer renderer;


    private void Update()
    {
        float offset = Time.time * m_scrollSpeed;
        
        var material = renderer.material;
        
        var posX = material.mainTextureOffset.x;
        var posY = material.mainTextureOffset.y;
        
        var newPos = new Vector2(offset ,posY);

        material.mainTextureOffset = newPos;
    }

    private void OnTriggerStay(Collider other)
    {
        {
            var rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb == null) return;
            rb.AddForce(m_dir * m_pullForce, m_forceMode);
        }
    }
}
