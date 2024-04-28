/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using TMPro;
using UnityEngine;

namespace RTDK
{
    /// <summary>
    /// 
    /// </summary>
    public class TimerUIBase : MonoBehaviour
    {
        [SerializeField]
        protected TimerBase timerToShow;

        [SerializeField]
        protected TextMeshProUGUI timerText;

        [SerializeField]
        internal bool hideOnTimerFinish = true;

        private void Start()
        {
            if (hideOnTimerFinish)
                timerToShow.onTimerFinish.AddListener(HideTimer);
        }

        private void Update()
        {
            ShowTimer();
        }

        public virtual void ShowTimer()
        {

        }

        public virtual void HideTimer()
        {
            timerText.gameObject.SetActive(false);
        }
    }
}