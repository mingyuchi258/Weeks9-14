using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class knight : MonoBehaviour
{
    public AudioSource sfx;
    public ParticleSystem particles;
    public Vector2 m;
    public float speed = 5;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)m * speed * Time.deltaTime;
    }

    public void footsteps()
    {
      sfx.Play();
    }

    public void play()
    {
        particles.Play();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        animator.SetBool("run", true);
        m = context.ReadValue<Vector2>();
    }

    public void Onjump(InputAction.CallbackContext context)
    {
        StartCoroutine(jp());

    }



    IEnumerator jp()
    {
        animator.SetBool("jump", true);
        float t = 0;

        while (t < 0.7 )
        {
            t += Time.deltaTime;
            yield return null;
        }
        animator.SetBool("jump", false);

    }


}
