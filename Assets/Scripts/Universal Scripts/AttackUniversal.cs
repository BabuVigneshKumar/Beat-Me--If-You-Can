using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisonLayer;
    public float radius = 1f;
    public float damage = 2f;

    public bool is_Player, is_Enemy;

    public GameObject hit_FX_Prefab;
    // Update is called once per frame
    void Update()
    {
        DetectCollision();
    }
    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisonLayer);
        if(hit.Length > 0)
        {
            if (is_Player)
            {
                Vector3 hitFX_Pos = hit[0].transform.position;
                hitFX_Pos.y += 1.3f;
                if (hit[0].transform.forward.x > 0)
                {
                    hitFX_Pos.x += 0.3f;
                } else if (hit[0].transform.forward.x < 0)
                {
                    hitFX_Pos.x -= 0.3f;
                }

                Instantiate(hit_FX_Prefab, hitFX_Pos, Quaternion.identity);

                if (gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.LEFT_LEG_TAG))
                        {

                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                } else
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                }
            }//if  is player 
            if (is_Enemy)
            {
                hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
            } // is enemy
           // print("We Hit The " + hit[0].gameObject.name);

            gameObject.SetActive(false);
        } // If we have a Hit
    } //detectCollision
}
