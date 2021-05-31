using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro_UI : MonoBehaviour
{
	public void GoMenu()
	{
		SceneManager.LoadScene("Menu");
	}

	//[SerializeField] private float _sleepTime = 3;
	//[SerializeField] private string nextSceneName;

	//void Start()
	//{
	//	Invoke("LoadScene", _sleepTime);
	//}

	//private void LoadScene()
	//{
	//	if (string.IsNullOrEmpty(nextSceneName))
	//	{
	//		return;
	//	}
	//	Application.LoadLevel(nextSceneName);
	//}
}
