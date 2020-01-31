using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ProductButton : MonoBehaviour
{
	[SerializeField] private Button m_button;
	[SerializeField] private Image m_countDown;
	[SerializeField] private TextMeshProUGUI m_countDownText;

	private void Awake()
	{
		m_button = GetComponent<Button>();
	}
	
	//public void Setup(Sprite icon)
}

public class CustomerShoppingMenu : MonoBehaviour
{
	[SerializeField, ReorderableList]
	private List<Product> m_products = new List<Product>();

	[SerializeField] private ProductButton m_productButton;
}