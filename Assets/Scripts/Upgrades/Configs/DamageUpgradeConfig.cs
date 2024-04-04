using UnityEngine;
using Game.CoreUpgrade;
using Game.UpgradeSkill;

namespace Game.ConfigSkill
{
    [CreateAssetMenu(menuName = "Upgrades/AttackUpgradeConfig", fileName = "AttackUpgradeConfig")]
    public class DamageUpgradeConfig : UpgradeConfig
    {
        public override Upgrade InstantiateUpgrade()
        {
            return new DamageUpgrade(this);
        }
    }
}