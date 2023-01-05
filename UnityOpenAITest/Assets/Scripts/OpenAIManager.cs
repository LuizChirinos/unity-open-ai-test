using OpenAI_API;
using System;
using UnityEngine;
using UnityEngine.UI;

public class OpenAIManager : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private Text resultText;
    [SerializeField] private Button buttonConfirm;
    const string API_KEY = "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";

    void Start()
    {
        buttonConfirm.onClick.AddListener(CompleteText);
    }

    private void CompleteText()
    {
        CompleteAsync(inputField.text);
    }

    private async void CompleteAsync(string message)
    {
        APIAuthentication auth = new APIAuthentication(API_KEY);
        OpenAIAPI api = new OpenAI_API.OpenAIAPI(auth, engine: Engine.Davinci);

        CompletionResult result = await api.Completions.CreateCompletionAsync(message, temperature: 0.1);
        resultText.text = result.ToString();
        // should print something starting with "Three"
    }

}
