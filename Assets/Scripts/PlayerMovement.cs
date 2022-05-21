using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D tankRigidbody;
    [SerializeField] float speed = 5f;
    PlayerInputActions playerInputActions;



    private void Awake()
    {
        tankRigidbody = GetComponent<Rigidbody2D>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        //playerInputActions.Player.Movement.performed += Movement_performed;
    }
    private void Update()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        //tankRigidbody.AddForce(inputVector * speed, ForceMode2D.Force);
        this.gameObject.transform.Translate(inputVector.x * speed * Time.deltaTime, inputVector.y * speed * Time.deltaTime, 0);
    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Movement " + context);
       
        
        
    }

        

}
