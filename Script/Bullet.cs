using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject obstaclePrefab;

    public GameObject shipPrefab;
    public Vector2 spawnMin = new(-10f, -10f);
    public Vector2 spawnMax = new( 10f,  10f);
    public float minDistanceFromShip = 5f;
    public float speed = 10f;

    public float lifetime = 2f;

    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;
        Destroy(gameObject, lifetime);
    }

    public void SpawnNewObstacle(Vector3 shipPos)
    {
            Vector2 candidate = new(
                Random.Range(spawnMin.x, spawnMax.x),
                Random.Range(spawnMin.y, spawnMax.y));

            if (Vector2.Distance(candidate, shipPos) >= minDistanceFromShip)
            {
                Instantiate(obstaclePrefab, candidate, Quaternion.identity);
            }

            Vector2 fallback = new(
            Random.Range(spawnMin.x, spawnMax.x),
            Random.Range(spawnMin.y, spawnMax.y));
        Instantiate(obstaclePrefab, fallback, Quaternion.identity);
        }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
{
        if (other.CompareTag("obstacle"))
        {
            Ship ship = FindAnyObjectByType<Ship>();
            if (ship != null)
            {
                ship.Addscore(1);
            }

            Destroy(other.gameObject);
            Destroy(gameObject);

            SpawnNewObstacle(shipPrefab.transform.position);
    }
}
}
