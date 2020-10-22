using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 respawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        respawnLocation = gameObject.transform.position;
    }

    public void SetActiveCheckpoint(GameObject newCheckpoint)
    {
        respawnLocation = newCheckpoint.transform.position;
        newCheckpoint.transform.Find("Particles").GetComponent<ParticleSystem>().Play();

    }
    public void RespawnPlayer()
    {
        gameObject.transform.position = respawnLocation;
        gameObject.GetComponent<PlayerHealth>().health = 10;
    }
}
