using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
   public static AdsManager instance;

   public string androidGameID;
   public string iOSGameID;
   
   public string idAdsAndroid;
   public string idAdsIOS;
   
   public string idSelected;
   public string idADSSelected;

   public bool isTestMode;

   public Action completedAdsReward;
   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
         DontDestroyOnLoad(gameObject);
         StartAds();
      }
      else
      {
         Destroy(gameObject);
      }
   }
   
   private void StartAds()
   {
      #if UNITY_ANDROID
      idSelected = androidGameID;
      idADSSelected = idAdsAndroid;
      #elif UNITY_IOS
      idSelected = iOSGameID;
      idADSSelected = idAdsIOS;
      #elif UNITY_EDITOR
      idSelected = androidGameID;
      idADSSelected = idAdsAndroid;
      #endif
      
      if(!Advertisement.isInitialized)
         Advertisement.Initialize(androidGameID, false, this);
   }

   public void ShowAds()
   {
      Debug.Log("ShowAds");
      Advertisement.Load(idADSSelected, this);
   }

   public void OnInitializationComplete()
   {
      Debug.Log("OnInitializationComplete");
   }

   public void OnInitializationFailed(UnityAdsInitializationError error, string message)
   {
      Debug.LogError("OnInitializationFailed: " + message);
   }

   public void OnUnityAdsAdLoaded(string placementId)
   {
      Debug.LogError("OnUnityAdsAdLoaded");
      Advertisement.Show(placementId, this);
   }

   public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
   {
      Debug.LogError("OnUnityAdsFailedToLoad: " + message);
   }

   public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
   {
      Debug.LogError("OnUnityAdsShowFailure: " + message);
   }

   public void OnUnityAdsShowStart(string placementId)
   {
      Debug.LogError("OnUnityAdsShowStart");
   }

   public void OnUnityAdsShowClick(string placementId)
   {
      Debug.LogError("OnUnityAdsShowClick");
   }

   public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
   {
      if (placementId.Equals(idADSSelected) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
      {
         Debug.LogError("OnUnityAdsShowComplete");
         completedAdsReward?.Invoke();
      }
   }
}
