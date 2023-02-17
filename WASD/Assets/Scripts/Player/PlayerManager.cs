using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerAnimationManager playerAnimationManager;
    
    private void Update()
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
