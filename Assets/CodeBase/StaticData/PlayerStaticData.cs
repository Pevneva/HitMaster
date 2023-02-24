using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "Player", menuName = "Player", order = 0)]
    public class PlayerStaticData : ScriptableObject
    {
        [Range(0, 5)] public float DelayBeforeMoving = 0.45f;

        [Range(0, 3)] public float AttackCooldown = 0.5f;
        
        [Range(0, 5)] public float DelayBeforeRestartLevel = 3;

        [Range(0.5f, 15)] public float Speed = 5f;
    }
}