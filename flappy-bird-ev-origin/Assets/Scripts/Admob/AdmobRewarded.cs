using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;

public class AdmobRewarded : MonoBehaviour
{
    private RewardedAd rewardedAd;

    private int gameAmount = 0;
    private int rewardAmount = 1;

    // Start is called before the first frame update
    void Start()
    {
        RequestRewardedAd();
    }

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
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleOnAdClosed;

        //
        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request);
    }

    public void PlayRewardedAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

    private void HandleOnAdClosed(object sender, EventArgs e)
    {
        print("HandleAdClosed event received");
        print("sender: " + sender);

       
        //
        RequestRewardedAd();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        // double amount = args.Amount;
        //rewardAmount = (int)amount;

        /*
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
        */

        /*
        string rewardedText;
        int gameAmount = 0;
        int rewardAmount = 0;
        */

        gameAmount += rewardAmount;
        
        print("Reward Point: " + rewardAmount);
        print("GameAount: " + gameAmount);
}
}
