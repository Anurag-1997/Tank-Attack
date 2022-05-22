using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GunRotation : MonoBehaviour
{
    DefaultInputActions defaultInputActions;
    private Vector2 _lookInputVector;
    [SerializeField] float _sensitivity=1f;
    Vector3 _targetDirection;
    float _lookAngle;

    private Vector3 _mousePos;
    [SerializeField] Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        defaultInputActions = new DefaultInputActions();
        defaultInputActions.Player.Enable();
    }

    private void Update()
    {
        defaultInputActions.Player.Look.performed += Look_performed;
        _lookInputVector = defaultInputActions.Player.Look.ReadValue<Vector2>();
        //_lookInputVector = Mouse.current.position.ReadValue();
        //_mousePos = cam.ScreenToWorldPoint(_lookInputVector);
        _targetDirection = Input.mousePosition - cam.WorldToScreenPoint(transform.position);
        _lookAngle = Mathf.Atan2(_targetDirection.y, _targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -90f)) * Quaternion.AngleAxis(_lookAngle, Vector3.forward);


        

       
        
        

        
    }

    private void Look_performed(InputAction.CallbackContext context)
    {
        //_lookInputVector = context.ReadValue<Vector2>();
        
        
    }
}
