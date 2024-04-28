/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RTDK.LoadingScreen
{
    /// <summary>
    /// Handle an UI for loading with progress
    /// </summary>
    public class LoadingScreenUI : MonoBehaviour
    {
        [SerializeField]
        private Slider progressSlider;

        [SerializeField]
        private CanvasGroup loadingScreen;

        [SerializeField]
        private float fadeTime;

        private void OnEnable()
        {
            SceneLoader.Instance.onSceneLoadStart.AddListener(Show);
            SceneLoader.Instance.onSceneLoadUpdate.AddListener(UpdateProgress);
            SceneLoader.Instance.onSceneLoadEnd.AddListener(Hide);
        }

        private void OnDisable()
        {
            SceneLoader.Instance.onSceneLoadStart.RemoveListener(Show);
            SceneLoader.Instance.onSceneLoadUpdate.RemoveListener(UpdateProgress);
            SceneLoader.Instance.onSceneLoadEnd.RemoveListener(Hide);
        }

        private void Start()
        {
            Hide();
        }

        private void UpdateProgress(float value)
        {
            progressSlider.value = value;
        }

        private void Show()
        {
            StopAllCoroutines();
            StartCoroutine(FadeIn());
        }

        private void Hide()
        {
            StopAllCoroutines();
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float startAlpha, float endAlpha, float duration)
        {
            float timer = 0.0f;

            while (timer < duration)
            {
                timer += Time.deltaTime;
                float t = timer / duration;
                canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, t);
                yield return null;
            }

            canvasGroup.alpha = endAlpha;
        }

        private IEnumerator FadeIn()
        {
            loadingScreen.alpha = 0;
            yield return FadeCanvasGroup(loadingScreen, 0f, 1f, fadeTime);
            loadingScreen.blocksRaycasts = true;
        }

        private IEnumerator FadeOut()
        {
            loadingScreen.alpha = 0;
            yield return FadeCanvasGroup(loadingScreen, 1f, 0f, fadeTime);
            loadingScreen.blocksRaycasts = false;

        }
    }
}