using System;
using System.Collections.Generic;
using System.Text;

namespace RollTheDice
{
    class WeaponBuilder
    {
        public enum Camo { None = 0, Classic = 1, Snow = 2, Multicam = 3, DigitalUrban = 4, Hex = 5, Choco = 6, Snake = 7, Blue = 8, Red = 9, Autumn = 10, Gold = 11 };
        public enum Reticle { None = 0, TargetDot = 1, Delta = 2, UDot = 3, MilDot = 4, Omega = 5, Lambda = 6 };
        public enum Attachment
        {
            none,
            acog,
            acogsmg,
            reflex,
            reflexsmg,
            reflexlmg,
            silencer,
            silencer02,
            silencer03,
            grip,
            gl,
            gp25,
            m320,
            akimbo,
            thermal,
            thermalsmg,
            shotgun,
            heartbeat,
            fmj,
            rof,
            xmags,
            eotech,
            eotechsmg,
            eotechlmg,
            tactical,
            /*vzscope,*/
            hamrhybrid,
            hybrid,
            zoomscope,
            scope,
            scopevz
        };
        static string[] snipers = { "barrett", "rsass", "dragunov", "msr", "l96a1", "as50" };
        static string remove(string source, string needle)
        {
            return source.Replace(needle, "");
        }
        public static string CreateWeapon(string name, Attachment Attachment1)
        {
            return CreateWeapon(name, Attachment1, Attachment.none, Camo.None, Reticle.None);
        }
        public static string CreateWeapon(string name)
        {
            return CreateWeapon(name, Attachment.none, Attachment.none, Camo.None, Reticle.None);
        }
        public static string CreateWeapon(string name, Attachment Attachment1, Attachment Attachment2)
        {
            return CreateWeapon(name, Attachment1, Attachment2, Camo.None, Reticle.None);
        }
        public static string CreateWeapon(string name, Attachment Attachment1, Attachment Attachment2, Camo Camo)
        {
            return CreateWeapon(name, Attachment1, Attachment2, Camo, Reticle.None);
        }
        public static string CreateWeapon(string name, Attachment Attachment1, Attachment Attachment2, Camo Camo, Reticle Reticle)
        {
            if (name.Substring(0, 4) != "iw5_" && name.EndsWith("_mp"))
                return name;
            else if (name.Substring(0, 4) != "iw5_" && !name.EndsWith("_mp"))
                return name + "_mp";

            string basename = remove(remove(name, "iw5_"), "_mp"); // remove iw5 & mp

            bool sniper = false;
            foreach (string s in snipers)
            {
                if (s == basename)
                {
                    sniper = true;
                    break;
                }
            }

            string a1 = Attachment1.ToString();
            if (sniper)
                a1 = basename + a1;

            string a2 = Attachment2.ToString();
            if (sniper)
                a2 = basename + a2;



            string x = string.Format("iw5_{0}_mp_{1}_{2}_camo{3}_scope{4}", basename, a1, a2, Convert.ToInt32(Camo), Convert.ToInt32(Reticle));
            Core.WriteDebug("[WeaponBuilder] Weapon created: " + x);
            return x;
        }
    }
}
