using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class movecontro : MonoBehaviour
{
    public float speed = 4;
    public Vector2 movement;
    public Transform weapon;
    public Transform Weapon;

    Coroutine attackC;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("attack");
        if (attackC != null)
        {
            StopCoroutine(attackC);
        }
        attackC = StartCoroutine(useWeapon());
    }

    IEnumerator useWeapon()
    {
        float R = 0;

        while (R < 360)
        {

            Vector3 newR = weapon.eulerAngles;
            newR.z -= 700 * Time.deltaTime;
            weapon.eulerAngles = newR;
            R += 700 * Time.deltaTime;
            yield return null;
        }
        weapon.eulerAngles = Vector3.zero;

        attackC = null;
    }
}

