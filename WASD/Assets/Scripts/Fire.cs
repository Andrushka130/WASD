using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Weapon weapon;
    Vector2 mousePosition;
    public float timer;
    public float cooldown = 1f;
    public Rigidbody2D rb;


    // Update is called once per frame
    void Update()
    {
        weapon = GameObject.Find("Weapon").GetComponent<Weapon>();
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            weapon.Fire();
            timer = 0;
        }
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {        
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}
