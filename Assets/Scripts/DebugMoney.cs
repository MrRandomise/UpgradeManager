using Game.Gameplay.Player;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Debug
{
    public class DebugMoney : MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyText;
        [SerializeField] private MoneyStorage _moneyStorage;

        [Inject]
        public void Construct(MoneyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;
            _moneyStorage.OnMoneyChanged += UpdateMoneyText;
            _moneyStorage.SetupMoney(0);
        }

        private void OnDestroy()
        {
            _moneyStorage.OnMoneyChanged -= UpdateMoneyText;
        }

        private void UpdateMoneyText(int amount)
        {
            _moneyText.text = $"Money = {amount}";
        }
    }
}
