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
    public Rigidbody body;

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
        body.transform.Rotate(0, value.x * lookSensitivity * Time.deltaTime, 0);
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/BabyWhale/Whale_Whine");
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Goal");
        foreach (GameObject target in enemies)
        {
            target.GetComponent<GoalMain>().AnswerCall();
        }

    }

    public void OnDive(InputAction.CallbackContext context)
    {
        Vector2 inputMovement = context.ReadValue<Vector2>();
        rawInputMovement = new Vector3(0, inputMovement.y, 0);
    }

    public void OnExit(InputAction.CallbackContext context)
    {
        Application.Quit();
    }

    void CalculateMovementInputSmoothing()
    {
        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);
    }
    void UpdatePlayerMovement()
    {
        if (transform.position.y >= 45)
        {
            if (smoothInputMovement.y > 0)
            {
                body.transform.Translate(smoothInputMovement.x, 0, smoothInputMovement.z);
            }
            else
            {
                body.transform.Translate(smoothInputMovement.x, smoothInputMovement.y, smoothInputMovement.z);
            }
        }
        else if (transform.position.y < -200)
        {
            if (smoothInputMovement.y < 0)
            {
                body.transform.Translate(smoothInputMovement.x, 0, smoothInputMovement.z);
            }
            else
            {
                body.transform.Translate(smoothInputMovement.x, smoothInputMovement.y, smoothInputMovement.z);
            }
        }
        else
        {
            //body.MovePosition(smoothInputMovement);
            body.transform.Translate(smoothInputMovement);
        }
    }
}
