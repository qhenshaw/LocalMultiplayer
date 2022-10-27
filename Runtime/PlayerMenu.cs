using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace CharacterSelect
{
    public class PlayerMenu : MonoBehaviour
    {
        [SerializeField] private Image _border;
        [SerializeField] private TextMeshProUGUI _playerName;
        [SerializeField] private TextMeshProUGUI _readyText;
        [SerializeField] private PlayerInfoEventAsset _playerReady;

        private Color _color;
        private PlayerInput _input;

        public void Init(Color color)
        {
            _input = GetComponent<PlayerInput>();
            _color = color;

            _color.a = 0.2f;
            _border.color = _color;

            _color.a = 1f;
            _playerName.text = $"Player {_input.playerIndex}";
            _playerName.color = _color;
        }

        public void ReadyUp()
        {
            _readyText.text = "Waiting for others...";
            _playerReady.Invoke(new PlayerInfo(_input.playerIndex, _color, _input.devices));
        }
    }
}