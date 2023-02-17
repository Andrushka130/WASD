using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EditModeTest
{
    [Test]
    public void weaponKatanaDmg()
    {
        var gameObject = new GameObject();
        Katana Katanalv1 = gameObject.AddComponent<Katana_lvl1>();

        Assert.AreEqual(2f, Katanalv1.Dmg);
    }

    [Test]
    public void hackingDmg()
    {
        var gameObject = new GameObject();
        Hacking hackinglvl1 = gameObject.AddComponent<Hacking_lvl1>();

        Assert.AreEqual(3f, hackinglvl1.Dmg);
        Assert.AreEqual(1.3f, hackinglvl1.CritDmg);
        Assert.AreEqual(1f, hackinglvl1.AtkSpeed);
    }
}
