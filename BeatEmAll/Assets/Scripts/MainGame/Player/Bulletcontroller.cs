using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletcontroller : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        StartCoroutine(WaitAndDestroy());
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
