using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CharacterSelect
{
    [RequireComponent(typeof(PlayerInputManager))]
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] protected PlayerList _readied;
        [SerializeField] protected GameObject _playerPrefab;
        [SerializeField] protected Transform[] _spawnPoints;

        protected virtual void Awake()
        {
            _playerInputManager = GetComponent<PlayerInputManager>();
            _playerInputManager.playerPrefab = _playerPrefab;
        }

        protected PlayerInputManager _playerInputManager;

        protected virtual void Start()
        {
            for (int i = 0; i < _readied.Count; i++)
            {
                PlayerInfo info = _readied.Get(i);
                if (info == null) continue;

                PlayerInput input = _playerInputManager.JoinPlayer(i, i, "Gamepad", info.GetDevices());
                GameObject player = input.gameObject;
                player.transform.position = _spawnPoints[i].position;
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