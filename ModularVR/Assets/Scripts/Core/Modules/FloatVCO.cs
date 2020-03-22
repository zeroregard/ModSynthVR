using Assets.Scripts.Core.Modules.ValueGenerator;
using Assets.Scripts.Core.Socket;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public enum WaveFunction
{
    Sin,
    Triangle,
    Square
}

public class FloatVCO : MonoBehaviour
{
    public FloatSocket OutSocket;
    public FloatGenerator Frequency;
    public FloatGenerator WaveShape;
    private float _sampleRate;

    void Awake()
    {
        _sampleRate = AudioSettings.outputSampleRate;
    }

    void Update()
    {
        Generate();
    }

    public void Generate()
    {
        var frequency = GetFrequency();
        Frequency.FinalValue = frequency;

        var waveFunc = GetWaveFunction(frequency);
        // WaveShape.FinalValue...

        OutSocket.OutputFunction = waveFunc;
    }

    private float GetFrequency()
    {
        return Frequency.Value * _sampleRate;
    }

    private Func<float, float> GetWaveFunction(float input)
    {
        // todo
        return (time) => Mathf.Sin(2 * Mathf.PI* input * time);
    }
}
