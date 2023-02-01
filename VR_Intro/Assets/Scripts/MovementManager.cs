using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementManager : MonoBehaviour
{

    [SerializeField] private InputActionAsset actionAsset;
    private InputAction thumbstick;
    private InputAction head;

    // Start is called before the first frame update
    void Start()
    {
        thumbstick = actionAsset.FindActionMap("XRI LeftHand").FindAction("Move");
        thumbstick.Enable();
        
        head = actionAsset.FindActionMap("XRI Head").FindAction("Rotation");
        head.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
