using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu]
public class ScoreData : ScriptableObject
{
	public int Amount => m_score;
	[SerializeField]private int m_score;

	public void AddScore(int amount)
	{
		m_score += amount;
	}

	public void RemoveScore(int amount)
	{
		m_score -= amount;
	}
}