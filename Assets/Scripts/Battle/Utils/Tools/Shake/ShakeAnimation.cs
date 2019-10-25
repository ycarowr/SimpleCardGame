using UnityEngine;

namespace Tools
{
    /// <summary>
    ///     Ref:https://gist.github.com/ftvs/5822103
    ///     Monobehavior used to shake an GameObject through it's Transform. All the variables are set with the Editor.
    ///     If you need global access to this class you can just inherit it from a SingletonMB instead.
    /// </summary>
    public class ShakeAnimation : MonoBehaviour
    {
        [Tooltip("How big are the width and height of the shake.")] [SerializeField]
        readonly float amplitude = 0;

        [Tooltip("Duration of the shake in seconds")] [SerializeField]
        readonly float duration = 0;

        [Tooltip("How often the shake happens during its own duration. Value has to be smaller than the duration.")]
        [SerializeField]
        readonly float frequency = 0;

        [Tooltip("Transform that has to be shaken")] [SerializeField]
        Transform cachedTransform;

        //initial position
        Vector3 originalPosition;

        [field: Tooltip("whether the object is shaking or not.")]
        public bool IsShaking { get; private set; }

        float CounterFrequency { get; set; }
        float CounterDuration { get; set; }

        void Awake() => cachedTransform = transform;

        /// <summary>
        ///     Method which starts the shake movement.
        /// </summary>
        public void Shake()
        {
            if (IsShaking)
                return;

            originalPosition = cachedTransform.position;
            IsShaking = true;
        }

        /// <summary>
        ///     Clear all the shake counters.
        /// </summary>
        void ResetCounters()
        {
            CounterDuration = 0;
            CounterFrequency = 0;
        }

        /// <summary>
        ///     Clear the shake instantly.
        /// </summary>
        public void StopShaking()
        {
            IsShaking = false;
            cachedTransform.localPosition = originalPosition;
            ResetCounters();
        }

        /// <summary>
        ///     Shake only works during play mode
        /// </summary>
        void Update()
        {
            if (!IsShaking) return;

            var deltaTime = Time.deltaTime;

            //increment duration
            CounterDuration += deltaTime;
            if (CounterDuration >= duration)
            {
                StopShaking();
            }
            else
            {
                //increment frequency
                if (CounterFrequency < frequency)
                {
                    CounterFrequency += deltaTime;
                }
                else
                {
                    //move the object somewhere inside the amplitude
                    cachedTransform.localPosition = originalPosition + Random.insideUnitSphere * amplitude;

                    //reset frequency
                    CounterFrequency = 0;
                }
            }
        }
    }
}