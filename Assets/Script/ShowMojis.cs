using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMojis : MonoBehaviour
{
    public Animator animatorPassOK;
    public Animator animatorPassError;
    public Animator animatorOutOK;
    public Animator animatorOutError;

    public void ShowPassOK()
    {
        if (animatorPassOK)
        {
            animatorPassOK.transform.SetSiblingIndex(animatorPassOK.transform.parent.childCount - 1);
            animatorPassOK.SetTrigger("IsShow");

        }
    }
    public void ShowPassError()
    {
        if (animatorPassError)
        {
            animatorPassError.transform.SetSiblingIndex(animatorPassError.transform.parent.childCount - 1);
            animatorPassError.SetTrigger("IsShow");

        }
    }
    public void ShowOutOK()
    {
        if (animatorOutOK)
        {
            animatorOutOK.transform.SetSiblingIndex(animatorOutOK.transform.parent.childCount - 1);
            animatorOutOK.SetTrigger("IsShow");

        }
    }
    public void ShowOutError()
    {
        if (animatorOutError)
        {
            animatorOutError.transform.SetSiblingIndex(animatorOutError.transform.parent.childCount - 1);
            animatorOutError.SetTrigger("IsShow");

        }
    }
}
