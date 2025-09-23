using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    Vector2 movement;

    private void Update()
    {
        ProcessTranslation();

    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float zOffset = movement.y * controlSpeed * Time.deltaTime;        
        transform.Translate(xOffset, 0f, zOffset);
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        Debug.Log(value.Get<Vector2>());

    }
    void OnAttack()
    {
        Debug.Log("Attack");
    } 
}
