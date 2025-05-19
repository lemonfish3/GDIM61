using UnityEngine;
using System.Collections;  // Needed for IEnumerator

public class PlayerSword : MonoBehaviour
{
    public float attackRadius = 2f;
    public KeyCode attackKey = KeyCode.Q;
    public LayerMask enemyLayer;

    private Animator animator;
    private bool isAttacking = false;
    public float attackDuration = 0.5f; // Adjust to match your attack animation length

    void Start()
    {
        animator = GetComponent<Animator>();  // Get Animator component
    }

    void Update()
    {
        if ((Input.GetKeyDown(attackKey) || Input.GetMouseButtonDown(0)) && !isAttacking)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;
        animator.SetBool("isAttacking", true);  // Trigger animation

        SwingAttack();  // Damage logic

        yield return new WaitForSeconds(attackDuration);  // Wait for animation to finish

        animator.SetBool("isAttacking", false);  // Reset animation
        isAttacking = false;
    }


    void SwingAttack()
    {
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(transform.position, attackRadius, enemyLayer);
        Debug.Log($"Hit {enemiesHit.Length} enemies");

        foreach (Collider2D enemy in enemiesHit)
        {
            if (enemy.CompareTag("Enemy"))
            {
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(50f); 
                    Debug.Log($"Damaged enemy: {enemy.name}");
                }

                //if (EnemyCounter.Instance != null)
                //{
                //    EnemyCounter.Instance.EnemyDestroyed(); 
                //}
            }
        }
    }
}


//    void SwingAttack()
//    {
//        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(transform.position, attackRadius, enemyLayer);
//        Debug.Log($"Hit {enemiesHit.Length} enemies");

//        foreach (Collider2D enemy in enemiesHit)
//        {

//            if (enemy.CompareTag("Enemy"))
//            {
//                Destroy(enemy.gameObject);
//                Debug.Log($"Destroyed enemy: {enemy.name}");

//                if (EnemyCounter.Instance != null)
//                {
//                    EnemyCounter.Instance.EnemyDestroyed();
//                }
//            }
//        }
//    }
//}
