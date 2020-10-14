using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public bool usingShieldRed = true;
    private GameObject _shieldRed;
    private GameObject _shieldBlue;

    private void Awake()
    {
        _shieldRed = GameObject.Find("ShieldRed");
        _shieldBlue = GameObject.Find("ShieldBlue");
        _shieldBlue.SetActive(false);
    }

    public void ToggleShield()
    {
        if (usingShieldRed == true)
        {
            Debug.Log("asd");
            usingShieldRed = false;
            _shieldRed.SetActive(false);
            _shieldBlue.SetActive(true);
        }
        else
        {
            usingShieldRed = true;
            _shieldRed.SetActive(true);
            _shieldBlue.SetActive(false);            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Red")
        {
            
        }    
    }
    
}