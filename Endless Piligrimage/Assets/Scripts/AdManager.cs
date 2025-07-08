using GoogleMobileAds.Api;
using System.Collections;
using UnityEngine;
using System;

public class AdManager : MonoBehaviour
{
    private BannerView bannerAd;

    private InterstitialAd interstitialAd;

    private RewardedAd rewardedAd;

    public static AdManager instance;
    bool isRewarded = false;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) => { });

        this.RequestBanner();
        this.RequestInterstitial();
        this.RequestRewardedAd();
    }

    private void Update()
    {
        if (isRewarded)
        {
            isRewarded = false;
            PlayerManager.numberOfCoins += 50;
        }
    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-3940256099942544/6300978111"; // Замініть на свій adUnitId для банера
        this.bannerAd = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = this.CreateAdRequest();
        this.bannerAd.LoadAd(request);
    }

    public void ShowBanner()
    {
        this.bannerAd.Show();
    }

    public void HideBanner()
    {
        this.bannerAd.Hide();
    }
    
    private void RequestInterstitial()
    {
        /*
        string adUnitId = "ca-app-pub-3940256099942544/1033173712"; // Замініть на свій adUnitId для міжсторінкової реклами
        this.interstitialAd = new InterstitialAd(adUnitId);
        AdRequest request = this.CreateAdRequest();
        this.interstitialAd.LoadAd(request);*/
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        InterstitialAd.Load(adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                interstitialAd = ad;
            });
    }

    
    public void ShowInterstitial()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }

    private void RequestRewardedAd()
    {
        /*
        string adUnitId = "ca-app-pub-3940256099942544/5224354917"; // Замініть на свій adUnitId для відео з винагородами
        this.rewardedAd = new RewardedAd(adUnitId);
        AdRequest request = this.CreateAdRequest();
        this.rewardedAd.LoadAd(request);*/
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }

        Debug.Log("Loading the rewarded ad.");

        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        RewardedAd.Load(adUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                rewardedAd = ad;
            });
    }

    public void ShowRewardedAd()
    {
        const string rewardMsg = "Rewarded ad rewarded the user. Type: {0}, amount: {1}.";

        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                // TODO: Reward the user.
                Debug.Log(String.Format(rewardMsg, reward.Type, reward.Amount));
            });
        }
    }

    #region RewardAd callback handlers
    public void HandleRewardAdClosed(object sender, EventArgs args)
    {
        this.RequestRewardedAd();
    }
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        isRewarded = true;// Обробка нагороди користувача після перегляду реклами
    }

    #endregion
}