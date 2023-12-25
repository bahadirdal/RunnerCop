using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerSpawnerController playerSpawnerScript;
    private GameObject playerSpawnerGO;
    void Start()
    {
        playerSpawnerGO = GameObject.FindGameObjectWithTag("PlayerSpawner");
        playerSpawnerScript = playerSpawnerGO.GetComponent<PlayerSpawnerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerSpawnerScript.PlayerGotKilled(other.gameObject);
        }
    }
}
