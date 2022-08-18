using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    MyInputActions myInputActions;
    Vector2 moveVector;
    float moveX, moveZ;
    public float moveSpeed = 5f,jumpForce = 5f;
    Rigidbody rb;
    public LayerMask groundLayer;
    bool isGrounded = false;
    public Transform feetPosition;
    private void Awake()
    {
        myInputActions = new MyInputActions();
        rb = this.GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        myInputActions.Enable();
    }
    private void OnDisable()
    {
        myInputActions.Disable();
    }
    private void Update()
    {
        Moving();
        Debug.DrawRay(feetPosition.position, Vector3.down * 0.1f, Color.cyan);
        isGrounded = Physics.Raycast(feetPosition.position, Vector3.down, 0.1f, groundLayer.value);
        myInputActions.Player.Jumping.performed += Jumping_performed;
    }

    private void Jumping_performed(InputAction.CallbackContext obj)
    {
        if(isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
       
    }

    private void Moving()
    {
        moveVector = myInputActions.Player.Moving.ReadValue<Vector2>();
        moveX = moveVector.x;
        moveZ = moveVector.y;
        this.gameObject.transform.position += new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
    }
}
