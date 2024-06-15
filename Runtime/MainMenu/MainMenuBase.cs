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
    public abstract class MainMenuBase : MonoBehaviour
    {
        [SerializeField]
        internal InputActionReference backButton;

        [SerializeField]
        internal List<MenuViewBase> views = new();

        [SerializeField]
        internal Stack<MenuViewBase> visitedViews = new();

        private void OnCancel(InputAction.CallbackContext context)
        {
            if (!context.action.WasPressedThisFrame()) return;
            Cancel();
            CloseView();
        }

        public virtual void Start()
        {
            backButton.action.performed += OnCancel;
            OpenView(views.FirstOrDefault());
        }

        public virtual void OnDestroy()
        {
            backButton.action.performed -= OnCancel;
        }

        public virtual void Cancel()
        {

        }

        public virtual void OpenView(MenuViewBase view)
        {
            if (view == null) return;

            visitedViews.Push(view);
            ShowView(view);
        }

        public virtual void ShowQuitModal()
        {
            QuitBtn();
        }

        public virtual void OpenURL(string url)
        {
            Application.OpenURL(url);
        }

        public virtual void CloseView()
        {
            if (visitedViews.Count > 1)
            {
                visitedViews.Pop();
                var v = visitedViews.Peek();
                ShowView(v);
            }
            else
            {
                ShowQuitModal();
            }
        }

        public virtual void ShowView(MenuViewBase view)
        {
            foreach (var v in views)
            {
                v.gameObject.SetActive(v == view);
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