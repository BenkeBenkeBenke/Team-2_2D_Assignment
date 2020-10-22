using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 respawnLocation;
    private PlayerStats _playerStats;

    // Start is called before the first frame update
    void Start()
    {
        //respawnLocation = gameObject.transform.position;
        _playerStats = gameObject.GetComponent<PlayerStats>();
    }

    public void SetActiveCheckpoint(GameObject newCheckpoint)
    {
        respawnLocation = newCheckpoint.transform.position;
        _playerStats.PlaceToSpawnPlayerOnLoad = newCheckpoint.transform.position;
        newCheckpoint.transform.Find("Particles").GetComponent<ParticleSystem>().Play();

    }
    public void RespawnPlayer()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        
        gameObject.GetComponent<PlayerHealth>().health = 10;
        //gameObject.transform.position = respawnLocation;
    }
}
