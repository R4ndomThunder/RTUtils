/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using RTDK.InspectorPlus;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RTDK.UIScene
{
    /// <summary>
    /// Load and/or unload a scene where you have all your in-game UI
    /// </summary>
    [AddComponentMenu("UILoader")]
    public class UILoader : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private string uiSceneName;
        [SerializeField]
        private string uiScenePath;
        #endregion


        #region Lifecycle
        void Start()
        {
            LoadUI();
        }
        #endregion


        #region Public API
        [Button("Load UI", 24)]
        public void LoadUI()
        {
            if (SceneManager.GetSceneByName(uiSceneName).isLoaded)
                return;

            if (Application.isPlaying)
                SceneManager.LoadSceneAsync(uiSceneName, LoadSceneMode.Additive);
#if UNITY_EDITOR
            else
                EditorSceneManager.OpenScene($"{uiScenePath}/{uiSceneName}.unity", OpenSceneMode.Additive);
#endif
        }

        [Button("Unload UI", 24)]
        public void UnloadUI()
        {
            if (!SceneManager.GetSceneByName(uiSceneName).isLoaded)
                return;

            if (Application.isPlaying)
                SceneManager.UnloadSceneAsync(uiSceneName);
#if UNITY_EDITOR
            else
                EditorSceneManager.CloseScene(EditorSceneManager.GetSceneByName(uiSceneName), true);
#endif
        }
        #endregion
    }

}