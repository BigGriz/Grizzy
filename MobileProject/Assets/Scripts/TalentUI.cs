using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentUI : MonoBehaviour
{
    // Local Variables
    Animator anim;
    bool show;

    #region Setup
    private void Awake()
    {
        anim = GetComponent<Animator>();
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
