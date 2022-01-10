using UnityEngine;
using UnityEditor;

namespace Assets.Scripts.Inspector
{
    [CustomEditor(typeof(PlayerModel))]
    public class PlayerModelInspector : Editor
    {
        #region Consts

        private const int COINS_TO_ADD = 10;

        private const int COINS_TO_WITHDRAW = 10;

        #endregion

        #region Methods

        public override void OnInspectorGUI()
        {
            var playerModel = (PlayerModel)target;

            GUILayout.Label("Player Model", EditorStyles.boldLabel);

            GUILayout.Space(10f);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Coins Balance");
            GUILayout.TextField(playerModel.Coins.ToString());

            if (GUILayout.Button("+"))
            {
                playerModel.AddCoins(COINS_TO_ADD);
            }       
            
            if (GUILayout.Button("-"))
            {
                playerModel.WithdrawCoins(COINS_TO_WITHDRAW);
            }

            GUILayout.EndHorizontal();

        }

        #endregion

    }
}
