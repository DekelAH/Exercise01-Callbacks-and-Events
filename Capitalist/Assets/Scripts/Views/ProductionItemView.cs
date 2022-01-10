using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GizmoLab.Capitalist.Views
{
    public class ProductionItemView : MonoBehaviour
    {
        #region Editor

        [Header("Unity View Components")]
        [SerializeField]
        private Text _producePriceText;

        [SerializeField]
        private Text _sellPriceText;

        [SerializeField]
        private Text _productNameText;

        [SerializeField]
        private Text _productionTimeText;

        [SerializeField]
        private Slider _productionProgressSlider;

        [SerializeField]
        private Image _productPreviewImage;

        [SerializeField]
        private Button _buyButtonRef;

        [Header("Unity Components")]
        [SerializeField]
        private string _productName;

        [SerializeField]
        [Range(1, 2000)]
        private int _productionPrice;

        [SerializeField]
        [Range(1, 2000)]
        private int _sellPrice;

        [SerializeField]
        private Sprite _previewImage;

        [SerializeField]
        [Range(1, 10)]
        private int _productionTimeSeconds;

        [SerializeField]
        private float _delay;       
        
        [SerializeField]
        private float _sliderValueToAdd;

        [SerializeField]
        private PlayerModel _playerModel;

        #endregion

        #region Methods

        private void OnValidate()
        {
            _productNameText.text = _productName;
            _producePriceText.text = _productionPrice.ToString();
            _sellPriceText.text = _sellPrice.ToString();
            _productionTimeText.text = _productionTimeSeconds.ToString();
            _productPreviewImage.sprite = _previewImage;
        }

        public void OnBuyButtonClick()
        {
            _playerModel.WithdrawCoins(_productionPrice);
            RunProgressBarCoroutine();
        }

        private void RunProgressBarCoroutine()
        {
            StartCoroutine(ProgressSliderCoroutine(_productionTimeSeconds, _delay, OnStartProgressBarCallback, OnProgressBarCallback, OnEndProgressBarCallback));
        }

        private void OnStartProgressBarCallback()
        {
            _buyButtonRef.enabled = false;
            _buyButtonRef.image.color = Color.grey;
            _productionProgressSlider.value = 0;

        }

        private void OnProgressBarCallback(int productionTimeSeconds)
        {
            _productionTimeText.text = productionTimeSeconds.ToString();
            _productionProgressSlider.value += _sliderValueToAdd;

        }

        private void OnEndProgressBarCallback()
        {
            _buyButtonRef.enabled = true;
            _productionTimeText.text = _productionTimeSeconds.ToString();
            _buyButtonRef.image.color = Color.white;
        }

        private IEnumerator ProgressSliderCoroutine(int productionTimeSeconds, float delay, Action startProgressBarCallback, Action<int> progressBarCallback, Action endProgressBarCallback)
        {
            startProgressBarCallback?.Invoke();

            while (productionTimeSeconds-- > 0)
            {
                progressBarCallback?.Invoke(productionTimeSeconds);
                yield return new WaitForSeconds(delay);
            }

            endProgressBarCallback?.Invoke();
        }

        #endregion
    }
}