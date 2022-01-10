using System;
using UnityEngine;
using UnityEngine.UI;

namespace GizmoLab.Capitalist.Views
{
    public class CoinsBalanceView : MonoBehaviour
    {
        #region Editor

        [Header("Unity Components")]
        [SerializeField]
        private Text _coinsBalanceText;

        [SerializeField]
        private PlayerModel _playerModel;
        
        #endregion

        #region Methods

        private void Start()
        {
            UpdateBalance(_playerModel.Coins);
            _playerModel.CoinsBalanceChange += UpdateBalance;
        }

        private void OnDestroy()
        {
            _playerModel.CoinsBalanceChange -= UpdateBalance;
        }

        private void UpdateBalance(int currentBalance)
        {
            _coinsBalanceText.text = currentBalance.ToString();
        }

        #endregion
    }
}