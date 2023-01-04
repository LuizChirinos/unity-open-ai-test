using OpenAI_API;
using System;
using UnityEngine;

public class OpenAIManager : MonoBehaviour
{
    const string API_KEY = "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";

    void Start()
    {
        CompleteAsync("A VRGlass é uma empresa fundada em 2011. A VRGlass trabalha com design, desenvolvimento e produção de apps e equipamentos de realidade virtual e aumentada para enterprise e varejo. O que é a VRGlass?");
    }

    private async void CompleteAsync(string message)
    {
        APIAuthentication auth = new APIAuthentication(API_KEY);
        OpenAIAPI api = new OpenAI_API.OpenAIAPI(auth, engine: Engine.Davinci);

        CompletionResult result = await api.Completions.CreateCompletionAsync(message, temperature: 0.1);
        Debug.Log(result.ToString());
        // should print something starting with "Three"
    }

}
