using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(AudioSource))]
public class Cart : MonoBehaviour
{
	[SerializeField] private CustomerShoppingMenu customerShopping;
	[SerializeField] private AudioClip m_clip;
	[SerializeField] private AudioSource m_audioSource;
	[SerializeField] private ScoreData m_score;
	private Dictionary<Product, int> m_shoppingList;

	private void OnTriggerEnter(Collider other)
	{
		var product = other.gameObject.GetComponent<Product>();
		if (product == null) return;
		//if (!product.Bought) return;
		if (!product.enabled) return;

		customerShopping.RemoveProductFromShoppingList(product);

		m_audioSource.PlayOneShot(m_clip);
		m_score.AddScore(1);
		product.enabled = false;
	}
}