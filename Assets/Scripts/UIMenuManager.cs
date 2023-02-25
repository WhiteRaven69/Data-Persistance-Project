using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TMP_InputField _inputPlayerName;

    private string _currentPlayerName = "";

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {

    }

    private void UpdateUI()
    {
        UpdateBestScore();
        UpdatePlayerName();
    }

    private void UpdateBestScore()
    {
        _bestScoreText.text = "Best score: " + PersistanceData.Instance.bestScorePlayerName + " : " + PersistanceData.Instance.bestScore;
    }

    private void UpdatePlayerName()
    {
        _inputPlayerName.text = PersistanceData.Instance.bestScorePlayerName;
    }

    public void SetPlayerName(string name)
    {
        _currentPlayerName = name;
        PersistanceData.Instance.SetCurrentPlayerName(_currentPlayerName);

        UpdateUI();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }
}
