using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
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
        if (!product.enabled) return;

        var result = m_shoppingList.Keys.ToList().Find(p => p.Name == product.Name);
        if (result != null)
        {
			m_shoppingList[result]--;
			if (m_shoppingList[result] <= 0)
			{
				m_shoppingList.Remove(result);
			}
		}

		if (m_shoppingList.Count == 0)
		{
			Debug.Log("You Won!");
			OnBoughtAllProducts?.Invoke();
		}

		m_audioSource.PlayOneShot(m_clip);
		m_score.AddScore(1);
        product.enabled = false;

    }
}