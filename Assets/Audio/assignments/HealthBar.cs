using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public UnityEvent GameOver;
    public Slider HB;
    public int health = 15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set maximum health bar
        HB.maxValue = health;
    }

    // Update is called once per frame
    void Update()
    {
        //The maximum health is 15
        if (health > 15)
        {
            health = 15;
        }
        HB.value = health;

        //The event is triggered when health reaches zero
        if (health == 0)
        {
            GameOver.Invoke();
        }
    }

}
