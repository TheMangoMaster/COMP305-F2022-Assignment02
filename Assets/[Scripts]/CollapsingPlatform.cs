using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{
    [SerializeField]
    private float fallDelay = 1f;
    [SerializeField]
    private float destroyDelay = 0.75f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject, destroyDelay);
    }
}
