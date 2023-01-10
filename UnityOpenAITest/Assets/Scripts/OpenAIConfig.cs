using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = nameof(OpenAIConfig), menuName = "ScriptableObjects/OpenAIConfig")]
public class OpenAIConfig : ScriptableObject
{
    public string engine;
    public string prompt;
    public float temperature;
}