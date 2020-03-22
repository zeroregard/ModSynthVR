using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalKnobRenderer : MonoBehaviour
{
    [SerializeField] private Transform _knobMesh;
    [SerializeField] private float _rotationMinMax = 135;

    public void Render(float value)
    {
        var rotation = Mathf.Lerp(-_rotationMinMax, _rotationMinMax, value);
        _knobMesh.transform.localRotation = Quaternion.Euler(0, 0, rotation);
    }
}
