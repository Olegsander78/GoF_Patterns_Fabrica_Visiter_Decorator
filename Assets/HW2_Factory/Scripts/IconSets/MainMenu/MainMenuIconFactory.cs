using System;
using UnityEngine;

namespace Assets.HW2_Factory
{
    public class MainMenuIconFactory : IconFactory
    {
        public override Icon Get(IconTypes iconTypes)
        {
            switch (iconTypes)
            {
                case IconTypes.COIN:
                    var coinSprite = Resources.Load<Sprite>("coin_menu");
                    return new MainMenuIconCoin(iconTypes, coinSprite);
                case IconTypes.ENERGY:
                    var energySprite = Resources.Load<Sprite>("energy_menu");
                    return new MainMenuIconEnergy(iconTypes, energySprite);
                default:
                    throw new ArgumentException(nameof(iconTypes));
            }
        }
    }
}