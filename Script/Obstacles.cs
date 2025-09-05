using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float minSize = 0.5f; public float maxSize = 2.0f;

    public float minSpeed = 100f; public float maxSpeed = 300f;

    public float RotationSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float RandomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(RandomSize, RandomSize, 1);

        float RandomSpeed = Random.Range(minSpeed, maxSpeed);

        Vector2 RandomDirection = Random.insideUnitCircle;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(RandomDirection * RandomSpeed);

        float RandomTorque = Random.Range(-RotationSpeed, RotationSpeed);

        rb.AddTorque(RandomTorque);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
