using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingPlatform : MonoBehaviour
{
    [SerializeField]
    private float fallDelay = 1f;
    [SerializeField]
    private float destroyDelay = 0.75f;
    [SerializeField]
    private GameObject explosion;

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
            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(fallDelay);
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(destroyDelay);
        Instantiate(explosion, new Vector3(29.3f, -0.4f, 0), Quaternion.identity);
        Destroy(gameObject, destroyDelay);
    }
}
