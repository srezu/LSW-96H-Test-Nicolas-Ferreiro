using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [Header("Player settings")]
   public float movementSpeed = 10f;
   
   
   private Rigidbody2D _rb;
   private PlayerInput _playerInput;
   private Animator _playerAnim;

   public bool playerIsMove;

   private void Awake()
   {
       _rb = GetComponent<Rigidbody2D>();
       _playerInput = GetComponent<PlayerInput>();
       _playerAnim = GetComponent<Animator>();
   }

   private void Update()
   {
       _playerAnim.SetFloat("HorizontalX", _playerInput.movement.x);
       _playerAnim.SetFloat("VerticalY", _playerInput.movement.y);
   }

   private void FixedUpdate()
   {
       _rb.MovePosition(_rb.position + _playerInput.movement * movementSpeed * Time.fixedDeltaTime);
   }
   
   
   private void UpdateAnimValues()
   {
       if (_playerInput.movement.y == 0)
       {
           _playerAnim.SetFloat("HorizontalX", _playerInput.movement.x);
           _playerAnim.SetFloat("VerticalY", 0);
       }

       if (_playerInput.movement.x == 0)
       {
           _playerAnim.SetFloat("VerticalY", _playerInput.movement.y);
           _playerAnim.SetFloat("HorizontalX", 0);
       }
   }
}
