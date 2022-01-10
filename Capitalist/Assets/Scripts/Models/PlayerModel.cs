using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Gizmo Lab/Models/Player Model", fileName = "Player Model")]
public class PlayerModel : ScriptableObject
{
    #region Events

    public event Action<int> CoinsBalanceChange;

    #endregion

    #region Fields

    [SerializeField]
    private int _coins;

    #endregion

    #region Methods

    public void AddCoins(int coinsToAdd)
    {
        _coins += coinsToAdd;
        CoinsBalanceChange?.Invoke(_coins);
    }

    public void WithdrawCoins(int coinsToTake)
    {
        if (coinsToTake <= _coins)
        {
            _coins = Mathf.Max(0, _coins - coinsToTake);
            CoinsBalanceChange?.Invoke(_coins);
        }
        else
        {
            Debug.Log("Not Enough Coins!");
        }
    }

    #endregion

    #region Properties

    public int Coins => _coins;

    #endregion
}
