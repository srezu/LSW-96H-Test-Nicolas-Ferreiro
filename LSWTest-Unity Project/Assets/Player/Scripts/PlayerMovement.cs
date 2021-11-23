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


   private void Awake()
   {
       _rb = GetComponent<Rigidbody2D>();
       _playerInput = GetComponent<PlayerInput>();
   }
    
   private void FixedUpdate()
   {
       _rb.MovePosition(_rb.position + _playerInput.movement * movementSpeed * Time.fixedDeltaTime);
   }
   
}
