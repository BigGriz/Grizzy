using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentUI : MonoBehaviour
{
    // Local Variables
    Animator anim;
    bool show;

    public TalentSO talentModifiers;
    List<TalentSO> talents;

    #region Setup
    private void Awake()
    {
        anim = GetComponent<Animator>();
        talents = new List<TalentSO>();
    }

    private void Start()
    {
        foreach(Talent n in GetComponentsInChildren<Talent>())
        {
            talents.Add(n.talent);
        }
    }
    #endregion Setup

    private void Update()
    {
        // Need some sort of menu manager
        if (Input.GetKeyDown(KeyCode.N))
        {
            show = !show;
            anim.SetBool("ShowTalents", show);
        }
    }
}
