using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Ship : MonoBehaviour
{

    public float thrustForce = 1f;
    public float maxSpeed = 5f;
    public GameObject boosterFlame;

    private float score = 0f;
    Rigidbody2D rb;

    public UIDocument uiDocument;

    public GameObject ExplosionEffect;

    private Label scoreText;

    private Button restartButton;

    public GameObject borderParent;

    public GameObject bulletPrefab;

    public float bulletOffset = 0.5f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        restartButton = uiDocument.rootVisualElement.Q<Button>("Restart");
        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += ReloadScene;
        scoreText.text = "Score: 0";
    }

    public void Addscore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
    }
    void Update()
    {



        FireBullet();
        
        MovePlayer();
    }

    void MovePlayer()
        {
            if (Mouse.current.leftButton.isPressed)
            {
                Vector3 MousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
                Vector2 direction = (MousePos - transform.position).normalized;
                transform.up = direction;
                rb.AddForce(direction * thrustForce);

                if (rb.linearVelocity.magnitude > maxSpeed)
                {
                    rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
                }
            }

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                boosterFlame.SetActive(true);
            }
            else if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                boosterFlame.SetActive(false);
            }
        }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        Instantiate(ExplosionEffect, transform.position, transform.rotation);

        restartButton.style.display = DisplayStyle.Flex;

        borderParent.SetActive(false);
    }

    void FireBullet()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Vector3 spawnPosition = transform.position + transform.up * bulletOffset;

            Instantiate(bulletPrefab, spawnPosition, transform.rotation);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
