using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using System;
using System.Threading;
using UnityEngine;

namespace CocoonDev.Foundation.Advertisement
{
    [DefaultExecutionOrder(-999)]
    public class AdsManagerCommand : MonoBehaviour
    {
        [Title("Asset Loader", titleAlignment: TitleAlignments.Centered)]
        [SerializeField]
        private AdsSettings _settings;
        [SerializeField]
        private GameObject _dummyCanvasPrefab;
        [SerializeField]
        private GameObject _interCooldownPrefab;

        [Title("Time Configs", titleAlignment: TitleAlignments.Centered)]
        [SerializeField]
        private bool _loadAdOnStart = true;
        [SerializeField]
        private bool _preshowOnStart = true;
        [SerializeField]
        private float _openFirstStartDelay = 5;

        private CancellationTokenSource _loadingCts;

        #region Unity Methods
        private void Awake()
        {
            RenewLoadingCts(ref _loadingCts);
            AdsManager.Initialize(_settings, _loadAdOnStart, _loadingCts.Token);
        }
        private async void Start()
        {
            if (_preshowOnStart)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_openFirstStartDelay)
                    , cancellationToken: this.GetCancellationTokenOnDestroy());
                AdsManager.ShowOpen();
            }
           
        }

        private void Update()
        {
            AdsManager.InternalOnUpdate();
        }

        private void OnApplicationPause(bool pause)
        {
            if (!pause && AdsManager.MainThreadEventsCount <= 0)
                AdsManager.ShowOpen();
        }
        #endregion

        private static void RenewLoadingCts(ref CancellationTokenSource cts)
        {
            cts ??= new();

            if (cts.IsCancellationRequested)
            {
                cts.Dispose();
                cts = new();
            }
        }

        [Button(buttonSize: 35), GUIColor("Yellow")]
        public void ShowOpen()
        {
            AdsManager.ShowOpen();
        }

        [Button(buttonSize: 35), GUIColor("Yellow")]
        public void ShowBanner()
        {
            AdsManager.ShowBanner();
        }


        [Button(buttonSize: 35), GUIColor("Yellow")]
        public void ShowInter()
        {
            AdsManager.ShowInter();
        }

        [Button(buttonSize: 35), GUIColor("Yellow")]
        public void ShowReward()
        {
            AdsManager.ShowRewardedAd(null);
        }
    }
}
