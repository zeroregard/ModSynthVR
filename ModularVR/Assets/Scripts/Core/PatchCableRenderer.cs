using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatchCableRenderer : MonoBehaviour
{
    [SerializeField] RopeScript _renderer;

    private void Awake()
    {
        _renderer = GetComponent<RopeScript>();
    }
    public void UpdateLeftSide(Transform socket)
    {
        transform.position = socket.position;
    }

    public void UpdateRightSide(Transform socket)
    {
        _renderer.SetTarget(socket);
    }
}
