using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : PlayerAttribute1
{
    public Rigidbody2D rb;
    public Weapon weapon;

    private float timer;
    
    Vector2 moveDirection;
    Vector2 mousePosition;

    private PlayerData _playerData;

    /* void Start()
{
    _playerData = PlayerData.Instance;
    _playerData.PlayerTag = "Test2";
    _playerData.Password = "1234";
    _playerData.Email = "adfdf";
    _playerData.Highscore = 16;

    //StartCoroutine(Database.CreateAccount(_playerData, result => {Debug.Log(result);}));
    //StartCoroutine(Database.GetHighscore(result => {Debug.Log(PlayerData.ParseAll(result));}));
    //StartCoroutine(Database.GetHighscore(_playerData.PlayerTag, result => {Debug.Log(PlayerData.Parse(result).Highscore);}));
    //StartCoroutine(_db.UpdateHighscore(_playerData, result => {Debug.Log(result);}));
    //StartCoroutine(Database.Login(_playerData, result => {Debug.Log(result);}));
    //StartCoroutine(_db.ChangeAccount(_playerData, result => {Debug.Log(result);}));
    //StartCoroutine(_db.DeleteAccount(_playerData.playerTag, result => {Debug.Log(result);}));
} */

    // Update is called once per frame
    void Update()
    {
        weapon = GameObject.Find("Weapon").GetComponent<Weapon>();
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
