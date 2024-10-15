using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Pool;

public class ReturnToPool : MonoBehaviour
{
    Rigidbody2D rb2d;
    TrailRenderer m_trailRenderer;
    public IObjectPool<GameObject> pool;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        if (m_trailRenderer == null)
        {
            m_trailRenderer = GetComponent<TrailRenderer>();
        }
        m_trailRenderer.emitting = true;

        if (rb2d == null)
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
        rb2d.velocity = transform.right * 15f;
    }

    private void OnDisable()
    {
        rb2d.velocity = Vector2.zero;
        m_trailRenderer.Clear();
        m_trailRenderer.emitting = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Je regarde si je me d�place � moins de 0.1m/s
        if (rb2d.velocity.magnitude <= 0.1f)
        {
            pool.Release(gameObject);
        }
    }
}