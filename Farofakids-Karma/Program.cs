﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using SharpDX;
using Color = System.Drawing.Color;

namespace Farofakids_Karma
{
    internal class Program
    {

        public static void Main()
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        public static bool MantraIsActive
        {
            get { return ObjectManager.Player.HasBuff("KarmaMantra"); }
        }

        public static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.BaseSkinName != "Karma") return;
            SPELLS.Initialize();
            MENUS.Initialize();
            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += Drawing_OnDraw;
            Interrupter.OnInterruptableSpell += MODES.Interrupter_OnInterruptableSpell;
            Gapcloser.OnGapcloser += MODES.Gapcloser_OnGapcloser;

        }


        public static void Drawing_OnDraw(EventArgs args)
        {
            if (MENUS.QRange && SPELLS.Q.Handle.IsLearned)
                Drawing.DrawCircle(Player.Instance.Position, SPELLS.Q.Range, Color.Red);
            if (MENUS.WRange && SPELLS.W.Handle.IsLearned)
                Drawing.DrawCircle(Player.Instance.Position, SPELLS.W.Range, Color.Red);
            if (MENUS.ERange && SPELLS.E.Handle.IsLearned)
                Drawing.DrawCircle(Player.Instance.Position, SPELLS.E.Range, Color.Red);
            if (MENUS.RRange && SPELLS.R.Handle.IsLearned)
                Drawing.DrawCircle(Player.Instance.Position, SPELLS.R.Range, Color.Red);
        }

        public static void Game_OnTick(EventArgs args)
        {
            if (Player.Instance.IsDead) return;

            SPELLS.Q.Width = MantraIsActive ? 80 : 60;
            SPELLS.Q.Range = MantraIsActive ? 1250u : 1050u;

            switch (Orbwalker.ActiveModesFlags)
            {
                case Orbwalker.ActiveModes.Combo:
                    MODES.Combo();
                    break;

                case Orbwalker.ActiveModes.Harass:
                    MODES.Harras();
                    break;
            }

        }
    }
}