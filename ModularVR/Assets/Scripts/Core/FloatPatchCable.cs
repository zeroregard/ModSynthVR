using Assets.Scripts.Core.Socket;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum PatchCableType
{
    Internal,
    External
}
[RequireComponent(typeof(PatchCableRenderer))]
public class FloatPatchCable : MonoBehaviour
{
    [SerializeField] private PatchCableRenderer _renderer;
    private FloatSocket _inSocket;
    private FloatSocket _outSocket;
    private bool _connected;

    void Awake()
    {
        _renderer = GetComponent<PatchCableRenderer>();
    }

    public void HandleConnection()
    {
        _renderer.UpdateLeftSide(_inSocket.GetTransform());
        _renderer.UpdateRightSide(_outSocket.GetTransform());
        _connected = true;
    }

    private void Update()
    {
        if(_connected)
        {
            _inSocket.OutputFunction = _outSocket.OutputFunction;
        }
    }

    public void HandleDisconnection()
    {
        _connected = false;
    }

    private bool IsConnected() => _inSocket != null && _outSocket != null;

    public bool Connect(FloatSocket socket)
    {
        var direction = socket.GetDirection();
        switch(direction)
        {
            case SocketDirection.In:
                if (_inSocket != null)
                    return false;
                _inSocket = socket;
                if (IsConnected())
                    HandleConnection();
                return true;
            case SocketDirection.Out:
                if (_outSocket != null)
                    return false;
                _outSocket = socket;
                if (IsConnected())
                    HandleConnection();
                return true;
        }
        return false;
    }
}
