using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class coroutine : MonoBehaviour
{
    public Transform duck;
    public Vector2 dp;
    public GameObject tank;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dp.x = 4;
        dp.y = 4;
        duck.localScale = dp;
    }

    void Update()
    {
        Vector2 mouseP = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            tank.transform.position = mouseP;
            Instantiate(tank);
        }
    }

    public void duckMove()
    {
        StartCoroutine(Duck());
    }

    IEnumerator Duck()
    {
        float t = 1;
        duck.localScale = dp;
        while (t>0.2)
        {
            t -= Time.deltaTime;
            duck.localScale = dp * t;
            yield return null;
        }

        while (t < 1)
        {
            t += Time.deltaTime;
            duck.localScale = dp * t;
            yield return null;
        }

    }
}
