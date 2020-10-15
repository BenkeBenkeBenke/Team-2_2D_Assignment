using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public Scene LastScene;
    public string LastSceneString;
    public Vector3 PlaceToSpawnPlayerOnLoad;

    void Awake()
    {
        // To make player consistent.
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");

        if (objs.Length > 1)
        {
            // if player enter a new room

            Destroy(this.gameObject);
        }
        objs[0].transform.position = objs[0].GetComponent<PlayerStats>().PlaceToSpawnPlayerOnLoad;

        DontDestroyOnLoad(this.gameObject);
    }
}
