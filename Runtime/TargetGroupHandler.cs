#if CINEMACHINE_3
using Unity.Cinemachine;
#else
using Cinemachine;
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSelect
{
    public class TargetGroupHandler : MonoBehaviour
    {
        [SerializeField] private float _defaultWeight = 1f;
        [SerializeField] private float _defaultRadius = 1f;

        private CinemachineTargetGroup _targetGroup;

        private void Awake()
        {
            _targetGroup = GetComponent<CinemachineTargetGroup>();
        }

        public void AddTarget(Transform t)
        {
            _targetGroup.AddMember(t, _defaultWeight, _defaultRadius);
        }

        public void RemoveTarget(Transform t)
        {
            _targetGroup.RemoveMember(t);
        }
    }
}