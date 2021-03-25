using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public static Tooltip instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one Tooltip exists!");
            Destroy(this);
        }
        instance = this;
        image = GetComponent<UnityEngine.UI.Image>();
    }

    new public TMPro.TextMeshProUGUI name;
    public TMPro.TextMeshProUGUI desc;
    UnityEngine.UI.Image image;

    private void Start()
    {
        SetEmpty();
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(container, Input.mousePosition, Camera.main, out localPoint);
        transform.localPosition = new Vector3(localPoint.x, localPoint.y, 1);
    }

    public RectTransform container;

    // Add in types here
    public void SetText(TalentSO _talent)
    {
        image.enabled = true;
        name.SetText(_talent.name);
        string description = "Added Flat Damage: " + _talent.addedFlat;

        if (_talent.level == _talent.maxLevel)
        {
            desc.SetText(description);
            return;
        }
        description += "\nNext Level: " + _talent.GetNextLevel();
        desc.SetText(description);
    }

    public void SetEmpty()
    {
        image.enabled = false;
        name.SetText("");
        desc.SetText("");
    }
}
