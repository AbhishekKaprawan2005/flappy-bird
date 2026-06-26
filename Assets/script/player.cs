 using UnityEngine;

public class Player : MonoBehaviour
{

    private SpriteRenderer SpriteRenderer;

    private Vector3 direction;

    private int SpriteIndex;            // keeps track of which sprite is currently being displayed.

    public Sprite[] Sprites;            // holds multiple sprites for animation.

    public float gravity = -9.8f;

    public float strength = 5f;

    private void Awake()
    {

        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);    // changes the player's sprite for animation.(3 sprites)
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector3.up * strength;

        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }
        direction.y += gravity * Time.deltaTime;            // pulling the player down over time.
        transform.position += direction * Time.deltaTime;   // updates the player’s position based on the current direction.

    }

    private void AnimateSprite()
    {
        SpriteIndex++;
        if (SpriteIndex >= Sprites.Length)
        {
            SpriteIndex = 0;
        }
        SpriteRenderer.sprite = Sprites[SpriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            FindObjectOfType<gamemanager>().GameOver();
        }
        else if (other.gameObject.tag == "scoring")
        {
            FindObjectOfType<gamemanager>().IncreaseScore();
        }

    }
}
