using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotatePower;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotatePower, 0f);
    }
}
