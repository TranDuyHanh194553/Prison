using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class loadRewarded : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public string androidAdUnitId;
    public string iosAdUnitId;

    string adUnitId;
    // [SerializeField] private Button restartButton, adsButton;

    void Awake()
    {
#if UNITY_IOS
        adUnitId = iosAdUnitId;
#elif UNITY_ANDROID
        adUnitId = androidAdUnitId;
#endif

    }

    public void LoadAd()
    {
        print("Loading Rewarded!!");
        Advertisement.Load(adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId.Equals(adUnitId))
        {
            print("Rewarded loaded!!");
            ShowAd();
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        print("Rewarded failed to load");
    }



    public void ShowAd()
    {

        print("showing Rewarded ad!!");
            Time.timeScale = 0;    
        Advertisement.Show(adUnitId, this);
        // restartButton.gameObject.SetActive(true);
        // adsButton.gameObject.SetActive(false);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        print("Rewarded clicked");

    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Time.timeScale = 1;
        if (placementId.Equals(adUnitId)&&showCompletionState.Equals(UnityAdsCompletionState.COMPLETED))
        {    
            print("Rewarded show complete , Distribute the rewards");
        }
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        print("Rewarded show failure");

    }

    public void OnUnityAdsShowStart(string placementId)
    {
        print("Rewarded show start");

    }
}