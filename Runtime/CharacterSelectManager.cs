using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace CharacterSelect
{
    public class CharacterSelectManager : MonoBehaviour
    {
        [SerializeField] private PlayerColors _playerColors;
        [SerializeField] private PlayerInfoEventAsset _playerJoinedEvent;
        [SerializeField] private PlayerList _joinedList;
        [SerializeField] private PlayerList _readyList;
        [SerializeField] private string _gameplayScene;

        private void Awake()
        {
            _joinedList.Clear();
            _readyList.Clear();
        }

        public void OnPlayerJoined(PlayerInput playerInput)
        {
            playerInput.transform.SetParent(transform, false);
            int playerIndex = playerInput.playerIndex;
            Color color = _playerColors.Colors[playerIndex];
            playerInput.GetComponent<PlayerMenu>().Init(color);
            _playerJoinedEvent.Invoke(new PlayerInfo(playerIndex, color, playerInput.devices));
        }

        public void CheckQueue()
        {
            if (_readyList.Count == _joinedList.Count)
            {
                SceneManager.LoadScene(_gameplayScene);
            }
        }
    }
}