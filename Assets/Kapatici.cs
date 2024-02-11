using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kapatici : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject digerCanvas;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Kapat();
        }
    }
    public void Kapat()
    {   
        digerCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
