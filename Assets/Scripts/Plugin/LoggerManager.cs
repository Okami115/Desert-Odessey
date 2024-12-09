using GooglePlayGames;
using GooglePlayGames.BasicApi;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoggerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textButton;
    void Start()
    {
        Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;
        Login();
    }

    public void Login()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }


    internal void ProcessAuthentication(SignInStatus status)
    {
        if(status == SignInStatus.Success) 
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log(status);
            textButton.color = Color.red;
        }
    }
}
