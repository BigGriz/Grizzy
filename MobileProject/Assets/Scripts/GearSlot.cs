using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GearSlot : MonoBehaviour, IPointerDownHandler
{
    #region Setup
    public Image image;
    List<TMPro.TextMeshProUGUI> textComponents;
    private void Awake()
    {
        textComponents = new List<TMPro.TextMeshProUGUI>();
        foreach(TMPro.TextMeshProUGUI n in GetComponentsInChildren<TMPro.TextMeshProUGUI>())
        {
            textComponents.Add(n);
        }
    }
    #endregion Setup
    Gear gear;

    private void Start()
    {
        EquipItem(gear);
    }

    public bool HasGear()
    {
        return (gear);
    }

    public void EquipItem(Gear _gear)
    {
        gear = _gear;

        if (gear)
        {
            image.enabled = true;
            image.sprite = gear.sprite;
            textComponents[0].SetText(gear.name);
            textComponents[1].SetText(gear.level.ToString());
            textComponents[2].SetText(gear.damage.ToString());
            textComponents[3].SetText(gear.upgradeCost.ToString());

            return;
        }

        image.enabled = false;
        textComponents[0].SetText("");
        textComponents[1].SetText("");
        textComponents[2].SetText("");
        textComponents[3].SetText("");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!gear)
            return;

        gear.Upgrade();
        EquipItem(gear);
    }
}
