using System.Linq;
using Game.CoreUpgrade;
using UnityEngine;
using Zenject;

public class UpgradesInstaller : MonoBehaviour
{
    [SerializeField] private UpgradeCatalog _catalog;

    private UpgradesManager _upgradesManager;

    [Inject]
    public void Construct(UpgradesManager upgradesManager)
    {
        _upgradesManager = upgradesManager;
        UpgradeManager();
    }

    private void UpgradeManager()
    {
        var upgradesConfig = _catalog.GetAllUpgradesConfig();
        var upgrades = new Upgrade[upgradesConfig.Length];
        for (var i = 0; i < upgradesConfig.Length; i++) upgrades[i] = upgradesConfig[i].InstantiateUpgrade();
        foreach (var config in upgradesConfig)
        {
            if (config.requiredUpgrades.Length == 0)
                continue;

            var targetUpgrade = upgrades.FirstOrDefault(t => t.Id == config.id);
            if (targetUpgrade is not IUpgrade requirableUpgrade)
                continue;
            var query = from firstItem in upgrades
                        join secondItem in config.requiredUpgrades
                            on firstItem.Id equals secondItem.id
                        select firstItem;

            requirableUpgrade.AddRequirements(query.ToArray());
        }

        _upgradesManager.Setup(upgrades);
    }
}