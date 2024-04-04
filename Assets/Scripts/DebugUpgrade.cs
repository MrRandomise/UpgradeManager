using Game.CoreUpgrade;
using UnityEngine;
using Zenject;

namespace Game.Debug
{
    public class DebugUpgrade : MonoBehaviour
    {
        [SerializeField] private UpgradesManager upgradesManager;

        [Inject]
        public void Construct(UpgradesManager upgradesManager)
        {
            this.upgradesManager = upgradesManager;
        }
    }
}
