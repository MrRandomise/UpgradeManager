using UnityEngine;
using Game.CoreUpgrade;
using Game.UpgradeSkill;

namespace Game.ConfigSkill
{
    [CreateAssetMenu(menuName = "Upgrades/SpeedUpgradeConfig", fileName = "SpeedUpgradeConfig")]
    public class SpeedUpgradeConfig : UpgradeConfig
    {
        public override Upgrade InstantiateUpgrade()
        {
            return new SpeedUpgrade(this);
        }
    }
}