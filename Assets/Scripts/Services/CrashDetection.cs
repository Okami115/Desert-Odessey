using UnityEngine;
using UnityEngine.Serialization;

public class CrashDetection : MonoBehaviour
{
    [SerializeField] private AnalyticsManager analyticsManager;

    private const string GameStateKey = "GameState";
    private const string RunningState = "Running";
    private const string ClosedState = "Closed";

    private static bool instanceExists = false;
    void Awake()
    {
        if (instanceExists)
        {
            Destroy(gameObject);
            return;
        }

        instanceExists = true;
        DontDestroyOnLoad(gameObject);

        CheckGameState();

        PlayerPrefs.SetString(GameStateKey, RunningState);
        PlayerPrefs.Save();
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetString(GameStateKey, ClosedState);
        PlayerPrefs.Save();
    }

    void CheckGameState()
    {
        if (PlayerPrefs.HasKey(GameStateKey))
        {
            string lastState = PlayerPrefs.GetString(GameStateKey);
            if (lastState == RunningState)
            {
                analyticsManager.RecordCrash();
            }
        }
    }
}