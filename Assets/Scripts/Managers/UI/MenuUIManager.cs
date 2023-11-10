using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TextMeshProUGUI _scoreText;
    private void Start()
    {
        _scoreText.text = $"Score: {MMainManager.Instance.highScore} : Name: {MMainManager.Instance.highPName}";
    }

    public void LoadScene(string sceneName)
    {
        GetPlayerName();
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit();
        #endif
    }

    private void GetPlayerName()
    {
        Debug.Log(_inputField.text);
        MMainManager.Instance.playerName = _inputField.text; 
    }
}
