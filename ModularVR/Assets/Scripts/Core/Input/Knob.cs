using UnityEngine;

namespace Assets.Scripts.Core.Input
{
    public class Knob : MonoBehaviour
    {
        public float Min = 0;
        public float Max = 1;
        public float Delta = 0.5f;
        public float Value => Mathf.Lerp(Min, Max, Delta);
        public PhysicalKnobRenderer KnobRenderer; // todo: interface

        void Update()
        {
            KnobRenderer.Render(Delta);
        }
    }
}
