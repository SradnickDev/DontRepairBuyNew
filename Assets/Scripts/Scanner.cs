using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Scanner : MonoBehaviour
{
	[SerializeField] private AudioClip m_clip;
	[SerializeField] private AudioSource m_audioSource;
	[SerializeField] private ScoreData ScoreData;
	private BoxCollider m_collider;

	private void Awake()
	{
		m_collider = GetComponent<BoxCollider>();
	}

	private void OnTriggerEnter(Collider other)
	{
		var product = other.gameObject.GetComponent<Product>();
		if (product == null) return;

		ScoreData.AddScore(product.Points);
		m_audioSource.PlayOneShot(m_clip);
	}
}