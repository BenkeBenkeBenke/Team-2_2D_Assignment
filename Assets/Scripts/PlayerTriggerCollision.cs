using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCollision : MonoBehaviour
{
    public bool isOnStairs;
    public GameObject _stairTrigger;
    private Collider2D _thisStairCollider;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "StairTriggerArea")
        {
            _stairTrigger = other.gameObject;
            _thisStairCollider = _stairTrigger.transform.Find("StairCollider").GetComponent<Collider2D>();
            isOnStairs = true;
            //thisStairCollider.enabled = true;
        }

        if (other.gameObject.tag == "StairTriggerTop")
        {
            isOnStairs = true;
            _thisStairCollider = _stairTrigger.transform.Find("StairCollider").GetComponent<Collider2D>();
            _thisStairCollider.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "StairTriggerArea")
        {
            isOnStairs = false;
            _thisStairCollider.enabled = false;
        }
    }

    public void UseStair(bool StairActive)
    {
        if (isOnStairs == true)
        {
            _thisStairCollider.enabled = StairActive;    
        }
    }
}
