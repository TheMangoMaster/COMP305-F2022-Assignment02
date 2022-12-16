using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipToHazardPlatform : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(Flip());
    }

    IEnumerator Flip()
    {

        if (transform.localScale.y > 0)
        {
            yield return new WaitForSecondsRealtime(5);
            transform.localScale = new Vector3(-1f, -1f, 0);
        }
        else
        {
            yield return new WaitForSecondsRealtime(5);
            transform.localScale = new Vector3(-1f, 1f, 0);
        }

    }
}
