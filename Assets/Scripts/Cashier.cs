using TMPro;
using UnityEngine;

public class Cashier : MonoBehaviour
{
	[SerializeField] private ScoreData m_scoreData;
	[SerializeField] private TextMeshPro m_scoreText;

	private void Update()
	{
		m_scoreText.text = "<color=green>$</color> " + m_scoreData.Amount;
	}
}