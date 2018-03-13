using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assembler{
    private Turtle turt;
    private List<GameObject> CreatureObjectList = new List<GameObject>();

	public void StartCreatureBuild(Creature creature)
    {
        turt = new Turtle();
        GameObject parentObject = AddToScene(creature);
        SetUpPMaterial(creature, parentObject); //Set up body part friction + bounce
        CreatureObjectList.Add(parentObject);//Adds first gameobject to Creature object list
        BuildCreatureMain(creature, parentObject);
    }

    private void BuildCreatureMain(Creature creature, GameObject parentObject)
    {   
        Creature[] childArray = creature.ChildArray;
        GameObject[] newParentArray = new GameObject[childArray.Length]; //Array to hold refrence to each 3D GameObject

        if (childArray.Length > 0)
        {
            for (int i = 0; i < childArray.Length; i++)
            {
                GameObject childPart = ConnectToParent(creature, childArray[i], parentObject);
                //Set up body part friction + bounce, with correct collider type
                SetUpPMaterial(childArray[i], childPart);
                newParentArray[i] = childPart;
                CreatureObjectList.Add(childPart);
                ConnectMuscles(creature, childArray[i], parentObject, childPart);
                
                
            }
        }   
        
        //Recurse for each child if it has childeren
        for (int j=0; j<childArray.Length; j++)
        {
            
            BuildCreatureMain(childArray[j], newParentArray[j]);
            
        }
    }

   

    private GameObject ConnectToParent(Creature parent, Creature child, GameObject parentObject)
    {
        int[,] connections = parent.JointArray;
        int parentPoint=-1, childPoint=-1;
        
        //Gets connection details
        for (int i = 0; i < 6; i++) //Width of 2D joint array connections = 6
        {
            
            if (child.ID == connections[i, 0])
            {
                parentPoint = i;
                childPoint = connections[i, 1];

            }
        }
        
        //Get parents connetion point transform 
        Transform parentPointPos = GetPointPos(parentObject, parentPoint);
        //Get vector3 direction from parent connection point to parent center 
        Vector3 directionFromParent = GetDirection(parentPointPos, parentObject.transform);
        //Move turtle to parent connection point
        turt.MoveTurtleTo(parentPointPos.position);
        //Rotate turtle to face direction from connection point to center of parent 
        turt.FaceTurtleTo(directionFromParent);

        //Add child object to scene
        GameObject childObject = AddToScene(child);
        //Get distance from child object to connection point
        Transform childPointPos = GetPointPos(childObject, childPoint);
        float childSpacing = GetDistance(childObject.transform, childPointPos);
        //Move turtle into possition
        turt.MoveTurtle(directionFromParent.x, directionFromParent.y, directionFromParent.z, childSpacing);
        
        //Move child object to new turtle possition
        childObject.transform.position = turt.GetTurtlePosition();
        //Make sure child object is rotated correctly for jointing
        CorrectRotation(childObject, childPoint, parentPointPos);

        
        
        CharacterJoint charJoint = childObject.AddComponent<CharacterJoint>();
        Vector3 localPoint = childPointPos.InverseTransformPoint(childPointPos.position);
        charJoint.anchor = localPoint;


        charJoint.connectedBody = parentObject.GetComponent<Rigidbody>();
        charJoint.enableCollision = true;
        SoftJointLimitSpring springA = charJoint.twistLimitSpring;
        springA.damper = 1f;
        charJoint.twistLimitSpring = springA;
        SoftJointLimitSpring springB = charJoint.swingLimitSpring;
        springB.damper = 1f;
        charJoint.swingLimitSpring = springB;
        charJoint.autoConfigureConnectedAnchor = true;
        return childObject;
    }

    public void SetUpPMaterial(Creature creature, GameObject childObject)
    {
        String partType = creature.ThisObject;
        if (ColliderSwitch(partType) == 1)
        {
            SetupPhysicMaterial(childObject.GetComponent<CapsuleCollider>().material, creature);
        }
        else if (ColliderSwitch(partType) == 2)
        {
            SetupPhysicMaterial(childObject.GetComponent<SphereCollider>().material, creature);
        }
    }

    private void SetupPhysicMaterial(PhysicMaterial material, Creature creature)
    {
        material.dynamicFriction = creature.DynamicFriction;
        material.staticFriction = creature.StaticFriction;
        material.bounciness = creature.Bounciness;   
    }

    public int ColliderSwitch(String partType)
    {
        switch (partType)
        {
            case "LargeCapsule":
                return 1;
            case "MediumCapsule":
                return 1;
            case "SmallCapsule":
                return 1;
            case "LargeSphere":
                return 2;
            case "MediumSphere":
                return 2;
            case "SmallSphere":
                return 2;
            default:
                Debug.Log("Collider Switch failed");
                return 0;
        }
    }

    public void CorrectRotation(GameObject childObject, int childPoint, Transform parentPointPos)
    {
        float tempDis;
        float minDistance = GetDistance(GetPointPos(childObject, childPoint), parentPointPos);
        int bestSide = -1;
        
        for(int i = 0; i < 6; i++)
        {
            Flipper(i, childObject);
            tempDis = GetDistance(GetPointPos(childObject, childPoint), parentPointPos);
            if (tempDis <= minDistance)
            {
                minDistance = tempDis;
                bestSide = i;
            }
        }
        //Flips to correct rotation after checking each
        Flipper(bestSide, childObject);
    }

    private void Flipper(int side, GameObject childObject)
    {
        switch (side)
        {
            case 0:
                turt.FacePositiveX();
                childObject.transform.rotation = turt.GetTurtleRotation();
                break;
            case 1:
                turt.FaceNegativeX();
                childObject.transform.rotation = turt.GetTurtleRotation();
                break;
            case 2:
                turt.FacePositiveY();
                childObject.transform.rotation = turt.GetTurtleRotation();
                break;
            case 3:
                turt.FaceNegativeY();
                childObject.transform.rotation = turt.GetTurtleRotation();
                break;
            case 4:
                turt.FacePositiveZ();
                childObject.transform.rotation = turt.GetTurtleRotation();
                break;
            case 5:
                turt.FaceNegativeZ();
                childObject.transform.rotation = turt.GetTurtleRotation();
                break;
        }
    }
    
    

    private void ConnectMuscles(Creature parent, Creature child, GameObject parentObj, GameObject childObj)
    {
        float[,] muscleArr = parent.MuscleArray;
        
        int parentConnection = -1, childConnection = -1, childID=-1;
        float pullForce=0, timing=0;
        for(int i=0; i< 6; i++) //6 is max branches
        {
            if(muscleArr[i,0] != -1)
            {
                parentConnection = i;
                childID = (int)muscleArr[i, 0];
                childConnection = (int)muscleArr[i, 1];
                pullForce = muscleArr[i, 2];
                timing = muscleArr[i, 3];
            }

            if (childID == child.ID)
            {
                GameObject parentFixing = parentObj.transform.GetChild(parentConnection).gameObject;
                GameObject childFixing = childObj.transform.GetChild(childConnection).gameObject;
                if(childFixing == null || parentFixing == null)
                {
                    Debug.Log("Muscle Error");
                }
                else
                {
                    
                    Muscle muscle = parentObj.AddComponent<Muscle>();
                    muscle.ConnectionA0 = parentFixing;
                    muscle.ConnectionA1 = childFixing;
                    muscle.PullForce = pullForce;
                    muscle.Timing = timing;
                }
                
                
            }
        }
        
        
    }

    /*
    private int MuscleCount(Creature creature)
    {
        int muscleCounter = 0;
        float[,] muscleArr = creature.MuscleArray;
        for (int i = 0; i < muscleArr.Length; i++)
        {
            if (muscleArr[i, 0] != -1)
            {
                muscleCounter++;
            }
        }
        return muscleCounter;
    }
    */

    private GameObject AddToScene(Creature creature)
    {
        string component = creature.ThisObject;
        GameObject creatureComponent = Resources.Load(component) as GameObject;
        return GameObject.Instantiate(creatureComponent, turt.GetTurtlePosition(), turt.GetTurtleRotation());
    }

    private Transform GetPointPos(GameObject creatureObject, int point)
    {
        
        
        Transform tran = null;
        try
        {
            tran = creatureObject.transform.GetChild(point);
        }
        catch(Exception e)
        {
            Debug.Log("Point: " +point);
            Debug.Log(e.StackTrace);

        }
        
        return tran;
    }

    public Vector3 GetDirection(Transform start, Transform end)
    {
        Vector3 direction = new Vector3(0,0,0);
        try
        {
            Vector3 heading = start.position - end.position;
            float distance = heading.magnitude;
            direction = heading / distance;
            return direction;
        }
        catch(Exception e)
        {
            Debug.Log(e.StackTrace);
        }
        return direction;
    }

    public float GetDistance(Transform start, Transform end)
    {
        Vector3 heading = start.position - end.position;
        return heading.magnitude;
    }
    public void GravityOff()
    {
        int listLen = CreatureObjectList.Count;
        for(int i = 0; i < listLen; i++)
        {
            CreatureObjectList[i].GetComponent<Rigidbody>().useGravity = false;
        }

    }
    public void GravityOn()
    {
        int listLen = CreatureObjectList.Count;
        for (int i = 0; i < listLen; i++)
        {
            CreatureObjectList[i].GetComponent<Rigidbody>().useGravity = true;
        }

    }
    public void CollidersOff()
    {
        int listLen = CreatureObjectList.Count;
        for (int i = 0; i < listLen; i++)
        {
            CreatureObjectList[i].GetComponent<Collider>().enabled = false;
        }

    }
    public void CollidersOn()
    {
        int listLen = CreatureObjectList.Count;
        for (int i = 0; i < listLen; i++)
        {
            CreatureObjectList[i].GetComponent<Collider>().enabled = true;
        }

    }
    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].SendMessage("AddDamage");
            i++;
        }
    }
    

}
