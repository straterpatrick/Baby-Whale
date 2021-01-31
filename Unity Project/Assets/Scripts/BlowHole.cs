using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowHole : MonoBehaviour
{

    private float previousPosition = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.y >= 45 && previousPosition < transform.position.y)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/BabyWhale/Blowhole");
        }
        previousPosition = transform.position.y;
    }
}
