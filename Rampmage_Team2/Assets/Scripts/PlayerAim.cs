using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    // Player aim object to fire towards
    public GameObject mouseAim;
    public GameObject playerAim;
    
    private void Update()
    {
        AimInDirection();
    }
    
    private void AimInDirection()
    {
        // Conver mouse position to worldspace
        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // Set rotation of player aims forward to look at mouse position
        mouseAim.transform.position = new Vector3(mPosition.x, mPosition.y, 0);
        playerAim.transform.rotation = Quaternion.LookRotation(playerAim.transform.forward, mPosition - playerAim.transform.position);
        //Debug.Log(mPosition);
    }
}
