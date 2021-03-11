using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _speed);

        if(transform.position.y > 5.5f)
        {
            Destroy(this.gameObject);
        }


    }
}
