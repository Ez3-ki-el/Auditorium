using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MusicBox : MonoBehaviour
{

    [Header("Balance")]
    [Tooltip("Volume gain per particle")]
    public float volumeIncrement = 0.02f;
    [Tooltip("Volume lost per second")]
    public float volumeDecay = 0.01f;
    [Tooltip("Time beforde decrementing volume")]
    public float decayInterval = 1f;

    [Header("Setup")]
    [SerializeField] SpriteRenderer[] m_bars;
    [SerializeField] AudioSource m_audioSource;
    [SerializeField] Color m_onColor;
    [SerializeField] Color m_offColor;

    private float m_chrono = 0f;

    // Start is called before the first frame update
    void Start()
    {
        m_audioSource.volume = 0f;

        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        UpdateVolumeBars();

        m_chrono += Time.deltaTime;

        if (m_chrono >= decayInterval)
        {
            //Je diminue le volume
            m_audioSource.volume -= volumeDecay * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_audioSource.volume += volumeIncrement;
        m_chrono = 0f;
    }

    private void UpdateVolumeBars()
    {
        for (int i = 0; i < m_bars.Length; i++)
        {
            float step = i / (float)m_bars.Length;

            if (m_audioSource.volume > step)
            {
                m_bars[i].color = m_onColor;
            }
            else
            {
                m_bars[i].color = m_offColor;
            }
        }
    }
}