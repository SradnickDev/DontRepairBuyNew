using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
	[SerializeField] private Animation m_screenAnim;
	[SerializeField] private Clock m_clock;

	public void StartGame()
	{
		m_screenAnim.Play();
		m_clock.StartCountdown();
	}

	public void RestartGame()
	{
		var scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.buildIndex);
	}
}