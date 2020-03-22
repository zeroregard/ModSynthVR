using Assets.Scripts.Core.Socket;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public static class AudioSettings
//{
//    public static float SampleRateHz = 44100;
//}

[RequireComponent(typeof(AudioSource))]
public class Speaker : MonoBehaviour
{

    private float _sampleRate;
    private int _timeIndex = 0;
    public FloatSocket InSocket;

    private void Awake()
    {
        _sampleRate = AudioSettings.outputSampleRate;
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        for (int i = 0; i < data.Length; i += channels)
        {
            data[i] = GetDataPoint(_timeIndex);

            if (channels == 2)
                data[i + 1] = data[i];

            _timeIndex++;
        }
    }

    private float GetDataPoint(int timeIndex)
    {
        if (InSocket.OutputFunction == null)
            return 0;
        return InSocket.OutputFunction(timeIndex/_sampleRate);
    }
}
