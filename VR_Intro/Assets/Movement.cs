using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Movement : MonoBehaviour
{
    public XRNode inputSource;

    private Vector2 intputAxis;
    private CharacterController character;

    [SerializeField] private float speed = 1f;

    private void Start()
    {
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out intputAxis);
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(intputAxis.x, 0, intputAxis.y);
        character.Move(direction * speed * Time.deltaTime);
    }
}
