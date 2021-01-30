using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowHole : MonoBehaviour
{
    private int Oxygen = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.y >= 45)
        {
            Oxygen = 1;
        } else
        {
            Oxygen = 0;
        }
        var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("Oxygen", Oxygen);

    }
}
