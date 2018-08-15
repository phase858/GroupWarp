using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Tools;

namespace GroupWarp
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            InputEvents.ButtonPressed += this.InputEvents_ButtonPressed;
        }

        private void InputEvents_ButtonPressed(object sender, EventArgsInput e)
        {
            if (!Context.IsWorldReady)
                return;
        
        if (Game1.player.CurrentTool is Wand && e.Button == SButton.MouseRight)
        {
                int power = (int)(((double)Game1.toolHold + 20.0) / 600.0) + 1;

                foreach (Farmer farmer in Game1.getOnlineFarmers())
                {
                    if (farmer.Name != Game1.player.Name)
                    {
                        /*this.Monitor.Log(farmer.Name);
                        this.Monitor.Log(power.ToString());
                        this.Monitor.Log(farmer.currentLocation.ToString());
                        Game1.player.CurrentTool.DoFunction(farmer.currentLocation, farmer.getStandingX(), farmer.getStandingY(), 45, farmer);*/
                        farmer.warpFarmer(new Warp (farmer.getStandingX(), farmer.getStandingY(), "Farm", 64, 15, false));
                    }                
                }
                //Game1.player.CurrentTool.DoFunction(Game1.player.currentLocation, Game1.player.getStandingX(), Game1.player.getStandingY(), 45, Game1.player);

                //Game1.warpFarmer("Farm", 64, 15, false);
                //int power = (int)(((double)Game1.toolHold + 20.0) / 600.0) + 1;
                //Game1.player.CurrentTool.DoFunction(Game1.currentLocation, Game1.player.getStandingX(), Game1.player.getStandingY(), power, Game1.player);
            }
        }
    }
}