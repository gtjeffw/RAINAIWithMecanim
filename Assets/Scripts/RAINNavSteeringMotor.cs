using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RAIN.Motion;
using RAIN.Serialization;


/// <summary>
/// Demo RAINMotor impl to use AINavSteeringController for nav and steering
/// Author: Jeff Wilson (jeff@imtc.gatech.edu)
/// Interactive Media Technology Center
/// Georgia Insitute of Technology
/// </summary>



[RAINSerializableClass]
public class RAINNavSteeringMotor : RAINMotor {

    private AINavSteeringController navController;
    private NavMeshAgent agent;

    public override void BodyInit()
    {
        base.BodyInit();


        navController = AI.Body.GetComponent<AINavSteeringController>();

        agent = AI.Body.GetComponent<NavMeshAgent>();
     
        if (navController == null || agent == null)
        {
            Debug.LogWarning("NavMeshAgent and/or AINavSteeringController not found!");
        }
                
    }


    public override void AIStart()
    {
        base.AIStart();


        if (navController != null)
        {
            navController.Init();

            //just in case there are any set
            navController.clearWaypoints();

            navController.waypointLoop = false;

            //TODO: there are probably some other settings in
            //AINavSteeringController that need to be default and
            //aren't currently checked here.
            //Currently, they should be set in the inspector before
            //runtime.
            //At runtime, there are no getters/setters for most settings
            //so changes via script don't necessarily get "baked" correctly.
        }

    }



    public override void UpdateMotionTransforms()
    {
        //Nothing to do because:
        //We aren't using RAIN AI navigation or steering
    }

    public override void ApplyMotionTransforms()
    {
        //Nothing to do because:
        //We aren't using RAIN AI navigation or steering
    }



    public override bool Move()
    {
       
        navController.setWayPoint(MoveTarget.Position);           
       
        return IsAt(MoveTarget);

    }
        
    //TODO do I need MoveTo() implemented also?

    public override bool Face()
    {
        //TODO

        return true;
    }

    public override void Stop()
    {
        navController.clearWaypoints();
    }

    //TODO do I need Reset() implemented also?

    public override bool IsAt(MoveLookTarget aTarget)
    {
        return IsAt(aTarget.Position);
    }

    public override bool IsAt(Vector3 aPosition)
    {

        //TODO: this logic should probably be a bit more robust
        //Maybe check if waypointsComplete() AND we aren't
        //too far away
     
        bool result = navController.waypointsComplete();

        return result;

    }

    public override bool IsFacing(MoveLookTarget aTarget)
    {
        //TODO

        return true;
    }

    public override bool IsFacing(Vector3 aPosition)
    {
        //TODO

        return true;
    }
}
