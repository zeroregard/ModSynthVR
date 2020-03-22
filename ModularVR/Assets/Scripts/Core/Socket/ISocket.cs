using UnityEngine;

namespace Assets.Scripts.Core.Socket
{
    public enum SocketDirection
    {
        In,
        Out
    }
    public interface ISocket
    {
        bool PluggedIn();
        SocketDirection GetDirection();
        Transform GetTransform();
    }
}
