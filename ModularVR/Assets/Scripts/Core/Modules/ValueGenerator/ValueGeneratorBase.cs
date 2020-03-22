using Assets.Scripts.Core.Input;
using Assets.Scripts.Core.Socket;
using UnityEngine;

namespace Assets.Scripts.Core.Modules.ValueGenerator
{
    public class ValueGeneratorBase<T> : MonoBehaviour
    {
        public ISocket SocketIn;
        public Knob InKnob;
        public Knob ModifierKnob;
        public T Value;
    }
}
