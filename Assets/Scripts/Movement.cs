using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform rightWheelTransform;
    public Transform leftWheelTransform;
    public float force;
    public float maxAngularVelocityI;
    public Animator animator;
    private Rigidbody rb;
    private bool rightForward;
    private bool rightBackward;
    private bool leftForward;
    private bool leftBackward;
    public bool yayaYolundaMi = false;
    private Transform sonKaldirim;
    public bool istasyondaMi = false;
    private bool otobusGeldiMi = false;
    public int otobusSayi;
    private bool otobusIsinlandiMi = false;
    public Transform parkOtobus;
    public Follow followSc;
    public GameObject olumEkrani;
    public Transform cicekSahteGiris;
    public Transform cicekSahteCikis;
    public Transform cicekGercekGiris;
    public Transform cicekGercekCikis;
    public Transform cicekGercekAsansörGiris;
    public Transform cicekGercekAsansörCikis;
    public Transform EczaneGiris;
    public Transform EczaneCikis;



    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rightForward = Input.GetKey(KeyCode.I);
        rightBackward = Input.GetKey(KeyCode.J);
        leftForward = Input.GetKey(KeyCode.R);
        leftBackward = Input.GetKey(KeyCode.F);

        animator.SetInteger("CiftEl", 0);
        animator.SetInteger("SagEl", 0);
        animator.SetInteger("SolEl", 0);
    
        if(leftForward && rightForward) //Çift el ileri
        {
            animator.SetInteger("SagEl", 0);
            animator.SetInteger("SolEl", 0);
            animator.SetInteger("CiftEl", 1);

        }else if (leftForward) //SOL İLERİ
        {
            animator.SetInteger("SolEl", 1);

        }else if (rightForward) //SAĞ İLERİ
        {
            animator.SetInteger("SagEl", 1);
        }
        
        
        if(leftBackward && rightBackward) //Çift el geri
        {
            animator.SetInteger("SagEl", 0);
            animator.SetInteger("SolEl", 0);
            animator.SetInteger("CiftEl", -1);

        }else if (leftBackward) //SOL GERİ
        {
            animator.SetInteger("SolEl", -1);

        }else if (rightBackward) //SAĞ GERİ
        {
            animator.SetInteger("SagEl", -1);
        }

        if(otobusSayi == 2 && !otobusIsinlandiMi)
        {
            transform.position = parkOtobus.position;
            otobusIsinlandiMi = true;
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            transform.position = new Vector3(sonKaldirim.position.x, 0.5f, sonKaldirim.position.z);
        }
    }

    void FixedUpdate()
    {
        rb.maxAngularVelocity = maxAngularVelocityI;

        //SOL İLERİ
        if (leftForward)
        {
            rb.AddForceAtPosition(force * leftWheelTransform.forward, leftWheelTransform.position, ForceMode.Force);
        }

        //SOL GERİ
        if (leftBackward) 
        {
            rb.AddForceAtPosition(-force * leftWheelTransform.forward, leftWheelTransform.position, ForceMode.Force);
        }
        
        //SAĞ İLERİ
        if (rightForward) 
        {
            rb.AddForceAtPosition(force * rightWheelTransform.forward, rightWheelTransform.position, ForceMode.Force);
        }
        
        //SAĞ GERİ
        if (rightBackward) 
        {
            rb.AddForceAtPosition(-force * rightWheelTransform.forward, rightWheelTransform.position, ForceMode.Force);
        }
    }

    private IEnumerator OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Car") || other.gameObject.CompareTag("Otobüs"))
        {
            transform.position = new Vector3(sonKaldirim.position.x, 0.5f, sonKaldirim.position.z);
            olumEkrani.SetActive(true);
            yield return new WaitForSeconds(5f);
            olumEkrani.SetActive(false);
        }
    }

    private  IEnumerator OnTriggerEnter(Collider other)
    {
        if(other.tag == "Otobüs" && istasyondaMi)
        {
            yield return new WaitForSeconds(followSc.otobusSure);
            otobusSayi ++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "YayaYolu")
        {
            yayaYolundaMi = true;
        }

        if(other.tag == "Kaldirim")
        {
            sonKaldirim = other.gameObject.transform;
        }

        if(other.tag == "Istasyon")
        {
            istasyondaMi = true;
        }

        if(other.tag == "SahteCicekGir" && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = cicekSahteCikis.position;
        }

        if(other.tag == "SahteCicekCik" && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = cicekSahteGiris.position;
        }

        if(other.tag == "CicekGir" && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = cicekGercekCikis.position;
        }

        if(other.tag == "CicekÇik" && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = cicekGercekGiris.position;
        }

        if(other.tag == "CicekAsansörGir" && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = cicekGercekAsansörCikis.position;
        }

        if(other.tag == "CicekAsansörÇik" && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = cicekGercekAsansörGiris.position;
        }

        if(other.tag == "EczaneGir" && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = EczaneCikis.position;
        }

        if(other.tag == "EczaneÇik" && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = EczaneGiris.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "YayaYolu")
        {
            yayaYolundaMi = false;
        }
        
        if(other.tag == "Istasyon")
        {
            istasyondaMi = false;
        }
    }
}
