using System;
using Cysharp.Text;
using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CocoonDev.Foundation.Advertisement
{
    [RequireComponent(typeof(CanvasGroup), typeof(RectTransform))]
    public class InterCooldownFeedback : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _rectTransform;
        [SerializeField]
        private CanvasGroup _canvasGroup;

        [Space]
        [SerializeField]
        private Image _radialFill;
        [SerializeField]
        private TextMeshProUGUI _countdownText;

        private Sequence _sequence;
        private event Action OnHide;

        public bool IsVisible
        {
            get => gameObject.activeSelf;
        }

        private void OnValidate()
        {
            if(_rectTransform == false)
                _rectTransform = GetComponent<RectTransform>();

            if( _canvasGroup == false)
                _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void RegisterListener(Action onHide)
        {
            OnHide = onHide;
        }

        public void Initialize(float initalTime)
        {
            _canvasGroup.alpha = 1.0F;

            _sequence = Sequence.Create();
            _sequence.Group(Tween.UIFillAmount(_radialFill, 0, initalTime, Ease.Linear));
            _sequence.Group(Tween.Custom(initalTime, 0, initalTime, UpdateCountdownText, Ease.Linear));
            _sequence.OnComplete(OnSequenceComplete);
            
        }

        public void Cleanup()
        {
            _sequence.Stop();
            _canvasGroup.alpha = 0;
            _radialFill.fillAmount = 1;

            gameObject.SetActive(false);
           
        }

        private void UpdateCountdownText(float value)
        {
            // ZString
            using (var sb = ZString.CreateStringBuilder())
            {
                // No fluent interface.
                sb.Append(Mathf.CeilToInt(value));
                _countdownText.TrySetText(sb);
            }
        }

        private void OnSequenceComplete()
        {
            Cleanup();
            OnHide?.Invoke();
        }
    }
}
