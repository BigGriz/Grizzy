using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum TalentType
{
    Passive,
    Active
}

public class Talent : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TalentType type;
    public Talent talentDependency;
    public int level = 0;
    public int maxLevel = 10;
    TMPro.TextMeshProUGUI text;

    public TalentSO talent;

    private void Awake()
    {
        text = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        text.SetText(level.ToString());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (talent.level < talent.maxLevel && PlayerInventory.instance.SpendTalentPoint())
        {
            if (talent.level == 0 && type == TalentType.Active)
            {
                // Add to Action Bar
                talent.AddLevel();
                return;
            }
            talent.AddLevel();
            text.SetText(level.ToString());
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.instance.SetText(talent);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.instance.SetEmpty();
    }
}
