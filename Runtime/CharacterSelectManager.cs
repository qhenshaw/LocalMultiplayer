using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace CharacterSelect
{
    public class CharacterSelectManager : MonoBehaviour
    {
        [SerializeField] protected PlayerColors _playerColors;
        [SerializeField] protected PlayerInfoEventAsset _playerJoinedEvent;
        [SerializeField] protected PlayerList _joinedList;
        [SerializeField] protected PlayerList _readyList;
        [SerializeField] protected string _gameplayScene;

        protected virtual void Awake()
        {
            _joinedList.Clear();
            _readyList.Clear();
        }

        public virtual void OnPlayerJoined(PlayerInput playerInput)
        {
            playerInput.transform.SetParent(transform, false);
            int playerIndex = playerInput.playerIndex;
            Color color = _playerColors.Colors[playerIndex];
            playerInput.GetComponent<PlayerMenu>().Init(color);
            _playerJoinedEvent.Invoke(new PlayerInfo(playerIndex, color, playerInput.devices));
        }

        public virtual void CheckQueue()
        {
            if (_readyList.Count == _joinedList.Count)
            {
                SceneManager.LoadScene(_gameplayScene);
            }
        }
    }
}