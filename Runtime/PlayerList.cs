using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace CharacterSelect
{
    [CreateAssetMenu(menuName = "Local Multiplayer/Player List")]
    public class PlayerList : ScriptableObject
    {
        [SerializeField] private List<PlayerInfo> _players = new List<PlayerInfo>();

        public int Count => _players.Count;

        public void AddPlayer(PlayerInfo playerInfo)
        {
            if (!Contains(playerInfo)) _players.Add(playerInfo);
        }

        public void RemovePlayer(PlayerInfo playerInfo)
        {
            if (Contains(playerInfo)) _players.Remove(playerInfo);
        }

        public void Clear()
        {
            _players = new List<PlayerInfo>();
        }

        private bool Contains(PlayerInfo playerInfo)
        {
            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].Index == playerInfo.Index) return true;
            }

            return false;
        }

        public PlayerInfo Get(int index)
        {
            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].Index == index) return _players[i];
            }

            return null;
        }
    }
}