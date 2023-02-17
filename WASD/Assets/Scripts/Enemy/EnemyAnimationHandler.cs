using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{
    private Vector2 posLastFrame;
    private Vector2 newPosition;        

    private void Update()
    {
        flipSprite();        
    }

    private void flipSprite()
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
