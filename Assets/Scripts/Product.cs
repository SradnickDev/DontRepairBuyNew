using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Product : MonoBehaviour
{
	public string Name;
	public int Points;
	public Sprite Icon;
	private BoxCollider m_collider;

	private void Awake()
	{
		m_collider = GetComponent<BoxCollider>();
	}

	private void Start()
	{
		
	}
}