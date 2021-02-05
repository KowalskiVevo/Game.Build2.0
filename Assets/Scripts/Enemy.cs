using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    int i = 0;
    public AIDestinationSetter ai;
    public AILerp ailerp;
    public Transform plr;
    public Transform colimn;
    public float distance;
    public Transform tr;
    public Rigidbody2D rb;

    void Start()
    {
        plr = GameObject.Find("Player").GetComponent<Transform>();
        colimn = GameObject.Find("Column").GetComponent<Transform>();
        Physics2D.queriesStartInColliders = false;
    }


    void Update()
    {

    }
    void FixedUpdate() 
    {

    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.name == "Player")
        {
            RaycastHit2D hit = Physics2D.Linecast(transform.position, plr.position,LayerMask.GetMask("Player","Walls","Decoration"));
            Debug.DrawLine(transform.position,plr.position,Color.red);
            Debug.Log(hit.collider.name);
            if (hit.collider.name == "Player")
            {
                ailerp.enableRotation = false;
                //Таргет - игрок
                ai.target = plr;
                //Поворот противника
                Vector2 lookDir = ((Vector2)plr.position - rb.position);
                float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
                rb.rotation = angle - 90 ;
            }
            else 
            {
                ailerp.enableRotation = true;
            }
        }
        else 
        {
            ai.target = null;
        }
    }
}
