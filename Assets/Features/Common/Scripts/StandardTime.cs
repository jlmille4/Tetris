using UnityEngine;
using System.Collections;


namespace gov.nasa.ksc.it.itacl.common
{
    public class StandardTime : ITime
    {
        public float DeltaTime
        {
            get { return Time.deltaTime; }
        }

        public float TimeSinceLevelLoad
        {
            get { return Time.timeSinceLevelLoad; }
        }
    }
}