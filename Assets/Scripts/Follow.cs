using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follow : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed;
    private float distanceTraveled;
    public Movement movementSc;
    private bool yayaYolundaMi;
    public bool isBus = false;
    public float otobusSure;
    private bool otobusDur = false;

    // Update is called once per frame
    void Update()
    {
        yayaYolundaMi = movementSc.yayaYolundaMi;

        if(!yayaYolundaMi)
        {
            if(isBus)
            {
                if(!otobusDur)
                {
                    distanceTraveled += speed * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTraveled);
                }
            }else
            {
                distanceTraveled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTraveled);
            }
        }

    }
    private  IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(isBus && movementSc.istasyondaMi)
            {
                otobusDur = true;
                yield return new WaitForSeconds(otobusSure);
                otobusDur = false;
            }
        }
    }
}
