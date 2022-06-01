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
    [SerializeField] Camera cam;
    Vector3 offset;



    private void Awake()
    {
        tankRigidbody = GetComponent<Rigidbody2D>();
        defaultInputActions = new DefaultInputActions();
        defaultInputActions.Player.Enable();
        cam = Camera.main;
        //playerInputActions.Player.Movement.performed += Movement_performed;
    }
    private void Start()
    {
        offset = cam.transform.position - transform.position;
    }
    private void Update()
    {
        Move();

        cam.transform.position = transform.position + offset;

    }

    private void Move()
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
