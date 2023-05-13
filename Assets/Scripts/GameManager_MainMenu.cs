using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_MainMenu : MonoBehaviour
{
	[SerializeField] private GameObject mainMenuPanel;
	[SerializeField] private GameObject selectLevelPanel;

	// Main Menu Select Level
	public void OnPlayClick () {
		mainMenuPanel.SetActive(false);
		selectLevelPanel.SetActive(true);
	}

	public void OnBackClick () {
		mainMenuPanel.SetActive(true);
		selectLevelPanel.SetActive(false);
	}

	public void OnQuitClick () {
#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#else
				Application.Quit();
#endif
	}

	public void OnLevelSelect (String level) {
		SceneManager.LoadScene(level);
	}
}
