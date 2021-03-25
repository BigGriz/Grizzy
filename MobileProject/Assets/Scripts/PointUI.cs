using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointUI : MonoBehaviour
{
    TMPro.TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    private void Start()
    {
        UIController.instance.updateTalentPoints += UpdateTalentPoints;
    }
    private void OnDestroy()
    {
        UIController.instance.updateTalentPoints -= UpdateTalentPoints;
    }

    public void UpdateTalentPoints(int _points)
    {
        text.SetText("POINTS: " + _points.ToString());
    }
}
