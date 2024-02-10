using System.Collections;
using System.Collections.Generic;
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
}
