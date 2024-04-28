/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
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

        [SerializeField] private InputActionReference consoleToggleInput;
        [SerializeField] private InputActionReference consoleSendCommandInput;

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

        bool isShowing = false;

        Queue<string> logQueue = new Queue<string>();

        string input = string.Empty;
        Vector2 scroll;
        #endregion

        #region UNITY METHOD
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

        private void Start()
        {
            consoleToggleInput.action.performed += OnConsoleToggle;
            consoleSendCommandInput.action.performed += OnSendCommand;

            Application.logMessageReceived += HandleLog;
        }

        private void OnDestroy()
        {
            consoleToggleInput.action.performed -= OnConsoleToggle;
            consoleSendCommandInput.action.performed -= OnSendCommand;

            Application.logMessageReceived -= HandleLog;
        }

        private void OnGUI()
        {
            if (!isShowing) return;

            float y = 0;

            GUI.Box(new Rect(0, y, Screen.width, 100), "");
            Rect viewport = new Rect(0, 0, Screen.width - 30, Screen.height / 4);
            scroll = GUI.BeginScrollView(new Rect(0, y + 5f, Screen.width, 90), scroll, viewport);

            int i = 0;
            foreach (var log in logQueue)
            {
                Rect labelRect = new Rect(5, 20 * i, viewport.width - 100, 20);
                GUI.Label(labelRect, log.ToString());
                i++;
            }

            GUI.EndScrollView();

            y += 100;

            GUI.Box(new Rect(0, y, Screen.width, 30), "");
            GUI.backgroundColor = new Color(0, 0, 0, 0);
            GUI.SetNextControlName("CommandInput");
            input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
            GUI.FocusControl("CommandInput");
        }

        #endregion

        public void OnConsoleToggle(CallbackContext ctx)
        {
            isShowing = !isShowing;
        }

        public void OnSendCommand(CallbackContext ctx)
        {
            if (isShowing)
            {
                ProcessCommand(input);
            }
        }

        public void ProcessCommand(string inputValue)
        {
            DeveloperConsole.ProcessCommand(inputValue);

            input = string.Empty;
        }

        void HandleLog(string logString, string stackTrace, LogType type)
        {
            string logToEnqueue = $"[{type}]: {logString}";

            if (type == LogType.Exception)
            {
                logToEnqueue += $"\n{stackTrace}";
            }

            logQueue.Enqueue(logToEnqueue);
        }
    }
}