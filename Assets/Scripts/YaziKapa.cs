using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaziKapa : MonoBehaviour
{
    public GameObject kontrolYazi;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            kontrolYazi.SetActive(false);
        }
    }
}
