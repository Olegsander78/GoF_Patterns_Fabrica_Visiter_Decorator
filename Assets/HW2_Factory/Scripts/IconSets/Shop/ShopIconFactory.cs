using System;
using UnityEngine;

namespace Assets.HW2_Factory
{
    public class ShopIconFactory : IconFactory
    {
        public override Icon Get(IconTypes iconTypes)
        {
            switch (iconTypes)
            {
                case IconTypes.COIN:
                    var coinSprite = Resources.Load<Sprite>("coin_shop");
                    return new ShopIconCoin(iconTypes, coinSprite);
                case IconTypes.ENERGY:
                    var energySprite = Resources.Load<Sprite>("energy_shop");
                    return new ShopIconEnergy(iconTypes, energySprite);
                default:
                    throw new ArgumentException(nameof(iconTypes));
            }
        }
    }
}
