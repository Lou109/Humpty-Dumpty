using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    Vector2 paddleToBallVector;
    private bool hasStarted = false;
    private bool firstBall = true;

    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

    void Start()
    {
        SetBallPosition();
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0) && !PauseMenu.GameIsPaused)
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       Vector2 velocityTweak = new Vector2 (Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity = myRigidbody2D.velocity.normalized * 16f;
            myRigidbody2D.velocity += velocityTweak;
        }
    }

    public void SetBallPosition()
    {
        if (firstBall)
        {
            paddleToBallVector = transform.position - paddle1.transform.position;
            firstBall = false;
        }

        hasStarted = false;
    }
}
