using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{

    public GameObject SpawnedFish;
    public float RespawnTimer = 1f;
    public int MaxFish = 20;
    private int School = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SchoolFish());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NewFish()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        GameObject fish = Instantiate(SpawnedFish);
        School++;
        Vector3 pp = player.transform.position;
        fish.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        fish.transform.position = new Vector3(Random.Range(pp.x + 100, pp.x - 100), Random.Range(pp.y + 50, pp.y - 50), pp.z + 100);
    }

    public void RemoveFish()
    {
        School--;
    }

    IEnumerator SchoolFish()
    {
        while (true)
        {
            yield return new WaitForSeconds(RespawnTimer);
            if(School <= MaxFish)
            {
               NewFish();
            }
        }
    }
}
