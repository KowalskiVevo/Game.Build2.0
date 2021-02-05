using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEditor.Animations;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Collider2D col;
    public GameObject weaponFirst = null;
    public Rigidbody2D rb;
    public Camera cam; 
    public Animator animator;

    public int AmmoAr15 = 150;
    public bool fl1=false; //Свет
    //public bool weaponfl1=false;
    public Transform plr; 

    Vector2 movement;
    public Vector2 mousePos;

    // Update is called once per frame
    void Start()
    {   
        //Debug.Log("Рабо");
    }
    void Update()   
    {
        //Управление
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");  

        //Анимация
        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Horizontal",movement.y);
        animator.SetFloat("Speed",movement.sqrMagnitude);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    private void FixedUpdate()
    {  
        //Движение
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //Взгляд на курсор
        Vector2 lookDir = mousePos - rb.position; 
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    //Взаимодействие триггера
    private void OnTriggerStay2D(Collider2D collider)
    {  
        col = collider;
        if (collider.name == "ButtonTest")
            fl1=true;
        else if (collider.tag == "Weapons"){
            //weaponfl1=true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        fl1=false;
        col = null;
        //weaponfl1=false;
    }
}