using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text BestScoreText;
    public TMP_InputField NameInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BestScoreText.text = $"Best Score : {DataManager.Instance.BestPlayerName} : {DataManager.Instance.BestScore}";
    }

    public void StartNew()
    {
        DataManager.Instance.currentPlayerName = NameInput.text;
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
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
