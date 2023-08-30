using System;
using UnityEngine;

public class IconHandler : MonoBehaviour
{
    [SerializeField] private PlaceForUseIconTypes _placeForUse;

    [SerializeField] private UIPanel _uIPanel;

    [ContextMenu("SetIcons")]
    public void SetIcons()
    {
        IconFactory iconFactory;

        switch (_placeForUse)
        {
            case PlaceForUseIconTypes.MAIN_MENU:
                iconFactory = new MainMenuIconFactory();
                break;
            case PlaceForUseIconTypes.SHOP:
                iconFactory = new ShopIconFactory();
                break;
            default:
                throw new ArgumentException(nameof(_placeForUse));
        }

        _uIPanel.SetIconCoin(iconFactory.Get(IconTypes.COIN).SpriteIcon);
        _uIPanel.SetIconEnergy(iconFactory.Get(IconTypes.ENERGY).SpriteIcon);
    }
}
