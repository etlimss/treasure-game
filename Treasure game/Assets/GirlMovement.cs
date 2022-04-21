using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GirlMovement : MonoBehaviour
{
     PlayerInput girlInput;
     CharacterController characterController;
     Animator animator;

      int isWalkingHash;
      int isRunningHash;
     
     Vector2 currentMovementInput;
     Vector3 currentMovement;
     Vector3 currentRunMovement;
     bool isMovementPressed;
     bool isRunPressed;
     float rotationFactorPerFrame = 15.0f;
     float runMultiplier = 3.0f;
     private bool isJumping;
     private bool isGrounded;
     
     

      void Awake()
     {
         girlInput= new PlayerInput();
         characterController = GetComponent<CharacterController>();
         animator = GetComponent<Animator>();

         isWalkingHash = Animator.StringToHash("isWalking");
         isRunningHash = Animator.StringToHash("isRunning");
         girlInput.GirlControls.Move.started += onMovementInput;
         girlInput.GirlControls.Move.canceled += onMovementInput;
         girlInput.GirlControls.Move.performed += onMovementInput;
         girlInput.GirlControls.Run.started += onRun;
         girlInput.GirlControls.Run.canceled += onRun;
     }

      void onRun(InputAction.CallbackContext context)
      {
          isRunPressed=context.ReadValueAsButton();
      }

      void rotationHandler()
      {
          Vector3 positionToLookAt;

          positionToLookAt.x = currentMovement.x;
          positionToLookAt.y = 0.0f;
          positionToLookAt.z = currentMovement.z;

          Quaternion currentRotation = transform.rotation;
          if (isMovementPressed)
          {
              Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
              transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
          }
      }

     void onMovementInput(InputAction.CallbackContext context)
     {
         currentMovementInput = context.ReadValue<Vector2>();
         currentMovement.x = currentMovementInput.x;
         currentMovement.z = currentMovementInput.y;
         currentRunMovement.x = currentMovementInput.x * runMultiplier;
         currentRunMovement.z = currentMovementInput.y * runMultiplier;
         isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
             
     }

     void animatorHandler()
     {
         bool isWalking = animator.GetBool(isWalkingHash);
         bool isRunning = animator.GetBool(isRunningHash);

         if (isMovementPressed && !isWalking)
         {
             animator.SetBool("isWalking", true);
         }
         else if (!isMovementPressed && isWalking)
         {
             animator.SetBool("isWalking", false);
         }
         if((isMovementPressed && isRunPressed) && !isRunning)
         {
             animator.SetBool(isRunningHash, true);
         }
         else if ((!isMovementPressed || !isRunPressed) && isRunning)
         {
             animator.SetBool(isRunningHash, false);
         }
     }

     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationHandler();
        animatorHandler();
        if (isRunPressed)
        {
            characterController.Move(currentRunMovement * Time.deltaTime); 
        }
        else
        {
            characterController.Move(currentMovement * Time.deltaTime);
        }
    }

     void OnEnable()
     {
         girlInput.GirlControls.Enable();
     }

      void OnDisable()
     {
         girlInput.GirlControls.Disable();
     }
}
