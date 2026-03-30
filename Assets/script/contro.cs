using UnityEngine;
using UnityEngine.InputSystem;

public class contro : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movement;
    public AudioSource a;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += (Vector3)movement * speed * Time.deltaTime;
        transform.position = movement;
    }
    public void OnPoint(InputAction.CallbackContext context)
    {
        movement = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());


    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();

        
    }

    public void OnAttak(InputAction.CallbackContext context)
    {
        Debug.Log("attack");
        if(context.performed == true)
        {
            a.Play();
        }
    }
}
