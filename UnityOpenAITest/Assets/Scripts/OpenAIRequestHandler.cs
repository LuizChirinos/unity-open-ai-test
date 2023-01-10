using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class OpenAIRequestHandler : MonoBehaviour
{
    [SerializeField] private string url = "localhost:3000";
    [SerializeField] private OpenAIConfig openAIConfig;
    [SerializeField] private InputField inputField;
    [SerializeField] private Text resultText;
    [SerializeField] private Button buttonConfirm;

    void Start()
    {
        buttonConfirm.onClick.AddListener(CompleteText);
    }

    private void CompleteText()
    {
        StartCoroutine(CompleteRequest(inputField.text));
    }

    private IEnumerator CompleteRequest(string prompt)
    {
        UnityWebRequest www = UnityWebRequest.Get(url+"/createCompletion/");
        //Setting up config to Request
        var config = openAIConfig;
        config.prompt = prompt;
        var jsonData = JsonUtility.ToJson(openAIConfig);
        www.SetRequestHeader("config", jsonData);

        Debug.Log($"Sending request...");
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            var json = www.downloadHandler.text;
            var data = JsonUtility.FromJson<OpenAIResponse>(json);
            Debug.Log("OpenAI Request Response: " + data.result);
            resultText.text = data.result;
        }
    }

}
