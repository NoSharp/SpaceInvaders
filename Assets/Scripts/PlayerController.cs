using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Utils;
using MathUtils = Utils.MathUtils;

public class PlayerController : MonoBehaviour
{

    private readonly Vector2 _cameraMins = new Vector2(-10, -10);
    private readonly Vector2 _cameraMaxs = new Vector2(10, 10);
    
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
        _playerRigidbody.position = _playerRigidbody.position.ClampX(_cameraMins, _cameraMaxs);
    }
}
