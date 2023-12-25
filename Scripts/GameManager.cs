using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject MainPanel;
    public GameObject FailPanel;
    public GameObject SuccessPanel;
    public static GameManager instance; 

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonTapped()
    {
        MainPanel.gameObject.SetActive(false);
        GameObject playerSpawnerGO = GameObject.FindGameObjectWithTag("PlayerSpawner");
        PlayerSpawnerController playerSpawnerScript = playerSpawnerGO.GetComponent<PlayerSpawnerController>();
        playerSpawnerScript.movePlayer();

    }

    public void ShowFailPanel()
    {
        FailPanel.gameObject.SetActive(true);
    }

    public void RestartButtonTapped()
    {
        LevelLoader.instance.GetLevel();
    }

    public void ShowSuccessPanel()
    {
        SuccessPanel.gameObject.SetActive(true);
    }

    public void NextLevelButtonTapped()
    {
        LevelLoader.instance.NextLevel();
    }
}
