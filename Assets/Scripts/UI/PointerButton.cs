using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerButton : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(AutoHide());
    }

    IEnumerator AutoHide()
    {
        yield return new WaitForSeconds(.5f);

        Destroy(gameObject);
    }
}
