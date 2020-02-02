using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class CustomerShoppingMenu : MonoBehaviour
{
    public UnityEvent OnBoughtAllProducts;
    [SerializeField, ReorderableList]
    private List<Product> m_products = new List<Product>();

    [SerializeField] private ProductButton m_productButton;
    [SerializeField] private RectTransform m_buttonRect;
    [SerializeField] private Transform m_spawnPoint;
    [SerializeField] private int m_itemsPerPage = 6;
    [SerializeField] private TextMeshProUGUI m_shoppingListDisplay;
	private List<ProductButton> m_productButtons = new List<ProductButton>();

	private int MaxPages =>
		Mathf.CeilToInt((float) m_productButtons.Count / (float) m_itemsPerPage);

	private int m_currentPage = 1;
	[SerializeField,MinMaxSlider(0,20)] private Vector2 m_itemsToBuyRange = new Vector2(0,20);
	private Dictionary<Product, int> m_shoppingList = new Dictionary<Product, int>();

	private void Start()
	{
		CreateButtons();
		CreateShoppingList();
	}

	private void CreateButtons()
	{
		var i = 0;
		foreach (var product in m_products)
		{
			i++;
			var productButton = Instantiate(m_productButton, m_buttonRect, false);
			productButton.name = i.ToString();
			productButton.Setup(product.Icon, product.Name, product.Cooldown,
								() =>
								{
									SpawnProduct(product);
				
								});
			m_productButtons.Add(productButton);
		}
	}

	private void CreateShoppingList()
	{
		var maxItems = Random.Range(m_itemsToBuyRange.x, m_itemsToBuyRange.y);

		for (var i = 0; i < maxItems; i++)
		{
			var rndIdx = Random.Range(0, m_products.Count);
			var product = m_products[rndIdx];

			if (m_shoppingList.ContainsKey(product))
			{
				m_shoppingList[product]++;
			}
			else
			{
				m_shoppingList.Add(product, 1);
			}
		}

		UpdateShoppingList();
	}

	public void RemoveProductFromShoppingList(Product product)
	{
        var result = m_shoppingList.Keys.ToList().Find(p => p.Name == product.Name);
        if (result == null) return;
        if (m_shoppingList.ContainsKey(result))
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


        UpdateShoppingList();
	}

	private void UpdateShoppingList()
	{
		m_shoppingListDisplay.text = "";
		foreach (var pair in m_shoppingList)
		{
			var amount = pair.Value;
			var productName = pair.Key.Name;
			m_shoppingListDisplay.text += $"{amount} x {productName}\n";
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
		var startIdx = (m_currentPage + 1) * m_itemsPerPage;
		var endIdx = Mathf.Clamp(startIdx + m_itemsPerPage, 0, m_productButtons.Count);
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