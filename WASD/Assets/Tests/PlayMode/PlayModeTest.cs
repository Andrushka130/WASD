using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;


public class PlayModeTest
{
      [OneTimeSetUp]
    public void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    [UnityTest]
    public IEnumerator EnemySpawningAmount()
    {
        yield return new WaitForSeconds(5f);
        
        GameObject[] gameObject = GameObject.FindGameObjectsWithTag("Enemy");

        Assert.IsTrue(gameObject.Length <= 8);
    }    

    [UnityTest]
    public IEnumerator CheckStarterWeapon()
    {
        yield return null;
        
        // Suche nach der Waffe Hacking_lvl1 im Spiel
        var gameObject = GameObject.Find("Weapon").GetComponent<Hacking_lvl1>();

        // das vorhandene Inventar holen
        WeaponInventory inventory = WeaponInventory.GetInstance();

        // neue Liste an Waffen ersten und Hacking_lvl1 hinzufügen
        List <Weapon> equWeapons = new List<Weapon>();
        equWeapons.Add(gameObject.GetComponent<Hacking_lvl1>());

        //Vergleiche beide Liste Anfangswaffe im Inventar soll der erstellten Waffenliste gleichen
        Assert.AreEqual(equWeapons, inventory.GetWeapons());
    }

    [UnityTest]
    public IEnumerator CheckForMusix()
    {
        yield return new WaitForSeconds(2f);
        var gameObject = GameObject.Find("AudioManager");
        AudioSource song = gameObject.GetComponent<AudioSource>();

        Assert.IsNotNull(song);
    }

}
