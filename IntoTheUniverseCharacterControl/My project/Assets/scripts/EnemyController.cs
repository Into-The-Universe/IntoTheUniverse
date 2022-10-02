using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed;
    public float chaseRangeMax;
    public float chaseRangeMin;
    public float attackRange;
    public int MaxHealth = 100;

    private Vector2 _facingDirection;
    private Character2dController _player;
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        // get the player target
        _player = FindObjectOfType<Character2dController>();
        // get the rigidbody component
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Chase()
    {
        Vector2 dir = (_player.transform.position - transform.position).normalized;
        _rigidBody.velocity = dir * moveSpeed;
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_rigidBody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rigidBody.velocity.x), 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float playerDist = Vector3.Distance(transform.position, _player.transform.position);
        Debug.Log(playerDist);
        if (playerDist <= chaseRangeMax && playerDist >= chaseRangeMin)
        {
            Chase();
        }
        else
        {
            _rigidBody.velocity = Vector2.zero;
        }

        FlipSprite();
    }
}
