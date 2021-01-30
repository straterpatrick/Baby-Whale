using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControl : MonoBehaviour
{
    public int lookSensitivity = 10;
    public float movementSmoothingSpeed = 1f;
    private Vector3 rawInputMovement;
    private Vector3 smoothInputMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        CalculateMovementInputSmoothing();
        UpdatePlayerMovement();

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 inputMovement = context.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        transform.Rotate(0, value.x * lookSensitivity * Time.deltaTime, 0);
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        // Echolocate?
    }

    public void OnDive(InputAction.CallbackContext context)
    {
        Vector2 inputMovement = context.ReadValue<Vector2>();
        rawInputMovement = new Vector3(0, inputMovement.y, 0);
    }

    void CalculateMovementInputSmoothing()
    {
        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);
    }
    void UpdatePlayerMovement()
    {
        transform.Translate(smoothInputMovement);
    }
}
