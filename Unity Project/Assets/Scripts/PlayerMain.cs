using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{

    public int Oxygen = 100;
    public int Exertion = 1;
    public int FoundFamily = 0;
    public int FamilyGoal = 5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Live());
    }

    // Update is called once per frame
    void Update()
    {
        
        float AtSurface;

        if (transform.position.y > 30)
        {
            AtSurface = (transform.position.y - 30) / 15;
            Debug.Log(AtSurface);
        }
        else
        {
            AtSurface = 0;
        }

        if (transform.position.y >= 45)
        {
            TakeBreath();
        }


        var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("Oxygen", Oxygen);
        emitter.SetParameter("AmbienceChange", AtSurface);

    }

    private void TakeBreath()
    {
        Oxygen = 100;
    }
    public void loseBreath(int hit)
    {
        if (Oxygen > 0) {
            Oxygen = Oxygen - hit;
        } else
        {
            // Force to surface?
        }
    }
    IEnumerator Live()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            loseBreath(Exertion);
        }
    }
}
