/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;
using UnityEngine.Events;

namespace RTDK
{
    /// <summary>
    /// 
    /// </summary>
    public class TimerBase : MonoBehaviour
    {
        [SerializeField] protected float time;
        [SerializeField] protected bool startOnAwake = false;

        private bool isStarted;
        public bool IsStarted => isStarted;

        public UnityEvent<bool> onTimerStart;
        public UnityEvent onTimerFinish;

        protected float currentTime;

        private void Awake()
        {
            if (startOnAwake)
                StartTimer(true);
        }

        private void Update()
        {
            if (isStarted)
            {
                HandleTimer();
            }
        }

        /// <summary>
        /// If started it will executed every frame
        /// </summary>
        public virtual void HandleTimer()
        {
            //Not implemented
        }

        public virtual void StartTimer(bool resume = false)
        {
            isStarted = true;
            onTimerStart.Invoke(resume);
        }

        public void StopTimer()
        {
            isStarted = false;
        }

        public float GetCurrentTime() => currentTime;
    }
}