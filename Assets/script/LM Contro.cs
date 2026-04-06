using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class LMContro : MonoBehaviour
{
    public Manager manager;
    public PlayerInput PlayerInput;
    public Vector2 movmentInput;
    public float speed = 5;
    void Update()
    {
        transform.position += (Vector3)movmentInput * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movmentInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            Debug.Log("plyer"+PlayerInput.playerIndex+":attack");
            manager.plyaerAttacking(PlayerInput);
        }

    }
}
