﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace RealTimeClock
{
    public class RealTimeClock : ModSystem
    {
        internal static ModKeybind ResetDeathCache;
        public RealTimeClock()
        {
            
        }
        
         public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)/* tModPorter Note: Removed. Use ModSystem.ModifyInterfaceLayers */
        {
            Config cfg = ModContent.GetInstance<Config>();
            int mouseText = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (cfg.clockEnabled && mouseText != -1)
            {
                layers.Insert(mouseText, new LegacyGameInterfaceLayer("RealTime: Player Name", delegate
                {
                    string text = DateTime.Now.ToString(cfg.clockFormat);
                    int offset = cfg.offset;
                    Vector2 overridePosition = cfg.position;
                    Vector2 position = overridePosition.Y != -1 ? overridePosition * new Vector2(Main.screenWidth, Main.screenHeight) : new Vector2(Main.miniMapWidth * 0.7f + Main.miniMapX, Main.miniMapY);
                    if (Main.mapStyle == 1)
                    {
                        position = overridePosition.Y != -1 ? overridePosition * new Vector2(Main.screenWidth, Main.screenHeight) : new Vector2(Main.miniMapWidth * 0.7f + Main.miniMapX, Main.miniMapHeight + Main.miniMapY + offset);
                    }
                    Utils.DrawBorderString(Main.spriteBatch, text, position, Color.WhiteSmoke);
                    return true;
                }, InterfaceScaleType.UI));
            }
        }
    }
}