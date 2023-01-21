using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerAnimationManager playerAnimationManager;    
    
    void Update()
    {
        playerMovement.getMovementInput();
        playerAnimationManager.setSpeed(playerMovement.movementVector);
        playerAnimationManager.flipSprite(playerMovement.movementVector);
    }

    private void FixedUpdate()
    {
        playerMovement.movePlayer();
    }
}
