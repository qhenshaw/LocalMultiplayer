using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSelect
{
    [CreateAssetMenu(menuName = "Local Multiplayer/Player Colors")]
    public class PlayerColors : ScriptableObject
    {
        public Color[] Colors;
    }
}