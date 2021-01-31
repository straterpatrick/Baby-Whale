using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{

    public Text Oxy;
    public Text Depth;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Oxy.text = player.GetComponent<PlayerMain>().Oxygen.ToString();
        Depth.text = "" + Mathf.RoundToInt(45 - player.transform.position.y);
    }
}
