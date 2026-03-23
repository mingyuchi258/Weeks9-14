using UnityEngine;

public class knight : MonoBehaviour
{
    public AudioSource sfx;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void footsteps()
    {
      sfx.Play();
    }
}
