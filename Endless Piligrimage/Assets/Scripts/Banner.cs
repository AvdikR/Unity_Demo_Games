using GoogleMobileAds;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class Banner : MonoBehaviour
{
    BannerView bannerView;
    public void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) => {});
        this.CreateBannerView();
        //ListenToAdEvents();
    }

    //UNITY_ANDROID
    private string adUnitId = "ca-app-pub-3940256099942544/6300978111";

    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

        if (bannerView != null)
        {
            DestroyAd();
        }

        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

        LoadAd();
    }

    public void LoadAd()
    {
        if (bannerView == null)
        {
            CreateBannerView();
        }

        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        Debug.Log("Loading banner ad.");
        bannerView.LoadAd(adRequest);
    }

    private void ListenToAdEvents()
    {
        bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner view loaded an ad with response : "
                + bannerView.GetResponseInfo());
        };

        bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                + error);
        };

        bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Banner view paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };

        bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Banner view recorded an impression.");
        };

        bannerView.OnAdClicked += () =>
        {
            Debug.Log("Banner view was clicked.");
        };

        bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Banner view full screen content opened.");
        };

        bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner view full screen content closed.");
        };
    }

    public void DestroyAd()
    {
        if (bannerView != null)
        {
            Debug.Log("Destroying banner ad.");
            bannerView.Destroy();
            bannerView = null;
        }
    }
}
