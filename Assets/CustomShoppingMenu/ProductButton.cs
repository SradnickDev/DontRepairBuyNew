using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ProductButton : MonoBehaviour
{
	public Button Button
	{
		get
		{
			if (m_button == null)
			{
				m_button = GetComponent<Button>();
			}

			return m_button;
		}
	}

	[SerializeField] private Button m_button;
	[SerializeField] private Image m_icon;
	[SerializeField] private TextMeshProUGUI m_name;
	[SerializeField] private Image m_countDownImage;
	private float m_cooldown;

	public void Setup(Sprite icon, string name, float cooldown, UnityAction onClick)
	{
		m_icon.sprite = icon;
		m_name.text = name;
		m_cooldown = cooldown;
		Button.onClick.AddListener(onClick);
		Button.onClick.AddListener(StartCooldownCoroutine);
	}

	private void StartCooldownCoroutine()
	{
		StartCoroutine(Cooldown(m_cooldown));
	}

	private IEnumerator Cooldown(float cooldown)
	{
		var time = 0f;
		Button.interactable = false;
		
		while (time <= cooldown)
		{
			m_countDownImage.fillAmount = time / cooldown;
			time += Time.deltaTime;
			yield return null;
		}
		m_countDownImage.fillAmount = 0;

		Button.interactable = true;
	}

	private void OnDestroy()
	{
		Button.onClick.RemoveAllListeners();
	}
}