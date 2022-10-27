using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace CharacterSelect
{
    [Serializable]
    public class PlayerInfo
    {
        public int Index;
        public Color Color;
        public int[] DeviceIDs;

        public PlayerInfo(int index, Color color, ReadOnlyArray<InputDevice> devices)
        {
            Index = index;
            Color = color;
            DeviceIDs = new int[devices.Count];
            for (int i = 0; i < devices.Count; i++)
            {
                DeviceIDs[i] = devices[i].deviceId;
            }
        }

        public InputDevice[] GetDevices()
        {
            InputDevice[] devices = new InputDevice[DeviceIDs.Length];
            for (int i = 0; i < DeviceIDs.Length; i++)
            {
                devices[i] = InputSystem.GetDeviceById(DeviceIDs[i]);
            }

            return devices;
        }
    }
}