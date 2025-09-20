using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class MonsterAttack : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float attackRange = 3.5f;   // 사거리를 넉넉히
    public int attackDamage = 10;
    public float attackCooldown = 1.0f;

    private float lastAttackTime = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // 몬스터는 물리 영향 안 받고 제자리 유지

        // Collider 확인
        Collider col = GetComponent<Collider>();
        if (col != null) col.isTrigger = false; // 플레이어가 안으로 들어가지 않도록
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // 몬스터와 플레이어 사이 거리 계산
        float distance = Vector3.Distance(transform.position, player.position);

        // 거리 Debug
        Debug.DrawLine(transform.position, player.position, Color.red);

        // 이동
        if (distance > attackRange)
        {
            Vector3 newPos = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        else
        {
            // 공격
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    void Attack()
    {
        Debug.Log("몬스터가 플레이어를 공격!");
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(attackDamage);
        }
        else
        {
            Debug.LogWarning("PlayerHealth 컴포넌트가 없음!");
        }
    }
}
