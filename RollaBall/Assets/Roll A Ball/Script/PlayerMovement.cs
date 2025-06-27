using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;  


public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigidBody;
    Vector2 move;
    Vector3 inputDirection;
    public float speed = 10f;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private int count = 0;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;

        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

void Update()
{
    move.x = Input.GetAxis("Horizontal");
    move.y = Input.GetAxis("Vertical");
    inputDirection = new Vector3(move.x, 0f, move.y).normalized;

    // Jump when on ground
    if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
    {
        rigidBody.AddForce(Vector3.up * 300f);
    }
}

bool IsGrounded()
{
    return Physics.Raycast(transform.position, Vector3.down, 0.6f);
}



    void FixedUpdate()
    {
        rigidBody.velocity = (inputDirection * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

void SetCountText()
{
    countText.text = "Count: " + count;

    // Save high score
    if (count > PlayerPrefs.GetInt("HighScore", 0))
    {
        PlayerPrefs.SetInt("HighScore", count);
    }

    if (count >= 12)  // Match total pickups
    {
        winTextObject.SetActive(true);

        int best = PlayerPrefs.GetInt("HighScore", 0);
        Debug.Log("🏆 Best Score: " + best);

        // ✅ Stop the timer when player wins
        FindObjectOfType<GameTimer>().StopTimer();
    }
}

void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Enemy"))
    {
        // Play enemy sound (if it has AudioSource)
        AudioSource enemySound = collision.gameObject.GetComponent<AudioSource>();
        if (enemySound != null)
        {
            enemySound.Play();
        }

        // Restart the scene after a short delay to let sound play
        StartCoroutine(RestartAfterDelay(1f));
    }
}

IEnumerator RestartAfterDelay(float delay)
{
    yield return new WaitForSeconds(delay);
    UnityEngine.SceneManagement.SceneManager.LoadScene(
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
    );
}



}
