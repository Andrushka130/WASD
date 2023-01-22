using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyAnimationHandler : MonoBehaviour
{
    private Vector2 posLastFrame;
    private Vector2 newPosition;

    private void Update()
    {
        flipSprite();
    }

    public void flipSprite()
    {
        posLastFrame = newPosition;
        newPosition = transform.position;
        if (newPosition.x > posLastFrame.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (newPosition.x < posLastFrame.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
