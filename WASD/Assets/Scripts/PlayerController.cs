using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerAttribute1
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;

    public float timer;
    public float cooldown = 1f;
    
    Vector2 moveDirection;
    Vector2 mousePosition;

    private PlayerData _playerData;
    private Datenbank db;

    void Start()
    {
        db = Datenbank.Instance;
        _playerData = new PlayerData();
        _playerData.playerTag = "Test1";
        _playerData.highscore = 1;

        StartCoroutine(db.DownloadOne(_playerData.playerTag, result => {
            Debug.Log(result.playerTag);
        }));
        StartCoroutine(db.DownloadAll(result => {
            Debug.Log(result.Items[0].highscore);
        }));
        /*StartCoroutine(db.Upload(_playerData.Stringify(), result => {
            Debug.Log(result);
        }));*/
    }
    
    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        timer += Time.deltaTime;
        
        if(timer > (10 / attackSpeed.GetValue()))
        {
            weapon.Fire();
            timer = 0;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * movementSpeed.GetValue(), moveDirection.y * movementSpeed.GetValue());
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    /* Hier muss die Konnection zum Inventar gezogen werden

    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged (Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }
        
        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }
    */
}
