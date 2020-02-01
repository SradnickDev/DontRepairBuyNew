using UnityEngine;

[RequireComponent(typeof(OVRGrabbable))]
[RequireComponent(typeof(DestructibleProduct))]
[RequireComponent(typeof(BoxCollider))]
public class Product : MonoBehaviour
{
	public string Name;
	public int Points;
	public Sprite Icon;
	public float Cooldown = 0.5f;
	[SerializeField] private LayerMask m_destructOnLayer;
	[SerializeField] private bool m_isBreakable = false;
	private BoxCollider m_collider;
	private DestructibleProduct m_destructible;
	private bool m_bought = false;

	private void Awake()
	{
		m_collider = GetComponent<BoxCollider>();
		m_destructible = GetComponent<DestructibleProduct>();
	}

	public void OnBought()
	{
		m_bought = true;
	}

	private void OnCollisionEnter(Collision other)
	{
		if (!m_isBreakable) return;
		if ((m_destructOnLayer & 1 << other.gameObject.layer) != 1 << other.gameObject.layer)
			return;

		if (m_bought) return;

		m_destructible.DestructProduct();
	}
}