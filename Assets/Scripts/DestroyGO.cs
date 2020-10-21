using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGO : MonoBehaviour
{
    [Header("Behavior")]
    public bool destroyAfterTimer;

    [Header("Timer Setting")]
    public float DaetroyAfter = 60;

    void Update()
    {
        if (destroyAfterTimer)
        {
            DaetroyAfter--;
            if (DaetroyAfter < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
