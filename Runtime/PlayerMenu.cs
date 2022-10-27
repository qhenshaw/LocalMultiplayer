using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace CharacterSelect
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMenu : MonoBehaviour
    {
        [SerializeField] protected Image _border;
        [SerializeField] protected TextMeshProUGUI _playerName;
        [SerializeField] protected TextMeshProUGUI _readyText;
        [SerializeField] protected PlayerInfoEventAsset _playerReady;

        protected Color _color;
        protected PlayerInput _input;

        public virtual void Init(Color color)
        {
            _input = GetComponent<PlayerInput>();
            _color = color;

            _color.a = 0.2f;
            _border.color = _color;

            _color.a = 1f;
            _playerName.text = $"Player {_input.playerIndex}";
            _playerName.color = _color;
        }

        public virtual void ReadyUp()
        {
            _readyText.text = "Waiting for others...";
            _playerReady.Invoke(new PlayerInfo(_input.playerIndex, _color, _input.devices));
        }
    }
}