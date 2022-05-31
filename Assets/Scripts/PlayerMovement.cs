using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D tankRigidbody;
    [SerializeField] float speed = 5f;
    //PlayerInputActions playerInputActions;
    DefaultInputActions defaultInputActions;
    public Vector2 inputVector;



    private void Awake()
    {
        tankRigidbody = GetComponent<Rigidbody2D>();
        defaultInputActions = new DefaultInputActions();
        defaultInputActions.Player.Enable();
        //playerInputActions.Player.Movement.performed += Movement_performed;
    }
    private void Update()
    {
        inputVector = defaultInputActions.Player.Move.ReadValue<Vector2>();
        //tankRigidbody.AddForce(inputVector * speed, ForceMode2D.Force);
        this.gameObject.transform.Translate(inputVector.x * speed * Time.deltaTime, inputVector.y * speed * Time.deltaTime, 0);
    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Movement " + context);
       
        
        
    }

        

}
