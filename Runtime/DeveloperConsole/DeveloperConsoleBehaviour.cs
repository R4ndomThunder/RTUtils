/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using TMPro;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace RTDK.DeveloperConsole
{
    /// <summary>
    /// 
    /// </summary>
    [AddComponentMenu("DeveloperConsoleBehaviour")]
    public class DeveloperConsoleBehaviour : MonoBehaviour
    {
        #region Fields
        [SerializeField] private string prefix = string.Empty;
        [SerializeField] private ConsoleCommand[] commands = new ConsoleCommand[0];

        [Header("UI")]
        [SerializeField] private GameObject uiCanvas = null;
        [SerializeField] private TMP_InputField inputField = null;

        private float pausedTimeScale;

        private static DeveloperConsoleBehaviour instance;
        private DeveloperConsole developerConsole;
        private DeveloperConsole DeveloperConsole
        {
            get
            {
                if (developerConsole != null) return developerConsole;
                return developerConsole = new DeveloperConsole(prefix, commands);
            }
        }
        #endregion


        #region Lifecycle
        void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;

            DontDestroyOnLoad(gameObject);
        }

        void Start() { }
        void Update() { }
        #endregion

        public void Toggle(CallbackContext ctx)
        {
            if (!ctx.action.triggered) return;

            if (uiCanvas.activeSelf)
            {
                Time.timeScale = pausedTimeScale;
                uiCanvas.SetActive(false);
            }
            else
            {
                pausedTimeScale = Time.timeScale;
                Time.timeScale = 0;
                uiCanvas.SetActive(true);
                inputField.ActivateInputField();
            }
        }

        public void ProcessCommand(string inputValue)
        {
            DeveloperConsole.ProcessCommand(inputValue);

            inputField.text = string.Empty;
        }
    }

}