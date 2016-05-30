﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;

namespace Farofakids_Heimerdinger
{
    internal class SPELLS
    {
        public static Spell.Skillshot Q, Q1, W, W1, E, E1, E2, E3;
        public static Spell.Active R;


        public static void Initialize()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 325, SkillShotType.Linear, 250, 2000, 90);
            W = new Spell.Skillshot(SpellSlot.W, 1100, SkillShotType.Linear, 500, 3000, 40);
            W1 = new Spell.Skillshot(SpellSlot.W, 1100, SkillShotType.Linear, 500, 3000, 40);
            E = new Spell.Skillshot(SpellSlot.E, 925, SkillShotType.Circular, 500, 1200, 120);
            E1 = new Spell.Skillshot(SpellSlot.E, 925, SkillShotType.Circular, 500, 1200, 120);
            E2 = new Spell.Skillshot(SpellSlot.E, 1125, SkillShotType.Circular, 250 + E1.CastDelay, 1200, 120);
            E3 = new Spell.Skillshot(SpellSlot.E, 1325, SkillShotType.Circular, 300 + E2.CastDelay, 1200, 120);
            R = new Spell.Active(SpellSlot.R, 100);
        }

        public static float GetComboDamage(Obj_AI_Base enemy)
        {
            var damage = 0d;

            if (Q.IsReady())
                damage += Player.Instance.GetSpellDamage(enemy, SpellSlot.Q);

            if (W.IsReady())
                damage += Player.Instance.GetSpellDamage(enemy, SpellSlot.W);

            if (E.IsReady())
                damage += Player.Instance.GetSpellDamage(enemy, SpellSlot.E);

            if (R.IsReady())
                damage += Player.Instance.GetSpellDamage(enemy, SpellSlot.R);

            return (float)damage;
        }

    }
}
