using UnityEngine;

public class TreadMill : MonoBehaviour
{
    [SerializeField] private Vector3 m_dir;
    [SerializeField] private float m_pullForce;
    [SerializeField] private ForceMode m_forceMode;

    private void OnCollisionStay(Collision other)
    {
        var rb = other.gameObject.GetComponent<Rigidbody>();
        if (rb == null) return;
        rb.AddRelativeForce(m_dir * m_pullForce,m_forceMode);
    }
}
