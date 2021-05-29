using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleMobileAds.Api;
using System;
// ca-app-pub-5085148332011154~7557090426

public class AdmobManager : MonoBehaviour
{
    /*
    // Abs Test IDs from google
    // Android: https://developers.google.com/admob/android/test-ads
    // ios: https://developers.google.com/admob/ios/test-ads     
    */

    // 이걸 쓸경우 그냥 uniy 아디 써도 어차피 테스트 ID로 나옴
    // 여러 디바이스 추가 가능 (NOX: E2FED6B0427869D8)
    // 내 폰 Galaxy A30 ("6932FA1B72C7B800")
    // 아에 추가 안해도 괜춘
    private readonly string test_DeviceID = ("E2FED6B0427869D8"); // nox
    private readonly string test_DeviceID2 = ("6932FA1B72C7B800"); // A30

    
    
    //
    [SerializeField] private bool isStartBannerAds;
    private BannerView bannerView;
    // 그냥 AdPosition.Top 식으로도 가능함
    public AdPosition bannerAdsPosition;

    //
    [SerializeField] private bool enableInterstitialAd;
    private InterstitialAd interstitialAd;

    //
    [SerializeField] private bool enableRewardedAd;
    private RewardedAd rewardedAd;

    [SerializeField] private int gameAmount = 0;
    [SerializeField] private int rewardAmount = 1;


    private void Awake()
    {
        if(isStartBannerAds)
        {
            MobileAds.Initialize(initStatus => { RequestBannerAd(); });
        }

        if (enableInterstitialAd)
        {
            MobileAds.Initialize(initStatus => { RequestInterstitialAd(); });
        }

        if (enableRewardedAd)
        {
            MobileAds.Initialize(initStatus => { RequestRewardedAd(); });

        }
    }

    private void RequestBannerAd()
    {

        // Test
#if UNITY_ANDROID
        string test_BannerAdID = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string test_BannerAdID = "ca-app-pub-3940256099942544/2934735716";
#else
            string test_BannerAdID = "unexpected_platform";
#endif

        //
#if UNITY_ANDROID
        string bannerAdID = "ca-app-pub-5085148332011154/6790803667";
#elif UNITY_IPHONE
            string BannerAdID = "ca-app-pub-5085148332011154/8365585691";
#else
            string BannerAdID = "unexpected_platform";
#endif

        string adUnitId = Debug.isDebugBuild ? test_BannerAdID : bannerAdID;

        //banner = new BannerView(id, AdSize.SmartBanner, AdPosition.Top);
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, bannerAdsPosition);

        // Builder Design Pattern
        AdRequest request = new AdRequest.Builder()
            .AddTestDevice(test_DeviceID).AddTestDevice(test_DeviceID2).Build();

        bannerView.LoadAd(request);
    }

    #region InterstitalAd
    private void RequestInterstitialAd()
    {

        // TEST
#if UNITY_ANDROID
        string test_InterstitialAdUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string test_InterstitialAdUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string test_InterstitialAdUnitId = "unexpected_platform";
#endif

        //
#if UNITY_ANDROID
        string interstitialAdUnitId = "ca-app-pub-5085148332011154/5286150303";
#elif UNITY_IPHONE
        string interstitialAdUnitId = "ca-app-pub-5085148332011154/8105731249";
#else
        string interstitialAdUnitId = "unexpected_platform";
#endif

        string adUnitId = Debug.isDebugBuild ? test_InterstitialAdUnitId : interstitialAdUnitId;

        this.interstitialAd = new InterstitialAd(adUnitId);
      
        // Builder Design Pattern
        AdRequest request = new AdRequest.Builder()
            .AddTestDevice(test_DeviceID).AddTestDevice(test_DeviceID2).Build();
       
        //AdRequest request = new AdRequest.Builder().Build();

        interstitialAd.LoadAd(request);

        interstitialAd.OnAdClosed += HandleOnInterstitialAdClosed;

        //interstitialAd.OnAdClosed += (sender, e) => Debug.Log("광고가 닫힘");
        //interstitialAd.OnAdClosed += (sender, e) => { HandleOnAdClosed(sender); };

    }

    private void HandleOnInterstitialAdClosed(object sender, EventArgs e)
    {
        print("HandleAdClosed event received");
        print("sender: " + sender);

        // prepare for next Ad
        RequestInterstitialAd();

    }

    public void PlayInterstitialAd()
    {

        if (this.interstitialAd.IsLoaded())
        {
            this.interstitialAd.Show();
        }

    }

    #endregion

    #region RewardedAd

    private void RequestRewardedAd()
    {
        // Test
#if UNITY_ANDROID
        string test_RewardedAdUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
        string test_RewardedAdUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
        string test_RewardedAdUnitId = "unexpected_platform";
#endif
        //

#if UNITY_ANDROID
        string rewardedAdUnitId = "ca-app-pub-5085148332011154/4114515349";
#elif UNITY_IPHONE
        string rewardedAdUnitId = "ca-app-pub-5085148332011154/4426340684";
#else
        string rewardedAdUnitId = "unexpected_platform";
#endif

        string adUnitId = Debug.isDebugBuild ? test_RewardedAdUnitId : rewardedAdUnitId;

        rewardedAd = new RewardedAd(adUnitId);

        //
        rewardedAd.OnAdClosed += HandleOnRewardedAdClosed;

        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;

        //
        //AdRequest request = new AdRequest.Builder().Build();
        AdRequest request = new AdRequest.Builder()
            .AddTestDevice(test_DeviceID).AddTestDevice(test_DeviceID2).Build();

        rewardedAd.LoadAd(request);
    }

    private void HandleOnRewardedAdClosed(object sender, EventArgs e)
    {
        print("+++++++HandleUserEarnedReward+++++");


        print("HandleAdClosed event received");
        print("sender: " + sender);
        //
        RequestRewardedAd();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        print("=====HandleUserEarnedReward=====");
  
        gameAmount += rewardAmount;

        print("Reward Point: " + rewardAmount);
        print("GameAount: " + gameAmount);
    }
    public void PlayRewardedAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

    #endregion
}


