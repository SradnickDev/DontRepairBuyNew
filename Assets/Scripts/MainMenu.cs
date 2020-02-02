using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void LoadGame()
	{
		SceneManager.LoadScene(1);
	}

	public void Exit()
	{
	#if UNITY_EDITOR
		if (EditorApplication.isPlaying)
		{
			EditorApplication.isPlaying = false;
		}
	#else
		Application.Quit();
	#endif
	}
}