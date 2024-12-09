using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager instance;
    async void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            
            await UnityServices.InitializeAsync();
        
            if ( UnityServices.State == ServicesInitializationState.Initialized)
                Debug.Log("ServicesInitializationState.Initialized");
        
            AnalyticsService.Instance.StartDataCollection();

            RecordStartGame();

            Debug.Log($"Started UGS Analytics Sample with user ID: {AnalyticsService.Instance.GetAnalyticsUserID()}");
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void RecordStartGame()
    {
        CustomEvent testCustomEvent = new CustomEvent("InitGame")
        {
            {"StringParameter","Start Game"},
        };
        AnalyticsService.Instance.RecordEvent(testCustomEvent);
            
        Debug.Log("InitGame");
    }

    public void RecordCrash()
    {
        CustomEvent crashCustomEvent = new CustomEvent("CrashReport")
        {
            {"Crash_Report","Game Crash"}
        };
        AnalyticsService.Instance.RecordEvent(crashCustomEvent);
        
        Debug.Log("Recording Crash Event");
    }

    public void RecordBuyEvent(int itemBuy)
    {
        CustomEvent BuyEvent = new CustomEvent("ItemBuy")
        {
            {"IntParameter",itemBuy},
        };

        AnalyticsService.Instance.RecordEvent(BuyEvent);
        
        Debug.Log("Recording Buy Event");
    }

    public void RecordRoundEvent(int playerHighScore)
    {
        CustomEvent SurviveEvent = new CustomEvent("RoundSurvive")
        {
            {"IntParameter",playerHighScore},
        };
        AnalyticsService.Instance.RecordEvent(SurviveEvent);
        
        Debug.Log("Recording Round Event");
    }
}