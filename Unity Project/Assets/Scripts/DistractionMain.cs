using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionMain : MonoBehaviour
{
    public float Speed = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + Speed * Time.deltaTime, 0);
        transform.position += transform.forward * Time.deltaTime * Speed;
    }
}
