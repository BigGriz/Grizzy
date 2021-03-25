using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUI : MonoBehaviour
{
    #region Setup
    TMPro.TextMeshProUGUI textComponent;
    private void Awake()
    {
        textComponent = GetComponentInChildren<TMPro.TextMeshProUGUI>();
    }
    #endregion Setup
    #region Callbacks
    // Start is called before the first frame update
    void Start()
    {
        UIController.instance.updateDamage += UpdateDamage;
    }
    private void OnDestroy()
    {
        UIController.instance.updateDamage -= UpdateDamage;
    }
    #endregion Callbacks

    public void UpdateDamage(float _damage)
    {
        textComponent.SetText(Mathf.RoundToInt(_damage).ToString());
    }
}
