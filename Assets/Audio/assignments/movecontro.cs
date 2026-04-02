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
    //Move value
    public void OnMove(InputAction.CallbackContext context)
    {

        movement = context.ReadValue<Vector2>();
    }
    //Attack value
    public void OnAttack(InputAction.CallbackContext context)
    {
        //Stop if weapons are being used
        if (attackC != null)
        {
            StopCoroutine(attackC);
        }
        //Start use weapon attack effect
        attackC = StartCoroutine(useWeapon());
    }

    //Use weapon attack effect
    IEnumerator useWeapon()
    {
        float R = 0;
        while (R < 360)
        {
            //The weapon rotates once during the attack
            Vector3 newR = weapon.eulerAngles;
            newR.z -= 700 * Time.deltaTime;
            weapon.eulerAngles = newR;
            R += 700 * Time.deltaTime;
            yield return null;
        }
        //After rotating, the weapon will return to its original position
        weapon.eulerAngles = Vector3.zero;
        //Do not use attack effects after the coroutine end
        attackC = null;
    }
}

