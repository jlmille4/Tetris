using UnityEngine;
using System.Collections;

namespace gov.nasa.ksc.it.itacl.common
{
    public class GameTime : MonoBehaviour, IPlayableTime, IRequireTime
    {
        public float DeltaTime
        {
            get
            {
                return deltaTime;
            }
        }

        public float TimeSinceLevelLoad
        {
            get
            {
                return timeSinceLevelLoaded;
            }
        }

        public bool IsPlaying
        {
            get
            {
                return isPlaying;
            }
        }

        public ITime Time
        {
            set
            {
                time = value;
            }
        }

        private float deltaTime = 0;
        private float timeSinceLevelLoaded = 0;
        private bool isPlaying = true;
        private ITime time = null;

        public void Play()
        {
            isPlaying = true;
        }

        public void Pause()
        {
            isPlaying = false;
        }

        private void Start()
        {
            deltaTime = 0;
            timeSinceLevelLoaded = 0;
            isPlaying = true;
        }

        public void Update()
        {
            if (isPlaying)
            {
                deltaTime = time.DeltaTime;
                timeSinceLevelLoaded += deltaTime;
            }
            else
            {
                deltaTime = 0;
            }
        }
    }
}
