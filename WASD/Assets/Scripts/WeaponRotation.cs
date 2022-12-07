using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    //Mouse position
    //Reference to the weapon/firepoint
    //pivot point
    private Camera mainCam;
    private Vector3 mousePos;
    private Weapon weapon;
    public float timer;
    public float cooldown = 1f;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        weapon = GameObject.Find("Weapon").GetComponent<Weapon>();

        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            weapon.Fire();
            timer = 0;
        }
    }


}
