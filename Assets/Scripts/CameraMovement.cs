using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float test = 40f;
    float myRotation;

    private void Update()
    {
        if (myRotation != 0)
        {
            float myRotaVec = myRotation * test * Time.deltaTime;
            transform.Rotate(Vector3.up, myRotaVec);
        }
    }


    public void OnRotation(InputAction.CallbackContext context)
    {
        myRotation = context.ReadValue<float>();
        Debug.Log(context.ReadValue<float>());
    }
}
