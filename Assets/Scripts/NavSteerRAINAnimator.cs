using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RAIN.Animation;
using RAIN.Serialization;


[RAINSerializableClass]
public class NavSteerRAINAnimator : RAINAnimator {

    private Animator anim; 

    private AnimatorStateInfo layer2CurrentState;

    protected static int waveState = Animator.StringToHash("Layer2.Wave");


    public override void AIInit() {

        anim = AI.Body.GetComponent<Animator>();

        if(anim == null)
            Debug.LogWarning("Animator not found!");
    }

    public override void AIStart() {

        if(anim.layerCount ==2)
            anim.SetLayerWeight(1, 1);

    }

    public override void UpdateAnimation() {

        if(anim.layerCount ==2)     
            layer2CurrentState = anim.GetCurrentAnimatorStateInfo(1);   // set our layer2CurrentState variable to the current state of the second Layer (1) of animation

        // if we enter the waving state, reset the bool to let us wave again in future
        if(layer2CurrentState.fullPathHash == waveState)
        {
            anim.SetBool("Wave", false);
        }

    }

    public override void UpdateIK(int n) {

    }
}
