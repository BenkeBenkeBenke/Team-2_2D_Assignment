using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerShield : MonoBehaviour
{
    public bool usingShieldRed = true;
    private GameObject _shieldRed;
    private GameObject _shieldBlue;

    public GameObject RedPlayer;
    public GameObject BluePlayer;

    private ParticleSystem _CastSpel_PS;                      //Animator for the player


    private PlayerAttackResource _attackResource;
    private void Awake()
    {
        _shieldRed = GameObject.Find("ShieldRed");
        _shieldBlue = GameObject.Find("ShieldBlue");
        _shieldBlue.SetActive(false);
        _attackResource = gameObject.GetComponent<PlayerAttackResource>();

        //ref to particle system
        _CastSpel_PS = this.gameObject.transform.GetChild(3).GetComponent<ParticleSystem>();
    }

    public void ToggleShield()
    {
        if (usingShieldRed == true)
        {
            usingShieldRed = false;
            _shieldRed.SetActive(false);
            _shieldBlue.SetActive(true);
            RedPlayer.SetActive(true);
            BluePlayer.SetActive(false);
            _CastSpel_PS.startColor = new Color32(191, 0, 0, 255);
            
        }
        else
        {
            usingShieldRed = true;
            _shieldRed.SetActive(true);
            _shieldBlue.SetActive(false);
            
            RedPlayer.SetActive(false);
            BluePlayer.SetActive(true);
            _CastSpel_PS.startColor = new Color32(0, 190, 191, 255);

        }
    }
}