using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = _playerHealth.health;
    }
}
