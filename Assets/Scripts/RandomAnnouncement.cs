using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomAnnouncement : MonoBehaviour
{
	[SerializeField] private AudioClip[] m_clips;
	private AudioSource m_source;

	private void Start()
	{
		if (m_clips == null || m_clips.Length == 0) return;
		m_source = GetComponent<AudioSource>();
		StartCoroutine(PlayRandomSound());
	}

	private IEnumerator PlayRandomSound()
	{
		yield return new WaitForSeconds(15);
		var clip = m_clips[Random.Range(0, m_clips.Length)];
		m_source.PlayOneShot(clip);
		StartCoroutine(PlayRandomSound());
	}
}