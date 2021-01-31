using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGoal : MonoBehaviour
{
    public GameObject GoalFish;
    public GameObject EnemyFish;
    public GameObject Distraction1;
    public GameObject Distraction2;
    public int SpawnDistance = 200;

    // Start is called before the first frame update
    void Start()
    {
        GameObject goal = Instantiate(GoalFish);
        GameObject enemy = Instantiate(EnemyFish);
        GameObject distract1 = Instantiate(Distraction1);
        GameObject distract2 = Instantiate(Distraction2);

        var player = GameObject.FindGameObjectWithTag("Player");
        Vector3 pp = player.transform.position;

        goal.transform.LookAt(Camera.main.transform);
        goal.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

        Vector3[] poslist = new Vector3[4];
        poslist[0] = new Vector3(pp.x + SpawnDistance, pp.y - 8, pp.z + SpawnDistance); //Random.Range(pp.y - 8, pp.y - 20)
        poslist[1] = new Vector3(pp.x + SpawnDistance, pp.y - 8, pp.z - SpawnDistance);
        poslist[2] = new Vector3(pp.x - SpawnDistance, pp.y - 8, pp.z + SpawnDistance);
        poslist[3] = new Vector3(pp.x - SpawnDistance, pp.y - 8, pp.z - SpawnDistance);
        
        for (int i = 0; i < poslist.Length - 1; i++)
        {
            int rnd = Random.Range(i, poslist.Length);
            var temppos = poslist[rnd];
            poslist[rnd] = poslist[i];
            poslist[i] = temppos;
        }

        goal.transform.position = poslist[0];
        enemy.transform.position = poslist[1];
        distract1.transform.position = poslist[2];
        distract2.transform.position = poslist[3];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
