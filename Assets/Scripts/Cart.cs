using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(AudioSource))]
public class Cart : MonoBehaviour
{
	public UnityEvent OnBoughtAllProducts;
	[SerializeField] private AudioClip m_clip;
	[SerializeField] private AudioSource m_audioSource;
	[SerializeField] private ScoreData m_score;
	private Dictionary<Product, int> m_shoppingList;

	public void OnShoppingListCreated(Dictionary<Product, int> shoppingList)
	{
		m_shoppingList = new Dictionary<Product, int>(shoppingList);
	}

	private void OnTriggerEnter(Collider other)
	{
		var product = other.gameObject.GetComponent<Product>();
		if (product == null) return;

		if (m_shoppingList.ContainsKey(product))
		{
			m_shoppingList[product]--;
			if (m_shoppingList[product] <= 0)
			{
				m_shoppingList.Remove(product);
			}
		}

		if (m_shoppingList.Count == 0)
		{
			Debug.Log("You Won!");
			OnBoughtAllProducts?.Invoke();
		}

		m_audioSource.PlayOneShot(m_clip);
		m_score.AddScore(1);
	}
}