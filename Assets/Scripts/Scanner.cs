using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Scanner : MonoBehaviour
{
	[SerializeField] private AudioClip[] m_clips;
	[SerializeField] private AudioSource m_audioSource;
	[SerializeField] private ScoreData ScoreData;
	[SerializeField] private TextMeshPro m_textMesh;
	private BoxCollider m_collider;

	private void Awake()
	{
		m_collider = GetComponent<BoxCollider>();
	}

	private void OnTriggerEnter(Collider other)
	{
		var barcode = other.gameObject.GetComponent<Barcode>();
		if (barcode == null) return;

		barcode.OnBought();
		ScoreData.AddScore(barcode.Product.Points);
		m_textMesh.text = barcode.Product.Name;
        var randomClipIdx = Random.Range(0, m_clips.Length);
		m_audioSource.PlayOneShot(m_clips[randomClipIdx]);
		Destroy(barcode);
	}
}