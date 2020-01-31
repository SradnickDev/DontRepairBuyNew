using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class CustomerShoppingMenu : MonoBehaviour
{
	[SerializeField, ReorderableList]
	private List<Product> m_products = new List<Product>();

	[SerializeField] private ProductButton m_productButton;
	[SerializeField] private RectTransform m_buttonRect;
	[SerializeField] private Transform m_spawnPoint;

	private void Start()
	{
		CreateButtons();
	}

	private void CreateButtons()
	{
		foreach (var product in m_products)
		{
			var productButton = Instantiate(m_productButton, m_buttonRect, false);
			productButton.Setup(product.Icon, product.Name, 1, () => { SpawnProduct(product); });
		}
	}

	private void SpawnProduct(Product product)
	{
		Instantiate(product, m_spawnPoint.transform.position, Quaternion.identity);
	}
}