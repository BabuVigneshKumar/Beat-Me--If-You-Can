using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovemnet : MonoBehaviour
{
    private CharacterAnimation enemyaAnim;

    private Rigidbody myBody;
    public float speed = 5f;
    private Transform playerTarget;
    public float attack_Distance = 1f;
    public float chaase_Player_After_Attack = 1f;
    private float current_Attack_Time;
    private float default_Attack_Time = 2f;

    private bool followPlayer, attackPlayer;
     void Awake()
    {
        enemyaAnim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();
        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }
    void Start()
    {
        followPlayer = true;
        current_Attack_Time = default_Attack_Time;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void FixedUpdate()
    {
        FollowTarget();
    }
    void FollowTarget()
    { //If we are not supposed to follow this player
        if (!followPlayer)
            return;
        if(Vector3.Distance(transform.position,playerTarget.position)> attack_Distance)
        {
            transform.LookAt(playerTarget);
            myBody.velocity = transform.forward * speed;
            if(myBody.velocity.sqrMagnitude != 0)
            {
                enemyaAnim.Walk(true);
            }
        } else if (Vector3.Distance(transform.position,playerTarget.position) <= attack_Distance)
        {
            myBody.velocity = Vector3.zero;
            enemyaAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }
    } // follow Target
    void Attack()
    {
        //If we Should not attack the player
        // Exit the functiom
        if (!attackPlayer)
            return;
        current_Attack_Time += Time.deltaTime;


        if(current_Attack_Time > default_Attack_Time)
        {
            enemyaAnim.EnemyAttack(Random.Range(0,3));

            current_Attack_Time = 0f;
        }
        if(Vector3.Distance(transform.position,playerTarget.position)> attack_Distance + chaase_Player_After_Attack)
        {
            attackPlayer = false;
            followPlayer = true;
        }


    } //Attack 
}
