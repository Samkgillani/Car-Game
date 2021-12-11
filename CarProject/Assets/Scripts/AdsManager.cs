using GoogleMobileAds.Api;
using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour,IUnityAdsListener
{
    public static AdsManager instance;
    private BannerView smallBannerView;
    private BannerView largeBannerView;
    private InterstitialAd interstitial;
    public RewardedAd rewardedVideo;
    public string unityID,unityRewardedID,unityInterstitialID;
    public string admobID,admobSmallBannerID,admobLargeBannerID,admobInterstitialID,admobRewardedID;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this);
    }
    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(unityID);
        //MobileAds.Initialize(initStatus => { });
        //RequestInterstitial();
        //RequestRewarded();
    }
    public void ShowInterstitialAd()
    {
        if (interstitial.IsLoaded())
            interstitial.Show();
        else if (Advertisement.IsReady(unityInterstitialID))
            Advertisement.Show(unityInterstitialID);
    }
    public void ShowRewardedVideo()
    {
        if (rewardedVideo.IsLoaded())
            rewardedVideo.Show();
        else if (Advertisement.IsReady(unityRewardedID))
            Advertisement.Show(unityRewardedID);
    }
    void RequestRewarded()
    {
        rewardedVideo = new RewardedAd(admobRewardedID);
        rewardedVideo.OnAdLoaded += HandleRewardedAdLoaded;
        rewardedVideo.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        rewardedVideo.OnAdOpening += HandleRewardedAdOpening;
        rewardedVideo.OnAdClosed += HandleRewardedAdClosed ;
        rewardedVideo.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        rewardedVideo.OnUserEarnedReward += HandleUserEarnedReward; 
        AdRequest request = new AdRequest.Builder().Build();
        rewardedVideo.LoadAd(request);
    }
    void RequestInterstitial()
    {
        interstitial = new InterstitialAd(admobInterstitialID);
        interstitial.OnAdLoaded += InterstitialHandleOnAdLoaded;
        interstitial.OnAdFailedToLoad += InterstitialHandleOnAdFailedToLoad;
        interstitial.OnAdOpening += InterstitialHandleOnAdOpened;
        interstitial.OnAdClosed += InterstitialHandleOnAdClosed;
        interstitial.OnAdLeavingApplication += InterstitialHandleOnAdLeavingApplication;
        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }
    public void ShowSmallBanner()
    {
        if (smallBannerView != null)
        {
            smallBannerView.Show();
        }
        else
        {
            RequestSmallBanner();
        }
    }
    void RequestSmallBanner()
    {
        smallBannerView = new BannerView(admobSmallBannerID, AdSize.Banner, AdPosition.Bottom);
        smallBannerView.OnAdLoaded += BannerHandleOnAdLoaded;
        smallBannerView.OnAdFailedToLoad += BannerHandleOnAdFailedToLoad;
        smallBannerView.OnAdOpening += BannerHandleOnAdOpened;
        smallBannerView.OnAdClosed += BannerHandleOnAdClosed;
        smallBannerView.OnAdLeavingApplication += BannerHandleOnAdLeavingApplication;
        AdRequest request = new AdRequest.Builder().Build();
        smallBannerView.LoadAd(request);
    }  
    void RequestLargeBanner()
    {
        largeBannerView = new BannerView(admobLargeBannerID, AdSize.MediumRectangle, AdPosition.TopLeft);
        largeBannerView.OnAdLoaded += BannerHandleOnAdLoaded;
        largeBannerView.OnAdFailedToLoad += BannerHandleOnAdFailedToLoad;
        largeBannerView.OnAdOpening += BannerHandleOnAdOpened;
        largeBannerView.OnAdClosed += BannerHandleOnAdClosed;
        largeBannerView.OnAdLeavingApplication += BannerHandleOnAdLeavingApplication;
        AdRequest request = new AdRequest.Builder().Build();
        largeBannerView.LoadAd(request);
    }
    public void ShowLargeBanner()
    {
        if (largeBannerView != null)
        {
            largeBannerView.Show();
        }
        else
        {
            RequestLargeBanner();
        }
    }
    public void HideSmallBanner()
    {
        if (smallBannerView != null)
            smallBannerView.Hide();
    } 
    public void HideLargeBanner()
    {
        if (largeBannerView != null)
            largeBannerView.Hide();
    }
    #region BannerCallBacks
    public void BannerHandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void BannerHandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void BannerHandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void BannerHandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void BannerHandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
    #endregion
    #region InterstitialAds
    public void InterstitialHandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void InterstitialHandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void InterstitialHandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void InterstitialHandleOnAdClosed(object sender, EventArgs args)
    {

        RequestInterstitial();
    }

    public void InterstitialHandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
    #endregion
    #region RewardedAdsCallBacks
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        RequestRewarded();
        MonoBehaviour.print("HandleAdClosed event received");
    }
    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        GetReward();
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    void GetReward()
    {
        Debug.Log("Reward kuch nhi rakha");
    }

    public void OnUnityAdsReady(string placementId)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        throw new NotImplementedException();
    }
    #endregion

}