using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public Animator animator;

    public SpriteRenderer spriteRenderer;
    private Characters currentChar;

    private void Start() {
        currentChar = CharactersManager.CurrentChar;
        spriteRenderer.sprite = currentChar.CharSprite;
    }

    public void flipSprite(Vector2 movement)
    {
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    public void setSpeed(Vector2 movement)
    {
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
