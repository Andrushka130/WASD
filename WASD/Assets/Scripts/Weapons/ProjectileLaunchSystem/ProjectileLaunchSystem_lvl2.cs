using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public class ProjectileLaunchSystem_lvl2 : ProjectileLaunchSystem, IProjectileLaunchWeapon, IBuyable
{
    
    public override string Name => WeaponName.ProjectileLauncherSystem + WeaponName.Lvl_2;
    public override string Description => "Upgrade: Shoots 2 explosions at once.";
    public override int WeaponLevel => 2;
    public override int Value => 15;
    public override float Dmg => 20;
    public override float CritDmg => 2.5f;
    public override int CritChance => 7;
    public override float Lifesteal => 0f;
    public override float AtkSpeed => 1.5f;
    public override Rarity RarityType => Rarity.Epic;    
    public GameObject BulletPrefab { get; set; }
    public EnemyDetectionCircle EnemyDetectionCircle { get; set; }
   

    private void Start()
    {
        EnemyDetectionCircle = new EnemyDetectionCircle();
        BulletPrefab = Resources.Load(WeaponAttacks.ProjectileLaunchSystem + WeaponAttacks.Lvl_2) as GameObject;        
    }

    public override void InstantiateWeaponPrefab()
    {               
        Collider2D[] enemys;
        enemys = EnemyDetectionCircle.getEnemysAroundPlayer(20f);                    

        for(int numberOfEnemys = 0; numberOfEnemys <= 1; numberOfEnemys++){
            if(enemys[numberOfEnemys].TryGetComponent<Enemy>(out Enemy enemy)){
                GameObject bullet = Instantiate(BulletPrefab, enemys[numberOfEnemys].transform.position, enemys[numberOfEnemys].transform.rotation);
                FindObjectOfType<AudioManager>().Play("Launcher");
                Destroy(bullet, 0.25f);
            }
        }   
        
    }    
}
