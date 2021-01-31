using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private GameObject player;
    private FMODUnity.StudioEventEmitter emitter;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        emitter.SetParameter("Oxygen", Mathf.Max(player.GetComponent<PlayerMain>().Oxygen, 1));

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject target in enemies)
        {
            var distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance < 100)
            {
                emitter.SetParameter("Danger", (100 - distance)/100);
            }

        }

    }
}
