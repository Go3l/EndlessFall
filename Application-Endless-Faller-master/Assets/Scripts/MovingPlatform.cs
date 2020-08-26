using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platformLeft;
    public Transform platformRight;
    public Transform playerTransform;
    public Vector3 endPoint;

    public bool scoredUp;
    private float speed;

    private const int wallsDistance = 11;
    private const float platformsGap = 1.5f;

    private void OnEnable()
    {
        RandomSize();
    }

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (!LevelManager.isPaused)
        {
            transform.position += Vector3.up * speed;
        }

        if (transform.position.y >= endPoint.y)
        {
            gameObject.SetActive(false);
            scoredUp = false;
        }
    }

    private void RandomSize()
    {
        var random = Random.Range(0, wallsDistance);

        platformLeft.localScale = new Vector3(random, platformLeft.localScale.y, platformLeft.localScale.z);
        platformRight.localScale = new Vector3(wallsDistance - (random + platformsGap), platformRight.localScale.y, platformRight.localScale.z);
    }

    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
