using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CharacterSelect
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerList _readied;
        [SerializeField] private GameObject _playerPrefab;

        private void Awake()
        {
            _playerInputManager = GetComponent<PlayerInputManager>();
            _playerInputManager.playerPrefab = _playerPrefab;
        }

        private Vector3[] _offsets = new[]
        {
        new Vector3(1f, 0f, 1f),
        new Vector3(1f, 0f, -1f),
        new Vector3(-1f, 0f, -1f),
        new Vector3(-1f, 0f, 1f),
    };
        private PlayerInputManager _playerInputManager;

        private void Start()
        {
            for (int i = 0; i < _readied.Count; i++)
            {
                PlayerInfo info = _readied.Get(i);
                if (info == null) continue;

                PlayerInput input = _playerInputManager.JoinPlayer(i, i, "Gamepad", info.GetDevices());
                GameObject player = input.gameObject;
                player.transform.position = transform.position + _offsets[i];
                player.transform.SetParent(transform, true);

                SkinnedMeshRenderer[] renderers = player.GetComponentsInChildren<SkinnedMeshRenderer>();
                for (int j = 0; j < renderers.Length; j++)
                {
                    renderers[j].material.color = info.Color;
                }
            }
        }
    }
}