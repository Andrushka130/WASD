using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public class ProjectileLaunchSystem_lvl3 : ProjectileLaunchSystem, IBuyable
{    
    public override string Name => WeaponName.ProjectileLauncherSystem + WeaponName.Lvl_3;
    public override string Description => "Upgrade: Increased size of explosion.";
    public override int WeaponLevel => 3;
    public override int Value => 25;
    protected override float Dmg => 30;
    protected override float CritDmg => 3f;
    protected override int CritChance => 4;
    public override float Lifesteal => 0f;
    protected override float AtkSpeed => 1f;
    public override Rarity RarityType => Rarity.Legendary;   
    protected override GameObject BulletPrefab { get; set; }
    protected override EnemyDetectionCircle EnemyDetectionCircle { get; set; }   
    protected override float CircleRadius => 20f; 

    private void Start()
    {
        EnemyDetectionCircle = new EnemyDetectionCircle();
        BulletPrefab = Resources.Load(WeaponAttacks.ProjectileLaunchSystem + WeaponAttacks.Lvl_3) as GameObject;
    }

    public override void InstantiateWeaponPrefab()
    {                          
        Collider2D[] enemys;
        enemys = EnemyDetectionCircle.getEnemysAroundPlayer(CircleRadius);                    

        for(int numberOfEnemys = 0; numberOfEnemys <= 2; numberOfEnemys++){
            if(enemys[numberOfEnemys].TryGetComponent<Enemy>(out Enemy enemyAI)){
                GameObject bullet = Instantiate(BulletPrefab, enemys[numberOfEnemys].transform.position, enemys[numberOfEnemys].transform.rotation);
                FindObjectOfType<AudioManager>().Play("Launcher");
                Destroy(bullet, 0.25f);
            }
        }   
        
    }
    
}
