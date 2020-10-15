using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    private GameObject[] Player;
    public GameObject bg_House;
    public GameObject bg_Sky;

    public float smoothTime = 0.5F;
    public Vector3 offset = new Vector3(0f, 1f, -10f);
    private Vector3 _velocity;
    private Transform _transform;

    public bool sliding_BG;


    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        _transform = transform;
        _transform.position = Player[0].transform.position + offset;
    }

    void Update()
    {
        Vector3 PlayerMovmentTarget = new Vector3(Input.GetAxis("Horizontal") * 2, 0,0);
        Vector3 targetPosition = Player[0].transform.TransformPoint(offset + PlayerMovmentTarget);       
        _transform.position = Vector3.SmoothDamp(_transform.position, targetPosition, ref _velocity, smoothTime);

        if(sliding_BG)
        {
            bg_House.transform.position = new Vector3(bg_House.transform.position.x - Input.GetAxis("Horizontal") / 2000, bg_House.transform.position.y, bg_House.transform.position.z);
            bg_Sky.transform.position = new Vector3(bg_Sky.transform.position.x - Input.GetAxis("Horizontal") / 5000, bg_Sky.transform.position.y, bg_Sky.transform.position.z);
        }

    }
}
