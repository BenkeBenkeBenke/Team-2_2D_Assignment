using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAttackResources : MonoBehaviour
{
    public Slider redSlider;
    public Slider blueSlider;
    
    private PlayerAttackResource _attackResource;

    private void Start()
    {
        _attackResource = GameObject.Find("Player").GetComponent<PlayerAttackResource>();
    }

    // Update is called once per frame
    void Update()
    {
        redSlider.value = _attackResource.redResource;
        blueSlider.value = _attackResource.blueResource;
    }
}
