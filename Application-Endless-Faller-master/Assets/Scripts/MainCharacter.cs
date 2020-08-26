using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private const float moveRange = 4.9f;

    public LevelManager levelManager;
    public Rigidbody rb;

    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (LevelManager.isPaused)
            return;

        if (transform.position.x >= -moveRange && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed;
        }
        else if (transform.position.x <= moveRange && Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            PlayerDead();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            levelManager.IncrementScore();
        }
    }

    private void PlayerDead()
    {
        gameObject.SetActive(false);
        levelManager.GameOver();
    }
}
