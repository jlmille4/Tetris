using UnityEngine;
using System.Collections;

namespace gov.nasa.ksc.it.itacl.common
{
    public class StandardInput : MonoBehaviour, IInput
    {
        public float GetAxis(string axis)
        {
            return Input.GetAxis(axis);
        }
    }
}
