using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.Timeline;

public class WeaponScript : MonoBehaviour
{
    public Enemy enemyScript;
    public GameObject enemyObject;
    private Animator _swordAnimator;
    public bool attacking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyScript = enemyObject.GetComponent<Enemy>();
        _swordAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !attacking)
        {
            attacking = true;
            _swordAnimator.SetTrigger("AtkTrigger");
            StartCoroutine(SwordAttack());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && attacking)
        {
            attacking = false;
            Attack();
        }
    }

    IEnumerator SwordAttack()
    {
        yield return new WaitForSeconds(1);
        attacking = false;
    }

    void Attack()
    {
        enemyScript.enemyHealth -= 5f;
        Debug.Log("hit!");
        StartCoroutine(SwordAttack());
    }
}
