using UnityEngine;
using UnityEngine.Pool;

using static UnityEngine.ParticleSystem;

public class Spawner : MonoBehaviour
{
    [Header("Pool Params")]
    public int maxPooledItem;
    public GameObject prefabParticle;
    public IObjectPool<GameObject> poolParticles;


    [Header("Spawn")]
    public float spawnRate;
    public float spawnRadius;

    private float chrono;

    // Start is called before the first frame update
    void Start()
    {
        poolParticles = new ObjectPool<GameObject>(OnCreateItem, OnTakeItem, OnReturnToPool, OnDestroyItem, maxSize: maxPooledItem);

        for (int i = 0; i < 10; i++)
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


    private GameObject CreateParticle()
    {

        GameObject particle = Instantiate(prefabParticle);

        //particle.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;

        //var particleSystem = particle.AddComponent<ParticleSystem>();

        //ParticleSystem.EmissionModule em = particleSystem.emission;
        //ParticleSystem.ShapeModule shape = particleSystem.shape;

        //em.rateOverTime = new ParticleSystem.MinMaxCurve(spawnRate, spawnRate + 10);
        //shape.radius = spawnRadius;


        ReturnToPool rtp = particle.AddComponent<ReturnToPool>();



        rtp.pool = poolParticles;
        return particle;
    }

    public GameObject OnCreateItem()
    {
        return CreateParticle();
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
