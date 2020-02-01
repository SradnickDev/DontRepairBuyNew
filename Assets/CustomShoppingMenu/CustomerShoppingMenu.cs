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
	[SerializeField] private int m_itemsPerPage = 6;
	private List<ProductButton> m_productButtons = new List<ProductButton>();
	private int MaxPages => m_productButtons.Count / m_itemsPerPage;
	private int m_currentPage = 1;

	private void Start()
	{
		CreateButtons();
	}

	private void CreateButtons()
	{
		var i = 0;
		foreach (var product in m_products)
		{
			i++;
			var productButton = Instantiate(m_productButton, m_buttonRect, false);
			productButton.name = i.ToString();
			productButton.Setup(product.Icon, product.Name + i, 1, () => { SpawnProduct(product); });
			m_productButtons.Add(productButton);
		}
	}

	private void SpawnProduct(Product product)
	{
		Instantiate(product, m_spawnPoint.transform.position, Quaternion.identity);
	}

	[Button()]
	public void NextPage()
	{
		m_currentPage = (m_currentPage + 1) % MaxPages;
		DisplayPageProductButtons();
	}

	[Button()]
	public void PreviousPage()
	{
		m_currentPage = ((m_currentPage - 1) % MaxPages + MaxPages) % MaxPages;
		DisplayPageProductButtons();
	}

	private void DisplayPageProductButtons()
	{
		var startIdx = (m_currentPage+1) * m_itemsPerPage;
		var endIdx = Mathf.Clamp(startIdx + 6, 0, m_productButtons.Count);
		if (startIdx >= m_productButtons.Count)
		{
			startIdx = 0;
		}

		var currentIdx = startIdx;

		for (var i = 0; i < m_itemsPerPage; i++)
		{
			m_productButtons[currentIdx].transform.SetSiblingIndex(i);
			currentIdx = (currentIdx + 1) % endIdx;
		}
	}
}