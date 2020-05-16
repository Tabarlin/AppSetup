using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;
public class Admob : MonoBehaviour
{
  private   RewardedAd rewardedAd;
    private void Start()
    {

        MobileAds.Initialize(initStatus => { });

        CreateAndLoadRewardedAd();
    }
    public void CreateAndLoadRewardedAd()
    {
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
        rewardedAd = new RewardedAd(adUnitId);

        rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
    }

    public void ShowRewardAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
        else
        {
            CreateAndLoadRewardedAd();
        }
            
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        CreateAndLoadRewardedAd();
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        Debug.Log("Награда");
        //Find.purchase.Add_money();
    }
}
