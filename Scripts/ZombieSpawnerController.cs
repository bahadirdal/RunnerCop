using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zombieGO;
    public int zombieCount = 0;
    public List<GameObject> zombieList = new List<GameObject>();
    public GameObject playerSpawnerGO;
    public PlayerSpawnerController playerSpawnerScript;
    public bool isZombieAttacking;
    void Start()
    {
        SpawnZombies();
        
    }
    private void Awake()
    {
        playerSpawnerGO = GameObject.FindGameObjectWithTag("PlayerSpawner");
        playerSpawnerScript = playerSpawnerGO.GetComponent<PlayerSpawnerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpawnZombies()
    {

        for (int i = 0; i < zombieCount; i++)
        {
            Quaternion zombieRotation = Quaternion.Euler(new Vector3(0, 180, 0));
            GameObject zombie = Instantiate(zombieGO, GetZombiePosition(), zombieRotation, transform);
            // Quaternion.identit; yeni oluþturulan nesnenin herhangi bir açýda dönük olmadan varsayýlan olarak hizalanmasýný saðlar. Rotasyon deðerlerini sýfýrlayarak bunu gerçekleþtirir.
            ZombieController zombieScript = zombie.GetComponent<ZombieController>();
            zombieScript.playerSpawnerGO = playerSpawnerGO;
            zombieScript.zombieSpawnerScript = this;

            zombieList.Add(zombie);
        }

    }


    public Vector3 GetZombiePosition()
    {
        Vector3 pos = Random.insideUnitSphere * 0.1f;
        Vector3 newPos = transform.position + pos;
        return newPos;
    }

    private void OnTriggerEnter(Collider other) // boxCollider'ýmýza herhangi bir þey geldiðinde bu blok çalýþacak.
    {
        if (other.tag == "Player")
        {
            GetComponent<BoxCollider>().enabled = false;
            playerSpawnerScript.ZombieDetected(gameObject);
            LookAtPlayers(other.gameObject);
            isZombieAttacking = true;
            // zombiler playerler'a dönecek, bakacak.
        }
    }

    private void LookAtPlayers(GameObject target)
    {
        Vector3 dir = transform.position - target.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        lookRotation.x = 0;
        lookRotation.z = 0;
        transform.rotation = lookRotation; 
    }

    public void ZombieAttackThisCop(GameObject player, GameObject zombie)
    {
        zombieList.Remove(zombie);   
        CheckZombieCount();
        playerSpawnerScript.PlayerGotKilled(player);
        Destroy(zombie);
    }


    private void CheckZombieCount()
    {
        if (zombieList.Count <= 0 )
        {
            playerSpawnerScript.AllZombiesKilled();
            // bütün zombiler öldü.
        }
    }

    public void ZombieGotShoot(GameObject zombie)
    {
        zombieList.Remove(zombie);
        Destroy(zombie); // zombiyi ekrandan siliyoruz. 
        CheckZombieCount();
    }
}

       
