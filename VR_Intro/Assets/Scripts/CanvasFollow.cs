using UnityEngine;

public class CanvasFollow : MonoBehaviour
{
    public Transform cameraTransform;

    private void Update()
    {
        transform.rotation = cameraTransform.rotation;
    }
}