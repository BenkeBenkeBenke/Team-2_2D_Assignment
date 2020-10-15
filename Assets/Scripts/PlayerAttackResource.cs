using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackResource : MonoBehaviour
{
    public float redResource = 100f;
    public float redCost = 3;
    public float redChargeSpeed = 0.5f;
    [Space]
    public float blueResource = 100f;
    public float blueCost = 3;
    public float blueChargeSpeed = 0.5f;
    [Space]
    public float specialResource;
    public float specialCost = 10;

    private Coroutine _redResourceCoroutine;
    private Coroutine _blueResourceCoroutine;
    private void Start()
    {
        _redResourceCoroutine = StartCoroutine(ChargeRedResource(redChargeSpeed));
        _blueResourceCoroutine = StartCoroutine(ChargeBlueResource(blueChargeSpeed));
    }
    
    // Use/Charge red resources
    public void UseRedResource()
    {
        redResource = redResource - redCost;
    }
    
    private IEnumerator ChargeRedResource(float chargeTime)
    {
        while (true)
        {
            if (redResource < 100)
            {
                redResource = redResource + 1;
            }
            yield return new WaitForSeconds(chargeTime); 
        }
    }
    
    // Use/Charge blue resources
    public void UseBlueResource()
    {
        blueResource = blueResource - blueCost;
    }

    private IEnumerator ChargeBlueResource(float chargeTime)
    {
        while (true)
        {
            if (blueResource < 100)
            {
                blueResource = blueResource + 1;
            }
            yield return new WaitForSeconds(chargeTime); 
        }
    }

    // Use/Charge special resources
    public void UseSpecialResource()
    {
        specialResource = specialResource - specialCost;
    }

}
