using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public Object SceneToLoad;
    public Vector3 PlaceToSpawnPlayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            //Save current Scene so when you load next scene you start in the correct place.
            GameObject[] Player = GameObject.FindGameObjectsWithTag("Player");
            PlayerStats PlayerStatsScript = Player[0].GetComponent<PlayerStats>();
           // PlayerStatsScript.LastScene = SceneManager.GetActiveScene();
           // PlayerStatsScript.LastSceneString = PlayerStatsScript.LastScene.name;
            PlayerStatsScript.PlaceToSpawnPlayerOnLoad = PlaceToSpawnPlayer;

            SceneManager.LoadScene(SceneToLoad.name);
        }
    }
}
