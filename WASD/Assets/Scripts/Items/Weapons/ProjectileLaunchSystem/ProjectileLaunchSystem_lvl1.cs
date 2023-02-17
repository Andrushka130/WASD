using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponResources;

public class ProjectileLaunchSystem_lvl1 : ProjectileLaunchSystem
{    
    public override string Name => WeaponName.ProjectileLauncherSystem + WeaponName.Lvl_1;
    public override string Description => "Shoots out explosions to one enemy near the player.";
    public override int WeaponLevel => 1;
    public override int Value => 10;
    public override float Dmg => 10;
    public override float CritDmg => 2f;
    public override int CritChance => 10;    
    public override float AtkSpeed => 1f;
    public override Rarity RarityType => Rarity.Common;   
    protected override GameObject BulletPrefab { get; set; }
    protected override EnemyDetectionCircle EnemyDetectionCircle { get; set; }
    protected override float CircleRadius => 10f;

    private void Start()
    {
        EnemyDetectionCircle = new EnemyDetectionCircle();
        BulletPrefab = Resources.Load(WeaponAttacks.ProjectileLaunchSystem) as GameObject;
    }

    public override void InstantiateWeaponPrefab()
    {
        Collider2D enemyDetector;
        enemyDetector = EnemyDetectionCircle.getFirstEnemyAroundPlayer(CircleRadius);       

        if(enemyDetector.TryGetComponent<Enemy>(out Enemy enemy)){
            GameObject bullet = Instantiate(BulletPrefab, enemyDetector.transform.position, enemyDetector.transform.rotation);
            FindObjectOfType<AudioManager>().Play("Launcher");
            Destroy(bullet, 0.25f);
        }              
    }       
}
