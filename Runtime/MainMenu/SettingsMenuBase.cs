/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;
using UnityEngine.Audio;
using System.Linq;

namespace RTDK.MainMenu
{
    public abstract class SettingsMenuBase : MonoBehaviour
    {
        public AudioMixer audioMixer;

        #region Audio Settings
        public virtual void SetSfxVolume(float vol)
        {
            audioMixer.SetFloat("SFX", Mathf.Log10(vol));
        }

        public virtual float GetSfxVolume()
        {
            audioMixer.GetFloat("SFX", out float vol);
            return vol;
        }

        public virtual void SetOSTVolume(float vol)
        {
            audioMixer.SetFloat("OST", Mathf.Log10(vol));
        }

        public virtual float GetOSTVolume()
        {
            audioMixer.GetFloat("OST", out float vol);
            return vol;
        }

        public virtual void SetMasterVolume(float vol)
        {
            audioMixer.SetFloat("Master", Mathf.Log10(vol));
        }

        public virtual float GetMasterVolume()
        {
            audioMixer.GetFloat("Master", out float vol);
            return vol;
        }
        #endregion

        #region Graphics Settings
        public virtual void SetQualityPreset(int quality)
        {
            QualitySettings.SetQualityLevel(quality);
        }

        public virtual int GetQualityLevel() => QualitySettings.GetQualityLevel();

        public virtual void SetResolution(int selectedRes)
        {
            var selRes = Screen.resolutions[selectedRes];
            Screen.SetResolution(selRes.width, selRes.width, Screen.fullScreenMode);
        }

        public virtual int GetCurrentResolutionIndex() => Screen.resolutions.ToList().IndexOf(Screen.currentResolution);

        public virtual void SetFullscreenMode(int fullscreenMode)
        {
            Screen.fullScreenMode = (FullScreenMode)fullscreenMode;
        }

        public virtual int GetFullscreenMode() => (int)Screen.fullScreenMode;

        public virtual void SetBrightness(float brightness)
        {
            Screen.brightness = brightness;
        }

        public virtual float GetBrightness() => Screen.brightness;

        public virtual void SetVSync(int frameToSync)
        {
            QualitySettings.vSyncCount = frameToSync;
        }

        public virtual int GetVSync() => QualitySettings.vSyncCount;

        public virtual void SetAntiAliasing(int aaLevel)
        {
            QualitySettings.antiAliasing = aaLevel;
        }

        public virtual int GetAntiAliasing() => QualitySettings.antiAliasing;

        public virtual void SetTextureQuality(int textureQuality)
        {
            QualitySettings.globalTextureMipmapLimit = textureQuality;
        }

        public virtual int GetTextureQuality() => QualitySettings.globalTextureMipmapLimit;

        public virtual void SetShadowResolution(int shadowQuality)
        {
            QualitySettings.shadowResolution = (ShadowResolution)shadowQuality;
        }

        public virtual int GetShadowResolution() => (int)QualitySettings.shadowResolution;
        #endregion

        #region Controls Settings

        #endregion
    }
}
