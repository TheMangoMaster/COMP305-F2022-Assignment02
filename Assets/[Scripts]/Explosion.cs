using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private CapsuleCollider2D capsuleCollider;

    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.1f);
        capsuleCollider.enabled = false;
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

}
