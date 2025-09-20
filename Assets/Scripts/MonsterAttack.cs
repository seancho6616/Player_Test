using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class MonsterAttack : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float attackRange = 3.5f;   // ��Ÿ��� �˳���
    public int attackDamage = 10;
    public float attackCooldown = 1.0f;

    private float lastAttackTime = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // ���ʹ� ���� ���� �� �ް� ���ڸ� ����

        // Collider Ȯ��
        Collider col = GetComponent<Collider>();
        if (col != null) col.isTrigger = false; // �÷��̾ ������ ���� �ʵ���
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // ���Ϳ� �÷��̾� ���� �Ÿ� ���
        float distance = Vector3.Distance(transform.position, player.position);

        // �Ÿ� Debug
        Debug.DrawLine(transform.position, player.position, Color.red);

        // �̵�
        if (distance > attackRange)
        {
            Vector3 newPos = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        else
        {
            // ����
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    void Attack()
    {
        Debug.Log("���Ͱ� �÷��̾ ����!");
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(attackDamage);
        }
        else
        {
            Debug.LogWarning("PlayerHealth ������Ʈ�� ����!");
        }
    }
}
