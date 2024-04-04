using System.Linq;
using Game.ConfigSkill;
using Game.CoreUpgrade;

namespace Game.UpgradeSkill
{
    public class HealthUpgrade : Upgrade, IUpgrade
    {
        private Upgrade[] _requiredUpgrades;
        public HealthUpgrade(UpgradeConfig config) : base(config)
        {
        }

        public void AddRequirements(params Upgrade[] requiredUpgrades)
        {
            _requiredUpgrades = requiredUpgrades;
        }
        
        public override bool CanUpgrade()
        {
            if (_requiredUpgrades == null)
                return base.CanUpgrade();
            return _requiredUpgrades.All(upgrade => Level < upgrade.Level);
        }
        
        protected override void LevelUp(int level)
        {
        }
    }
}