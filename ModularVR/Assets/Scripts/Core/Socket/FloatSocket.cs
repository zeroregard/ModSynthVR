using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Core.Socket
{
    public class FloatSocket : MonoBehaviour, ISocket
    {
        public SocketDirection Direction;
        private bool _pluggedIn = false;

        public SocketDirection GetDirection() => Direction;
        public Transform GetTransform() => transform;
        public bool PluggedIn() => _pluggedIn;
        public Func<float, float> OutputFunction;

        private void OnDrawGizmos()
        {
            Handles.Label(transform.position, OutputFunction != null ? OutputFunction(Time.time).ToString() : "0");
        }
    }
}