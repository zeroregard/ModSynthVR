using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestThing : MonoBehaviour
{
    [SerializeField] private FloatPatchCable _patchCablePrefab;
    public FloatVCO WaveGenerator;
    public Speaker Speaker;

    void Start()
    {
        var cable = Instantiate(_patchCablePrefab);
        cable.Connect(WaveGenerator.OutSocket);
        cable.Connect(Speaker.InSocket);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
