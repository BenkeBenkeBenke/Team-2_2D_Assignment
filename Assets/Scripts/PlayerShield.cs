using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public bool usingShieldRed = true;
    private GameObject _shieldRed;
    private GameObject _shieldBlue;

    private PlayerAttackResource _attackResource;
    private void Awake()
    {
        _shieldRed = GameObject.Find("ShieldRed");
        _shieldBlue = GameObject.Find("ShieldBlue");
        _shieldBlue.SetActive(false);
        _attackResource = gameObject.GetComponent<PlayerAttackResource>();
    }

    public void ToggleShield()
    {
        if (usingShieldRed == true)
        {
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
}