using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerDownHandler
{
    public Animator anim;
    
    public void Press()
    {
        anim.SetBool("Show", !anim.GetBool("Show"));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Press();
    }

}
