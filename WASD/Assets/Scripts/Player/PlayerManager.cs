using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerAnimationManager playerAnimationManager;
    private Database db = new Database();

    private void Awake() 
    {
        PlayerData.Instance.LoadPlayerData();
    }

    private async void Start() {
        Debug.Log("Test");
        Debug.Log(await db.GetHighscore("Test"));
    }
    
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
