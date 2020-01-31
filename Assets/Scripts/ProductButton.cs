using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ProductButton : MonoBehaviour
{
	[SerializeField] private Button m_button;
	[SerializeField] private TextMeshProUGUI m_name;
	[SerializeField] private Image m_countDownImage;
	[SerializeField] private TextMeshProUGUI m_countDownText;
	private Product m_product;

	private void Awake()
	{
		m_button = GetComponent<Button>();
	}

	public void Setup(Sprite icon, string name, Product product)
	{
		m_button.image.sprite = icon;
		m_name.text = name;
		m_product = product;
	}
}