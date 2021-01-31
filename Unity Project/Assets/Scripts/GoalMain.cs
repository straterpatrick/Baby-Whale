using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMain : MonoBehaviour
{
    public float Speed = 5;
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

    public void AnswerCall()
    {
        StartCoroutine(Call());
    }

    IEnumerator Call()
    {
        yield return new WaitForSeconds(4f);
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/PodWhine");
    }
}
