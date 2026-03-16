using System.Collections;
using UnityEngine;

public class grower : MonoBehaviour
{
    public Transform tree;
    public Transform apple;

    Coroutine groingCoroutine;
    Coroutine treeCoroutine;
    Coroutine appleCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tree.localScale = Vector2.zero;
        apple.localScale = Vector2.zero;
    }

    public void startTreeGrowing()
    {
        if (groingCoroutine != null)
        {
            StopCoroutine(groingCoroutine);
        }
        if (treeCoroutine != null)
        {
            StopCoroutine(treeCoroutine);
        }
        if (appleCoroutine != null)
        {
            StopCoroutine(appleCoroutine);
        }
        groingCoroutine = StartCoroutine(Growing());
    }

    IEnumerator Growing()
    {
        yield return treeCoroutine = StartCoroutine(Growtree());
        yield return appleCoroutine = StartCoroutine(GrowApple());
    }

    IEnumerator Growtree()
    {
        Debug.Log("starting growing the tree");
        float t = 0;
        tree.localScale = Vector2.zero;
        apple.localScale = Vector2.zero;


        while (t < 1)
        {
            t += Time.deltaTime;
            tree.localScale = Vector2.one * t;
            yield return null;
        }
        Debug.Log("finished growing the tree");
    }


    IEnumerator GrowApple()
    {
        Debug.Log("starting growing the apple");
        float t = 0;
        apple.localScale = Vector2.zero;


        while (t < 1)
        {
            t += Time.deltaTime;
            apple.localScale = Vector2.one * t;
            yield return null;
        }
        Debug.Log("finished growing the apple");
    }
}
