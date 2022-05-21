using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GunRotation : MonoBehaviour
{
    DefaultInputActions defaultInputActions;
    private Vector2 _lookInputVector;
    [SerializeField] float _sensitivity=1f;
    Vector3 _rotation;

    //private Vector2 mousePos;
    //[SerializeField] Camera cam;

    private void Awake()
    {
        //cam = Camera.main;
        defaultInputActions = new DefaultInputActions();
        defaultInputActions.Player.Enable();
    }

    private void Update()
    {
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        defaultInputActions.Player.Look.performed += Look_performed;
       
        
        

        
    }

    private void Look_performed(InputAction.CallbackContext context)
    {
        //_lookInputVector = context.ReadValue<Vector2>();
        
        
    }
}
