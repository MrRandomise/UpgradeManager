using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Game.Character
{
    [Serializable]
    public sealed class PlayerStats
    {
        [ReadOnly,ShowInInspector]
        private readonly Dictionary<string, int> stats = new();
        
        [Button]
        public void AddStat(string name, int value)
        {
            this.stats.Add(name, value);
        }

        public int GetStat(string name)
        {
            return this.stats[name];
        }

        public IReadOnlyDictionary<string, int> GetStats()
        {
            return this.stats;
        }
        
        [Button]
        public void ChangeStat(string name, int newValue)
        {
            if (!stats.ContainsKey(name))
                throw new NullReferenceException($"No stat with name - {name}");
            this.stats[name] = newValue;
        }
        
        [Button]
        public void RemoveStat(string name)
        {
            this.stats.Remove(name);
        }
    }
}