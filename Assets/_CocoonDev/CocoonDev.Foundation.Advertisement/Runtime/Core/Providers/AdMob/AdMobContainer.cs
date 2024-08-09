using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace CocoonDev.Foundation.Advertisement
{
    [System.Serializable]
    public class AdMobContainer
    {
        public static readonly string ANDROID_OPEN_TEST_ID = "ca-app-pub-3940256099942544/9257395921";
        public static readonly string IOS_OPEN_TEST_ID = "ca-app-pub-3940256099942544/2934735716";

        public static readonly string ANDROID_BANNER_TEST_ID = "ca-app-pub-3940256099942544/6300978111";
        public static readonly string IOS_BANNER_TEST_ID = "ca-app-pub-3940256099942544/2934735716";

        public static readonly string ANDROID_INTERSTITIAL_TEST_ID = "ca-app-pub-3940256099942544/1033173712";
        public static readonly string IOS_INTERSTITIAL_TEST_ID = "ca-app-pub-3940256099942544/4411468910";

        public static readonly string ANDROID_REWARDED_VIDEO_TEST_ID = "ca-app-pub-3940256099942544/5224354917";
        public static readonly string IOS_REWARDED_VIDEO_TEST_ID = "ca-app-pub-3940256099942544/1712485313";

        [BoxGroup("Open ID", centerLabel: true), SerializeField] 
        private string _androidOpenID;
        [BoxGroup("Open ID"), SerializeField] 
        private string _iOSOpenID;

        [BoxGroup("Banner ID", centerLabel: true), SerializeField] 
        private string _androidBannerID;
        [BoxGroup("Banner ID"), SerializeField] 
        private string _iOSBannerID;
        [BoxGroup("Banner ID"), SerializeField] 
        private BannerPlacementType _bannerType = BannerPlacementType.Banner;
        [BoxGroup("Banner ID"), SerializeField] 
        private BannerPosition _bannerPosition = BannerPosition.Bottom;

        [BoxGroup("Inter ID", centerLabel: true), SerializeField] 
        private string _androidInterstitialID;
        [BoxGroup("Inter ID"), SerializeField] 
        private string _iOSInterstitialID;

        [BoxGroup("Rewarded Ad ID", centerLabel: true), SerializeField] 
        private string _androidRewardID;
        [BoxGroup("Rewarded Ad ID"), SerializeField] 
        private string _iOSRewardID;

        [SerializeField] private List<string> _testDevicesIDs;

        // Properties
        public BannerPlacementType BannerType { get { return _bannerType; } }
        public BannerPosition BannerPosition { get { return _bannerPosition; } }

        public List<string> TestDevicesIDs { get { return _testDevicesIDs; } }


        // Get ID
        public string AndroidOpenID(bool testMode = false)
        {
            return testMode ? ANDROID_OPEN_TEST_ID : _androidOpenID;
        }
        public string IOSOpenID(bool testMode = false)
        {
            return testMode ? IOS_OPEN_TEST_ID : _iOSOpenID;
        }

        public string AndroidBannerID(bool testMode = false)
        {
            return testMode ? ANDROID_BANNER_TEST_ID : _androidBannerID;
        }
        public string IOSBannerID(bool testMode = false)
        {
            return testMode ? IOS_BANNER_TEST_ID : _iOSBannerID;
        }

        public string AndroidInterstitialID(bool testMode = false)
        {
            return testMode ? ANDROID_INTERSTITIAL_TEST_ID : _androidInterstitialID;
        }
        public string IOSInterstitialID(bool testMode)
        {
            return testMode ? IOS_INTERSTITIAL_TEST_ID : _iOSInterstitialID;
        }

        public string AndroidRewardedVideoID(bool testMode = false)
        {
            return testMode ? ANDROID_REWARDED_VIDEO_TEST_ID : _androidRewardID;
        }
        public string IOSRewardedVideoID(bool testMode = false)
        {
            return testMode ? IOS_REWARDED_VIDEO_TEST_ID : _iOSRewardID;
        }


        public enum BannerPlacementType
        {
            Banner = 0,
            MediumRectangle = 1,
            IABBanner = 2,
            Leaderboard = 3,
        }
    }
}
