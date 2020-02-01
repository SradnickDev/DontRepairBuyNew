using System;
using NaughtyAttributes;
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
	private ParticleSystem spawnParticle;
	private BoxCollider m_collider;
	private DestructibleProduct m_destructible;
	private bool m_bought = false;

	private void Awake()
	{
		spawnParticle = GetComponentInChildren<ParticleSystem>();
		m_collider = GetComponent<BoxCollider>();
		m_destructible = GetComponent<DestructibleProduct>();
	}

	private void Start()
	{
        if(spawnParticle)
		    spawnParticle.Play();
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

	[Button()]
	private void playParticle()
	{
		spawnParticle.Play();
	}
}