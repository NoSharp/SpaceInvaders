using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using MathUtils = Utils.MathUtils;

public class PlayerController : MonoBehaviour
{

    private SpriteRenderer _playerRenderer;
    private Rigidbody2D _playerRigidbody;

    private Vector3 _wishVelocity;
    
    void Start()
    {
        _playerRenderer = GetComponentInParent<SpriteRenderer>();
        _playerRigidbody = GetComponentInParent<Rigidbody2D>();
        SetupRigidBody();
    }

    private void SetupRigidBody()
    {
        _playerRigidbody.gravityScale = 0;
    }

    private Vector3 GetDirection()
    {
        var xDir = 0;
        var yDir = 0;

        if (Input.GetKey(KeyCode.W))
        {
            yDir += 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            yDir -= 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            xDir -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            xDir += 1;
        }

        return new Vector2(xDir, yDir);
    }
    
    void FixedUpdate()
    {
        _wishVelocity = GetDirection() * 15;
        _playerRigidbody.velocity = MathUtils.LerpVector(_playerRigidbody.velocity, _wishVelocity, Time.deltaTime*5);
    }
}
