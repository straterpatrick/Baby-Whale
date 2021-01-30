using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidFish : MonoBehaviour
{
    public int Speed = 50;
    public int Noticedistance = 30;
    public int StartleDistance = 200;
    private bool Noticed = false;
    private Vector3 FleeDirection;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        var cameraDist = Vector3.Distance(Camera.main.transform.position, transform.position);

        if (cameraDist < Noticedistance)
        {
            Noticed = true;

        }

        if (Noticed)
        {
            //transform.LookAt(Camera.main.transform);
            // var targetRotation = Quaternion.LookRotation(Camera.main.transform.position - transform.position); // fish spin
            var targetRotation = Quaternion.LookRotation(Camera.main.transform.position + transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, (Speed/10) * Time.deltaTime);
            transform.Translate(FleeDirection * Speed * Time.deltaTime);
            transform.position += transform.forward * Time.deltaTime * Speed;
        }

        if (cameraDist > StartleDistance)
        {
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnFish>();
            player.RemoveFish();
            Destroy(gameObject);
        }

    }

}
