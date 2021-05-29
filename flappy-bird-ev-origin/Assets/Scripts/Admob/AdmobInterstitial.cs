using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

using GoogleMobileAds.Api;

public class AdmobInterstitial : MonoBehaviour
{
    private InterstitialAd interstitialAd;
    private void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => 
             {
                 RequestInterstitialAd();
             }
        );
    }

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


        /*
        // Builder Design Pattern
        AdRequest request = new AdRequest.Builder()
            .AddTestDevice(test_DeviceID).AddTestDevice(test_DeviceID2).Build();
        */

        AdRequest request = new AdRequest.Builder().Build();

        interstitialAd.LoadAd(request);

        interstitialAd.OnAdClosed += HandleOnAdClosed;

        //interstitialAd.OnAdClosed += (sender, e) => Debug.Log("±¤°í°¡ ´ÝÈû");
        //interstitialAd.OnAdClosed += (sender, e) => { HandleOnAdClosed(sender); };

    }

    private void HandleOnAdClosed(object sender, EventArgs e)
    {
        print("HandleAdClosed event received");
        print("sender: " + sender);

        //
        RequestInterstitialAd();

    }

    public void PlayInterstitialAd()
    {


        if (this.interstitialAd.IsLoaded())
        {
            this.interstitialAd.Show();
        }

    }

    /*
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }
    */

    /*
     
    start()
    {
            RequestInterstitialAd();

    // 10ÃÊµÚ ½ÇÇà
        Invoke("Show", 10f);
    }
    public void Show()
    {
        StartCoroutine("ShowScreenAd");
    }

    private IEnumerator ShowScreenAd()
    {
        while (!screenAd.IsLoaded())
        {
            yield return null;
        }

        screenAd.Show();
    }
     
     */





}
