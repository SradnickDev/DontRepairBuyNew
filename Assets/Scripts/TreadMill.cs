using UnityEngine;

public class TreadMill : MonoBehaviour
{
    [SerializeField] private Vector3 m_dir;
    [SerializeField] private float m_pullForce;
    [SerializeField] private ForceMode m_forceMode;

    private void OnTriggerStay(Collider other)
    {
        {
            var rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb == null) return;
            rb.AddForce(m_dir * m_pullForce, m_forceMode);
        }
    }
}
