using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    private Rigidbody2D mybody;

    public SpriteRenderer sr;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mybody.velocity = new Vector2(speed, mybody.velocity.y);
    }
}
