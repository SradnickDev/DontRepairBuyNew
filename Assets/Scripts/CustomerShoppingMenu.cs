using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class CustomerShoppingMenu : MonoBehaviour
{
	[SerializeField, ReorderableList]
	private List<Product> m_products = new List<Product>();

	[SerializeField] private ProductButton m_productButton;
	[SerializeField] private Rect m_buttonRect;

}