using System;

namespace WeaponResources
{
    public static class WeaponName
    {
        public static readonly string Hacking = "Hacking";
        public static readonly string GorillaArms = "GorillaArms";
        public static readonly string Katana = "Katana";
        public static readonly string ProjectileLauncherSystem = "ProjectileLauncherSystem";
        public static readonly string Revolver = "Revolver";

        public static readonly string Lvl_1 = " Level 1";
        public static readonly string Lvl_2 = " Level 2";
        public static readonly string Lvl_3 = " Level 3";
    }

    public static class WeaponIconPath
    {
        public static readonly string HackingIcon = "IconOrdner/Hacking.png";
        public static readonly string GorillaArmsIcon = "IconOrdner/Gorilla.png";
        public static readonly string KatanaIcon = "IconOrdner/Katana.png";
        public static readonly string RevolverIcon = "IconOrdner/Revolver.png";
        public static readonly string ProjectileLauncherSystemIcon = "IconOrdner/Launched.png";
    }

    public static class WeaponAttacks
    {
        public static readonly string Hacking = "Bullets/HackingBullets/HackingBullet";
        public static readonly string GorillaArm = "MeleeAttacks/GorillaArm/GorillaArm";
        public static readonly string Katana = "MeleeAttacks/KatanaSwipes/KatanaSwipe";
        public static readonly string ProjectileLaunchSystem = "Bullets/ProjectileLaunchSystemProjectile/ProjectileExplosion";
        public static readonly string Revolver = "Bullets/RevolverBullets/RevolverBullet";

        public static readonly string Lvl_2 = "_2";
        public static readonly string Lvl_3 = "_3";
    }

    public static class WeaponFirePoints
    {
        public static readonly string FirePoint = "firepoint";
        public static readonly string FirePointLeft = "firePointLeft";
        public static readonly string FirePointUp = "firePointUp";
        public static readonly string FirePointDown = "firePointDown";
        public static readonly string FirePointMelee = "firePointMelee";
    }
}