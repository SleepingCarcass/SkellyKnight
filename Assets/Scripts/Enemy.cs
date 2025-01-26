using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float enemyHealth = 100f;
    public float attackStrenght = 5f;
    public float attackSpeed = 10f;
    public float attackCooldown = 2f; 
    public float distanceToPlayer;
    
    public bool attacking = false;
    
    public Rigidbody enemyRb;
    public GameObject player;
    public PlayerController playerController;

    public Ray toThePlayerRay;
    public RaycastHit hitData;
    
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * moveSpeed);
        transform.LookAt(player.transform.position);
        toThePlayerRay.origin = transform.position;
        toThePlayerRay.direction = lookDirection;
        distanceToPlayer = hitData.distance;
        Debug.DrawRay(transform.position, lookDirection * 15f, Color.red);
        Physics.Raycast(toThePlayerRay, out hitData);
        Attack();
    }

    void Attack()
    {
        if (distanceToPlayer <= 2 && !attacking)
        {
            attacking = true;
            StartCoroutine(DoDamage());
        }
    }

    IEnumerator DoDamage()
    {
        //playerController.health -= attackStrenght;
        Debug.Log("Attack");
        yield return new WaitForSeconds(attackCooldown);
        attacking = false;
    }
}
