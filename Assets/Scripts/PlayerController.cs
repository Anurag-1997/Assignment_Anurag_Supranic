using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    MyInputActions myInputActions;
    Vector2 moveVector;
    float moveX, moveZ, moveSpeed = 5f;
    private void Awake()
    {
        myInputActions = new MyInputActions();
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
        moveVector = myInputActions.Player.Moving.ReadValue<Vector2>();
        moveX = moveVector.x;
        moveZ = moveVector.y;
        this.gameObject.transform.position += new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
    }
}
