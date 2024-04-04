using UnityEngine;

namespace Game.Character
{
    public class Hero : MonoBehaviour
    {
        [field: SerializeField] public PlayerStats PlayerStats { get; private set; }
    }
}
