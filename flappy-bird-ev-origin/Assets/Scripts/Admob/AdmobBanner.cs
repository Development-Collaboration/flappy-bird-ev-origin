using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleMobileAds.Api;

public class AdmobBanner : MonoBehaviour
{
    private BannerView bannerView;

    [SerializeField]
    private AdPosition bannerAdsPosition;

    private readonly string test_DeviceID = ("E2FED6B0427869D8"); // nox
    private readonly string test_DeviceID2 = ("6932FA1B72C7B800"); // A30

    private void Awake()
    {
        /*
        if (isStartBannerAds)
        {
            // 여기에 수동으로 앱 아이디 넣을 수도 있음
            MobileAds.Initialize(initStatus => 

             { 
                 RequestBanner(); 
             }
             
            );

        }
        */


        /*
        if (isStartBannerAds)
        {
            // 여기에 수동으로 앱 아이디 넣을 수도 있음
            MobileAds.Initialize(
                (initStatus) =>
                {
                    RequestBanner();

                    // status 정보 확인
                    var statusMap = initStatus.getAdapterStatusMap();

                    foreach (var status in statusMap)
                    {
                        Debug.Log($"{status.Key} : {status.Value}");
                    }
                }
            );

        }
        */
    }


    private void RequestBanner()
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

    /*
    public void ToggleAd(bool active)
    {
        if (active)
            bannerView.Show();
        else
            bannerView.Destroy();
    }
    */

    /*

    // 만약 광고를 아에 지우고 싶다면
    public void DestroyAd()
    {
        banner.Destroy();
    }
    */
}
