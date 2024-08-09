using Sirenix.OdinInspector;
using UnityEngine;

namespace CocoonDev.Foundation.Advertisement
{
    public class InterCooldownBehavior : MonoBehaviour
    {
        private const float SHOW_COOLDOWN_UI_TIMEOUT = 5;

        [Title("Component Refs", titleAlignment: TitleAlignments.Centered)]
        [SerializeField]
        private InterCooldownFeedback _interCooldownFeedback;

        [Title("Settings", titleAlignment: TitleAlignments.Centered)]
        [SerializeField]
        private float _initialPlayInterval;
        [SerializeField]
        private float _initialAFKInterval;

        [Title("Debug Info", titleAlignment: TitleAlignments.Centered)]
        [SerializeField, ReadOnly] 
        private float _playTimeElapsed;
        [SerializeField, ReadOnly]
        private float _afkTimeElapsed;

        #region Unity Methods
        private void Start()
        {
            Initialize();
        }
        private void Update()
        {
            OnLogic();
        }
        #endregion

        public void Initialize()
        {
            _interCooldownFeedback.RegisterListener(OnCooldownComplete);
        }

        public void OnLogic()
        {
            if (Input.anyKey)
                _afkTimeElapsed = 0;

            _playTimeElapsed += Time.deltaTime;
            _afkTimeElapsed += Time.deltaTime;

            if (!_interCooldownFeedback.IsVisible && HasInterCooldownFeedback())
            {
                ShowInterCooldownFeedback();
                return;
            }

            if (_interCooldownFeedback.IsVisible && !HasInterCooldownFeedback())
            {
                HideInterCooldownFeedback();
            }
        }
       

        private bool HasInterCooldownFeedback()
        {
            return _playTimeElapsed >= _initialPlayInterval - SHOW_COOLDOWN_UI_TIMEOUT
                || _afkTimeElapsed >= _initialAFKInterval - SHOW_COOLDOWN_UI_TIMEOUT;
                
        }

        private void ResetTimeElapsed()
        {
            _playTimeElapsed = 0.0f;
            _afkTimeElapsed = 0.0f;
        }

        private void OnCooldownComplete()
        {
            AdsManager.ShowInter();
            ResetTimeElapsed();
        }

        private void ShowInterCooldownFeedback()
        {
            _interCooldownFeedback.gameObject.SetActive(true);
            _interCooldownFeedback.Initialize(SHOW_COOLDOWN_UI_TIMEOUT);
        }

        private void HideInterCooldownFeedback()
        {
            _interCooldownFeedback.gameObject.SetActive(false);
            _interCooldownFeedback.Cleanup();
        }

    }
}
