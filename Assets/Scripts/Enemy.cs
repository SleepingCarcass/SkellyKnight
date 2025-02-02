using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float enemyHealth = 15f;
    public float attackStrenght = 5f;
    public float attackSpeed = 10f;
    public float attackCooldown = 2f; 
    public float distanceToPlayer;
    
    public bool attacking = false;
    
    public Rigidbody enemyRb;
    public GameObject player;
    public GameObject enemyCorpse;
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
        EnemyMovement();
        Attack();
        if (enemyHealth == 0)
        {
            Destroy(gameObject);
            Instantiate(enemyCorpse, transform.position - new Vector3(0, 0.5f, 0), enemyCorpse.transform.rotation);
        }
    }

    void Attack()
    {
        if (distanceToPlayer <= 1 && !attacking)
        {
            attacking = true;
            StartCoroutine(DoDamage());
        }
    }

    IEnumerator DoDamage()
    {
        playerController.health -= attackStrenght;
        Debug.Log("Attack");
        yield return new WaitForSeconds(attackCooldown);
        attacking = false;
    }

    void EnemyMovement()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        transform.Translate(new Vector3(lookDirection.x, 0, lookDirection.z) * -moveSpeed * Time.deltaTime);
        transform.LookAt(player.transform.position);
        toThePlayerRay.origin = transform.position;
        toThePlayerRay.direction = lookDirection;
        distanceToPlayer = hitData.distance;
        Debug.DrawRay(transform.position, lookDirection * 15f, Color.red);
        Physics.Raycast(toThePlayerRay, out hitData);
    }
}
