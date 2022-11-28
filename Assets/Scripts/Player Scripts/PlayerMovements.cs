using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private CharacterAnimation player_Anim;
    private Rigidbody myBody;
    public float walk_Speed = 3f;
    public float Z_Speed = 1.5f;
    private float rotation_Y = -90f;
    private float rotation_Speed = 15f;
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
        
    }
     void FixedUpdate()
    {
        DetectMovemnet();    
    }
    void DetectMovemnet()
    {
        myBody.velocity = new Vector3(Input.GetAxis(Axis.HORIZONTAL_AXIS)*(-walk_Speed),
        myBody.velocity.y,Input.GetAxisRaw(Axis.VERTICAL_AXIS)*(-Z_Speed));

    } //Movement
    void RotatePlayer()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, -Mathf.Abs(rotation_Y), 0f);
        }
        else if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS)<0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotation_Y), 0f);

        }
    } // Rotation
    void AnimatePlayerWalk()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {
            player_Anim.Walk(true);
        }
        else
        {
            player_Anim.Walk(false);
        }
        }
    } //AnimatePlayerWalk

 