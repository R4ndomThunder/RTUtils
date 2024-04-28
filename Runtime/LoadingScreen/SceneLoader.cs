/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using RTDK.Utility;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace RTDK.LoadingScreen
{
    /// <summary>
    /// Handle all scene loading logic
    /// </summary>
    public class SceneLoader : Singleton<SceneLoader>
    {
        public UnityEvent onSceneLoadStart;
        public UnityEvent onSceneLoadEnd;
        public UnityEvent<float> onSceneLoadUpdate;

        public void LoadScene(string sceneName)
        {
            StopAllCoroutines();
            StartCoroutine(LoadSceneCoroutine(sceneName));
        }

        IEnumerator LoadSceneCoroutine(string sceneName)
        {
            onSceneLoadStart.Invoke();

            var asyncOp = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncOp.isDone)
            {
                onSceneLoadUpdate.Invoke(asyncOp.progress);
                yield return null;
            }

            onSceneLoadEnd.Invoke();
        }
    }
}