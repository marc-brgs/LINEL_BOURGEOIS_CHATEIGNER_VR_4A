using UnityEngine;
using TMPro;

public class FPSDisplayer : MonoBehaviour
{
    public TextMeshProUGUI fpsText; // Référence au TextMeshProUGUI dans l'inspecteur d'Unity

    private float deltaTime;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = string.Format("{0:0.} FPS", fps);
    }
}