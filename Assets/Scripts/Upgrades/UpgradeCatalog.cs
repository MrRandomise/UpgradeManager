using System;
using UnityEngine;
using Game.ConfigSkill;

namespace Game.CoreUpgrade
{
    [CreateAssetMenu(
        fileName = "UpgradeCatalog",
        menuName = "Upgrade/Base/UpgradeCatalog"
    )]
    public sealed class UpgradeCatalog : ScriptableObject
    {
        [SerializeField]
        private UpgradeConfig[] configs;
        
        public UpgradeConfig[] GetAllUpgradesConfig()
        {
            return this.configs;
        }

        public UpgradeConfig FindUpgrade(string id)
        {
            var length = this.configs.Length;
            for (var i = 0; i < length; i++)
            {
                var config = this.configs[i];
                if (config.id == id)
                {
                    return config;
                }
            }

            throw new Exception($"Config with {id} is not found!");
        }
    }
}