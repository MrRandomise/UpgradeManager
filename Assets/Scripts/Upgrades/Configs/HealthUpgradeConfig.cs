using UnityEngine;
using Game.CoreUpgrade;
using Game.UpgradeSkill;

namespace Game.ConfigSkill
{
    [CreateAssetMenu(menuName = "Upgrades/HealthUpgradeConfig", fileName = "HealthUpgradeConfig")]
    public class HealthUpgradeConfig : UpgradeConfig
    {
        public override Upgrade InstantiateUpgrade()
        {
            return new HealthUpgrade(this);
        }
    }
}