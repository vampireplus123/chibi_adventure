using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MethodType
{
    None,
    Banner,
    Interstitial,
    Rewarded,
}
public class AdsAccessing : MonoBehaviour
{
    public MethodType methodType;

    public int GiftForRewardVideo; // Add the gift to the player's coin count when the ad is shown and closed successfully;
    public int GiftForInterstitialVideo;

    void Start()
    {
        methodType = MethodType.None;
    }

    public void ExecuteMethod()
    {
        switch (methodType)
        {
            case MethodType.None:
                return;
            case MethodType.Banner:
                Banner();
                break;
            case MethodType.Interstitial:
                Interstitial();
                break;
            case MethodType.Rewarded:
                Rewarded();
                break;
        }
    }

    public void Interstitial()
    {
        if (adsManager.Instance != null)
        {
            if (IronSource.Agent.isInterstitialReady()) // Check if Interstitial is ready
            {
                Debug.Log("Showing interstitial ad...");
                adsManager.Instance.ShowInterstitial();
                ArrangeCoint(GiftForInterstitialVideo); // Add the gift to the player's coin count when the ad is shown and closed successfully
            }
            else
            {
                Debug.LogWarning("Interstitial ad is not ready.");
                ShowNoServicePanel(); // Show the "no service" panel if interstitial is not ready
            }
        }
        else
        {
            Debug.LogError("adsManager Instance is null!");
            ShowNoServicePanel();
        }
    }

    public void Banner()
    {
        if (adsManager.Instance != null)
        {
            Debug.Log("Showing Banner ad...");
            adsManager.Instance.LoadBanner();
        }
        else
        {
            Debug.LogError("adsManager Instance is null!");
            ShowNoServicePanel();
        }
    }

    public void Rewarded()
    {
        if (adsManager.Instance != null)
        {
            if (IronSource.Agent.isRewardedVideoAvailable()) // Check if Rewarded video is available
            {
                Debug.Log("Showing Rewarded ad...");
                adsManager.Instance.ShowRewardedVideo();
                ArrangeCoint(GiftForRewardVideo); // Add the gift to the player's coin count when the ad is shown and closed successfully); // Add the gift to the player's coin count when the ad is shown and closed successfully
            }
            else
            {
                Debug.LogWarning("Rewarded ad is not available.");
                ShowNoServicePanel();
            }
        }
        else
        {
            Debug.LogError("adsManager Instance is null!");
            ShowNoServicePanel();
        }
    }

    private void ShowNoServicePanel()
    {
        if (NoServices.Instance != null)
        {
            NoServices.Instance.ShowUp();
        }
        else
        {
            Debug.LogError("NoServices Instance is null!");
        }
    }

    void ArrangeCoint(int typeGift)
    {
        if(adsManager.Instance.RewardedCoin != 0)
        {
            adsManager.Instance.RewardedCoin = 0;
        }
        adsManager.Instance.RewardedCoin += typeGift;
    }
}
