/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using RTDK.Utility;

namespace RTDK
{
    /// <summary>
    /// 
    /// </summary>
    public class HTTPService
    {
        public static HTTPService client = new HTTPService();

        public async Task<TResultType> Get<TResultType>(string url, string authHeaderName = null, string authHeaderValue = null)
        {
            using var www = UnityWebRequest.Get(url);

            if (authHeaderName != null && authHeaderValue != null)
                www.SetRequestHeader(authHeaderName, authHeaderValue);

            www.SetRequestHeader("Content-Type", "application/json");

            var operation = www.SendWebRequest();

            while (!operation.isDone)
                await Task.Yield();

            var jsonResponse = www.downloadHandler.text;
            if (www.result != UnityWebRequest.Result.Success)
                Debug.LogError($"Failed: {www.error}");

            try
            {
                var result = JsonConvert.DeserializeObject<TResultType>(jsonResponse);
                Debug.Log($"Success {www.downloadHandler.text}");
                return result;
            }
            catch (Exception ex)
            {
                Debug.LogError($"{this} could not parse response {jsonResponse}.\n{ex.Message}");
                return default;
            }
        }

        public async Task<TResultType> Post<TResultType>(string url, string body, string contentType = "application/json", string authHeaderName = null, string authHeaderValue = null)
        {
            Debug.Log($"[Post] ~ url: {url} \nbody: {body}");
            using var www = UnityWebRequest.Post($"{url}", body, contentType);

            if (authHeaderName != null && authHeaderValue != null)
                www.SetRequestHeader(authHeaderName, authHeaderValue);

            www.SetRequestHeader("Content-Type", contentType);

            var operation = www.SendWebRequest();

            while (!operation.isDone)
                await Task.Yield();

            var jsonResponse = www.downloadHandler.text;
            if (www.result != UnityWebRequest.Result.Success)
                Debug.LogError($"Failed: {www.error}");

            try
            {
                if (jsonResponse.IsNullOrEmpty()) return default;

                var result = JsonConvert.DeserializeObject<TResultType>(jsonResponse);
                Debug.Log($"Success: {www.downloadHandler.text}");
                return result;
            }
            catch (Exception ex)
            {
                Debug.LogError($"{this} could not parse response {jsonResponse}.\n{ex.Message}");
                return default;
            }
        }

        public async Task<TResultType> Patch<TResultType>(string url, string body, string contentType = "application/json", string authHeaderName = null, string authHeaderValue = null)
        {
            Debug.Log($"[Patch] ~ {url}");

            using var www = UnityWebRequest.Put($"{url}", body);

            if (authHeaderName != null && authHeaderValue != null)
                www.SetRequestHeader(authHeaderName, authHeaderValue);

            www.SetRequestHeader("Content-Type", contentType);

            var operation = www.SendWebRequest();

            while (!operation.isDone)
                await Task.Yield();

            var jsonResponse = www.downloadHandler.text;
            if (www.result != UnityWebRequest.Result.Success)
                Debug.LogError($"Failed: {www.error}");

            try
            {
                var result = JsonConvert.DeserializeObject<TResultType>(jsonResponse);
                Debug.Log($"Success: {www.downloadHandler.text}");
                return result;
            }
            catch (Exception ex)
            {
                Debug.LogError($"{this} could not parse response {jsonResponse}.\n{ex.Message}");
                return default;
            }
        }
    }
}