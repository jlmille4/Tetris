using UnityEngine;
using System.Collections;

namespace gov.nasa.ksc.it.itacl.common
{
    public interface ITime
    {
        float DeltaTime { get; }
        float TimeSinceLevelLoaded { get; }
    }
}