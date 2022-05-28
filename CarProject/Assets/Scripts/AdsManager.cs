using GoogleMobileAds.Api;
using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public static AdsManager instance;
    private BannerView bannerView;
    private InterstitialAd interstitial;
    public RewardedAd rewardedVideo;
    public string unityID = "4499733", unityInterstitial= "Interstitial_Android", unityRewarded= "Rewarded_Android", unityBanner= "Banner_Android";
    public string admobID= "ca-app-pub-5346214855207630~5236819506", bannerID= "ca-app-pub-5346214855207630/2660711338", interstitialID= "ca-app-pub-5346214855207630/9902822823", rewardedID= "ca-app-pub-5346214855207630/7050310654";
    public string testBannerID, testInterstitialID, testRewardedID;
    AdSize bannerSize;
    AdPosition bannerPosition;
    public bool testMode = false;
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
        Advertisement.Initialize(unityID, testMode);
        if (testMode)
        {
            bannerID = testBannerID;
            interstitialID = testInterstitialID;
            rewardedID = testRewardedID;
        }
        MobileAds.Initialize(admobID);
        RequestInterstitial();
        RequestRewarded();
    }
    public void ShowInterstitialAd()
    {

        if (interstitial != null)
        {
            if (interstitial.IsLoaded())
            {
                interstitial.Show();
            }
            else if (Advertisement.IsReady(unityInterstitial))
            {
                Advertisement.Show(unityInterstitial);
            }
        }
        else
        {
            RequestInterstitial();
            if (Advertisement.IsReady(unityInterstitial))
            {
                Advertisement.Show(unityInterstitial);
            }
        }
    }
    public void ShowRewardedVideo()
    {
        if (rewardedVideo.IsLoaded())
            rewardedVideo.Show();
        else if (Advertisement.IsReady(unityRewarded))
            Advertisement.Show(unityRewarded);
    }
    void RequestRewarded()
    {
        rewardedVideo = new RewardedAd(rewardedID);
        rewardedVideo.OnAdLoaded += HandleRewardedAdLoaded;
        rewardedVideo.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        rewardedVideo.OnAdOpening += HandleRewardedAdOpening;
        rewardedVideo.OnAdClosed += HandleRewardedAdClosed;
        rewardedVideo.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        rewardedVideo.OnUserEarnedReward += HandleUserEarnedReward;
        AdRequest request = new AdRequest.Builder().Build();
        rewardedVideo.LoadAd(request);
    }
    void RequestInterstitial()
    {
        interstitial = new InterstitialAd(interstitialID);
        interstitial.OnAdLoaded += InterstitialHandleOnAdLoaded;
        interstitial.OnAdFailedToLoad += InterstitialHandleOnAdFailedToLoad;
        interstitial.OnAdOpening += InterstitialHandleOnAdOpened;
        interstitial.OnAdClosed += InterstitialHandleOnAdClosed;
        interstitial.OnAdLeavingApplication += InterstitialHandleOnAdLeavingApplication;
        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }
    void RequestBanner()
    {
        bannerView = new BannerView(bannerID, bannerSize, bannerPosition);
        bannerView.OnAdLoaded += BannerHandleOnAdLoaded;
        bannerView.OnAdFailedToLoad += BannerHandleOnAdFailedToLoad;
        bannerView.OnAdOpening += BannerHandleOnAdOpened;
        bannerView.OnAdClosed += BannerHandleOnAdClosed;
        bannerView.OnAdLeavingApplication += BannerHandleOnAdLeavingApplication;
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }
    public void ShowBanner(AdSize _bannerSize, AdPosition _bannerPosition)
    {
        //if (Advertisement.IsReady(unityBanner))
        //{
        //    Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        //    Advertisement.Banner.Show(unityBanner);
        //}
        if (bannerView == null)
        {
            bannerSize = _bannerSize;
            bannerPosition = _bannerPosition;
            RequestBanner();
        }
        else
        {
            if (bannerSize == _bannerSize && bannerPosition == _bannerPosition)
            {
                bannerView.Show();
            }
            else
            {
                DestroyBanner();
                bannerSize = _bannerSize;
                bannerPosition = _bannerPosition;
                RequestBanner();
            }
        }
    }
    public void HideBanner()
    {
        //Advertisement.Banner.Hide();
        if (bannerView != null)
            bannerView.Hide();
    }
    public void DestroyBanner()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
            bannerView = null;
        }
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
    #region InterstitialCallBacks
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
        Invoke(nameof(GetReward), 0.1f);
    }

    void GetReward()
    {
        if (MainMenu.rewardCounter == 0)
        {
            PlayerPrefs.SetInt("car" + MainMenu.carNum, 1);
            MainMenu.instance.mainMenuPanel.SetActive(false);
            MainMenu.instance.mainMenuPanel.SetActive(true);
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            Invoke(nameof(GetReward), 0.1f);
        }
    }
    #endregion

}