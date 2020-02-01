using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(AudioSource))]
public class Cart : MonoBehaviour
{
	[SerializeField] private AudioClip m_clip;
	[SerializeField] private AudioSource m_audioSource;
	[SerializeField] private ScoreData m_score;

	private void OnTriggerEnter(Collider other)
	{
		var product = other.gameObject.GetComponent<Product>();
		if (product == null) return;
		m_audioSource.PlayOneShot(m_clip);
		m_score.AddScore(1);
	}
}