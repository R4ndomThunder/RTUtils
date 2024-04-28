/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RTDK.MainMenu
{
    /// <summary>
    /// 
    /// </summary>
    public class MainMenuBase : MonoBehaviour
    {
        [SerializeField]
        internal InputActionReference backButton;

        [SerializeField]
        internal List<GameObject> views = new();

        [SerializeField]
        internal Stack<GameObject> visitedViews = new();

        private void OnCancel(InputAction.CallbackContext context)
        {
            if (!context.action.WasPressedThisFrame()) return;

            CloseView();
        }

        void Start()
        {
            backButton.action.performed += OnCancel;
            OpenView(views.First());
        }

        private void OnDestroy()
        {
            backButton.action.performed -= OnCancel;
        }

        public virtual void OpenView(GameObject view)
        {
            visitedViews.Push(view);
            ShowView(view);
        }

        internal virtual void ShowQuitModal()
        {
            //Not Implemented
        }

        internal virtual void CloseView()
        {
            if (visitedViews.Count > 1)
            {
                var v = visitedViews.Pop();
                ShowView(v);
            }
            else
            {
                ShowQuitModal();
            }
        }

        internal virtual void ShowView(GameObject view)
        {
            foreach (var v in views)
            {
                view.SetActive(v == view);
            }
        }

        public virtual void QuitBtn()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
            Application.OpenURL(webplayerQuitURL);
#else
            Application.Quit();
#endif
        }
    }
}