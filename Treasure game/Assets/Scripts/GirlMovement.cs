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
     Vector2 currentMovementInput;
     Vector3 currentMovement;
     Vector3 currentRunMovement;

     int isWalkingHash;
     int isRunningHash;
     
     bool isMovementPressed;
     bool isRunPressed;
     float rotationFactorPerFrame = 15.0f;
     float runMultiplier = 5.0f;
     
      void Awake()
     {
         girlInput= new PlayerInput();
         characterController = GetComponent<CharacterController>();
         animator = GetComponent<Animator>();

         isWalkingHash = Animator.StringToHash("isWalking");
         isRunningHash = Animator.StringToHash("isRunning");
         
         girlInput.GirlControls.Move.started += onMovementInput;
         // when players release the key (walking)
         girlInput.GirlControls.Move.canceled += onMovementInput;
         girlInput.GirlControls.Move.performed += onMovementInput;
         // when players is running
         girlInput.GirlControls.Run.started += onRun;
         girlInput.GirlControls.Run.canceled += onRun;
     }

      void onRun(InputAction.CallbackContext context)
      {
          isRunPressed=context.ReadValueAsButton();
      }
      
      void onMovementInput(InputAction.CallbackContext context)
     {
         // storing the values in our code
         currentMovementInput = context.ReadValue<Vector2>(); 
         // setting the x axis to be the currentMovementInput value
         currentMovement.x = currentMovementInput.x;
         // setting the y axis to be the currentMovementInput value
         // z because the movement is controlled on X and Z axis 
         currentMovement.z = currentMovementInput.y;
         currentRunMovement.x = currentMovementInput.x * runMultiplier;
         currentRunMovement.z = currentMovementInput.y * runMultiplier;
         // value grater than 0 or less than 0 
         isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
     }

     void rotationHandler()
     {
         // where we are moving next
         Vector3 positionToLookAt;
         // the change
         positionToLookAt.x = currentMovement.x;
         positionToLookAt.y = 0.0f;
         positionToLookAt.z = currentMovement.z;
         // rotation of the character
         Quaternion currentRotation = transform.rotation;
         if (isMovementPressed)
         {
             // new rotation 

             Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
             // smooth rotation- time.deltaTime for making it a fraction of a second
             transform.rotation =
                 Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
         }
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
            // Time.deltaTime - fraction of a second to make the move smooth 
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
}
