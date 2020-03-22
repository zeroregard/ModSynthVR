using Assets.Scripts.Core.Input;
using Assets.Scripts.Core.Socket;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Core.Modules.ValueGenerator
{
    public class FloatGenerator : MonoBehaviour // : ValueGeneratorBase<float> // how to handle ISocket<float> with serialization?
    {
        public FloatSocket SocketIn;
        public Knob InKnob;
        public Knob ModifierKnob;
        public float Value;
        public float FinalValue; // todo: this needs to be a separate monobehavior that can take in anything

        private void Update()
        {
            CalculateValue();
        }

        private void CalculateValue()
        {
            var socketInValue = SocketIn.OutputFunction != null ? SocketIn.OutputFunction(Time.time) : 0; // 0..1
            var socketInWeightedValue = socketInValue * InKnob.Value; // -1..1
            var modifierValue = ModifierKnob.Value; // 0..1
            Value = Mathf.Clamp(modifierValue + socketInWeightedValue, 0, 1);
        }

        private void OnDrawGizmos()
        {
            Handles.Label(ModifierKnob.transform.position, FinalValue.ToString());
        }
    }
}
