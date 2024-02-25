using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class Player : Agent
{
    [Header("References")]
    [SerializeField] private Spawner spawner = null;

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    public float strength = 5f;
    public float gravity = -9.81f;
    public float tilt = 5f;

    private Vector3 direction;

    public override void Initialize()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    public override void OnEpisodeBegin()
    {
        spawner.ResetPipes();

        Vector3 position = transform.localPosition;
        position.y = 0f;
        transform.localPosition = position;
        direction = Vector3.zero;

        FindObjectOfType<GameManager>().Play();
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        AddReward(0.1f);

        if (Mathf.FloorToInt(actions.DiscreteActions.Array[0]) != 1)
        {
            return;
        }

        Jump();
    }

    private void Jump()
    {
        direction = Vector3.up * strength;
        direction.y += gravity * Time.deltaTime;
        transform.localPosition += direction * Time.deltaTime;
    }

    private void Update()
    {
        direction.y += gravity * Time.deltaTime;
        transform.localPosition += direction * Time.deltaTime;

        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0)
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            AddReward(-1.0f);
            EndEpisode();
        }
        else if (other.gameObject.CompareTag("Scoring"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        actionsOut.DiscreteActions.Array[0] = 0;

        if (!Input.GetKeyDown(KeyCode.Space) && !Input.GetMouseButtonDown(0))
        {
            return;
        }

        actionsOut.DiscreteActions.Array[0] = 1;
    }
}
