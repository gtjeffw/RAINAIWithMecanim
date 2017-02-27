using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class Wave : RAINAction
{
    protected Animator anim;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);

        //TODO: I could actually grab the RAINAnimator and create an interface for it instead of grabbing Unity Animator here
        anim = ai.Body.GetComponent<Animator>();

        if(anim == null)
            Debug.LogWarning("Animator not found!");


        anim.SetBool("Wave", true);

    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);

        //We don't actually stop, but animation ends pretty quick
    }
}