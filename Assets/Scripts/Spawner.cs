using UnityEngine;
using UnityEngine.Pool;

using static UnityEditor.Progress;
using static UnityEngine.ParticleSystem;

public class Spawner : MonoBehaviour
{
    [Header("Pool Params")]
    public int maxPooledItem;
    public GameObject prefabParticle;
    public ObjectPool<GameObject> poolParticles;


    [Header("Spawn")]
    public float spawnRate;
    public float spawnRadius;

    private float chrono;

    // Start is called before the first frame update
    void Start()
    {
        poolParticles = new ObjectPool<GameObject>(OnCreateItem, OnTakeItem, OnReturnToPool, OnDestroyItem, maxSize: maxPooledItem);

        for (int i = 0; i < maxPooledItem; i++)
        {
            poolParticles.Release(CreateParticle());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (chrono >= 1f / spawnRate)
        {
           poolParticles.Get();
            chrono = 0f;

        }

        chrono += Time.deltaTime;
    }

    public int nbCreate = 0;
    private GameObject CreateParticle()
    {



        GameObject particle = Instantiate(prefabParticle);

        particle.transform.position = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
        particle.transform.rotation = transform.rotation;

        ReturnToPool rtp = particle.AddComponent<ReturnToPool>();

        rtp.pool = poolParticles;
        
        return particle;
    }

    public GameObject OnCreateItem()
    {
        GameObject particule = CreateParticle();
        particule.SetActive(false);
        return particule;
    }

    public void OnTakeItem(GameObject item) 
    {
        item.transform.position = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
        item.transform.rotation = transform.rotation;
        item.SetActive(true); 
    }

    public void OnReturnToPool(GameObject item) { item.SetActive(false); }

    public void OnDestroyItem(GameObject item) { Destroy(item); }

}
