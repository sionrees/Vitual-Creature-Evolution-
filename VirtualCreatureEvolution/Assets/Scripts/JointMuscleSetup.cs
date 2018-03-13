using System.Collections;
using UnityEngine;
using System;


public class JointMuscleSetup{
    /* Index of array represents parent object connection point.
     * Row 0 holds child ID, Row 1 holds child object connection point.
    */
    private int[,] jointArray2D;
    private float[,] muscleArr;
    
    private const int MIN_BRANCHES = 0;
    private const int MAX_BRANCHES = 6;
    private const int JOINT_FIELDS = 2;

    private const int MIN_MUSCLES = 1;
    private const int MAX_MUSCLES = 4;
    private const int MUSCLE_FIELDS = 4;

    //Muscle force ranges
    private const int MIN_FORCE = 0;
    private const int MAX_FORCE = 15000;
    //Muscle firing timing
    private const float MIN_TIMING = 0.0f;
    private const float MAX_TIMING = 5.0f;

    /*
    public void SeedJointMuscleSetUp(Creature creature, Seed seed, int parentID)
    {
        JointArrayFromSeed(creature, seed, parentID);
        MuscleArrayFromSeed(creature, seed, parentID);
    }
    */

    /*
    public void JointArrayFromSeed(Creature creature, Seed seed, int parentID)
    {
        int[] childIDs = GetChildIDs(parentID);
        jointArray2D = GenNegativeJointArr(MAX_BRANCHES, JOINT_FIELDS);
        if (seed.ChildA)
        {
            jointArray2D[seed.JointAFromPoint, 0] = childIDs[0];
            jointArray2D[seed.JointAFromPoint, 1] = seed.JointAToPoint;
        }
        if (seed.ChildB)
        {
            jointArray2D[seed.JointBFromPoint, 0] = childIDs[1];
            jointArray2D[seed.JointBFromPoint, 1] = seed.JointBToPoint;
        }
        if (seed.ChildB)
        {
            jointArray2D[seed.JointCFromPoint, 0] = childIDs[2];
            jointArray2D[seed.JointCFromPoint, 1] = seed.JointCToPoint;
        }
        if (seed.ChildB)
        {
            jointArray2D[seed.JointDFromPoint, 0] = childIDs[3];
            jointArray2D[seed.JointDFromPoint, 1] = seed.JointDToPoint;
        }
        creature.JointArray = jointArray2D;
    }
    */

    /*
    public void MuscleArrayFromSeed(Creature creature, Seed seed, int parentID)
    {
        int[] childIDs = GetChildIDs(parentID);
        muscleArr = GenNegativeMuscleArr(MAX_BRANCHES, MUSCLE_FIELDS);
        if (seed.MuscleA)
        {
            muscleArr[seed.MuscleAFromPoint, 0] = childIDs[0];
            muscleArr[seed.MuscleAFromPoint, 1] = seed.MuscleAToPoint;
            muscleArr[seed.MuscleAFromPoint, 2] = seed.MuscleAForce;
            muscleArr[seed.MuscleAFromPoint, 3] = seed.MuscleATiming;
        }

        if (seed.MuscleB)
        {
            muscleArr[seed.MuscleBFromPoint, 0] = childIDs[1];
            muscleArr[seed.MuscleBFromPoint, 1] = seed.MuscleBFromPoint;
            muscleArr[seed.MuscleBFromPoint, 1] = seed.MuscleBToPoint;
            muscleArr[seed.MuscleBFromPoint, 2] = seed.MuscleBForce;
        }
        if (seed.MuscleC)
        {
            muscleArr[seed.MuscleCFromPoint, 0] = childIDs[2];
            muscleArr[seed.MuscleCFromPoint, 1] = seed.MuscleCToPoint;
            muscleArr[seed.MuscleCFromPoint, 2] = seed.MuscleCForce;
            muscleArr[seed.MuscleCFromPoint, 3] = seed.MuscleCTiming;
        }

        if (seed.MuscleD)
        {
            muscleArr[seed.MuscleDFromPoint, 0] = childIDs[3];
            muscleArr[seed.MuscleDFromPoint, 1] = seed.MuscleDToPoint;
            muscleArr[seed.MuscleDFromPoint, 2] = seed.MuscleDForce;
            muscleArr[seed.MuscleDFromPoint, 3] = seed.MuscleDTiming;

        }
        creature.MuscleArray = muscleArr;
    }
    */

    private int[] GetChildIDs(int parentID)
    {
        switch (parentID)
        {
            case 0:
                return new int[] { 1, 2, 3, 4};
            case 1:
                return new int[] { 5, 6, 7, 8 };
            case 2:
                return new int[] { 9, 10, 11, 12 };
            case 3:
                return new int[] { 13, 14, 15, 16 };
            case 4:
                return new int[] { 17, 18, 19, 20 };
            default:
                Debug.Log("ChildID Switch failed");
                return new int[0];
        }
    }

    //Generate array defineing muscle connection from parent to child objects
    private void GenMuscleArray(Creature creature)
    {
        int branches = creature.ChildArray.Length;
        int[] idArr = creature.GetChildIDs();
        if(branches == 0)
        {
            muscleArr = new float[0, 0];

        }else
        {
            int[,] usedConnections = creature.JointArray; //To make sure muscles are not set to jointed connection points on parent
            int muscleCount = UnityEngine.Random.Range(MIN_MUSCLES, MAX_MUSCLES);//Number of muscles to be for this creature object.
            muscleArr = GenNegativeMuscleArr(MAX_BRANCHES, MUSCLE_FIELDS);

            for(int i=0; i<muscleCount; i++)
            {
                bool inserted = false;
                while (!inserted)
                {
                    int randomPlacmentParent = UnityEngine.Random.Range(MIN_BRANCHES, MAX_BRANCHES - 1);
                    int randomPlacmentChild = UnityEngine.Random.Range(MIN_BRANCHES, MAX_BRANCHES - 1);
                    int ramdomChildID = UnityEngine.Random.Range(0, idArr.Length-1);
                    if (usedConnections[randomPlacmentParent,0] == -1)
                    {
                        //Main index represents connection point used by parent
                        muscleArr[randomPlacmentParent, 0] = idArr[ramdomChildID]; // ID of child object connected to
                        muscleArr[randomPlacmentParent, 1] = randomPlacmentChild; // Connection point on child object
                        muscleArr[randomPlacmentParent, 2] = UnityEngine.Random.Range(MIN_FORCE, MAX_FORCE); //Force exerted by the muscle
                        muscleArr[randomPlacmentParent, 3] = UnityEngine.Random.Range(MIN_TIMING, MAX_TIMING); //Timing for coroutine, to fire muscle contraction
						inserted = true;
                    }
                }
            }
            
        }
        creature.MuscleArray = muscleArr;
    }
    

    private void GenJointArray(Creature creature)
    {
        int branches = creature.ChildArray.Length;
        

        if (branches == 0) // Checking for end of graph objects
        {
            jointArray2D = new int[0, 0];
        }
        else
        {
            int[] idArr = creature.GetChildIDs();

            jointArray2D = GenNegativeJointArr(MAX_BRANCHES, JOINT_FIELDS);
            //int placment = 0;
            //For each child object
            for (int i = 0; i < branches; i++)
            {
                bool inserted = false;
                while (!inserted)
                {
                    int randomPlacmentParent = UnityEngine.Random.Range(MIN_BRANCHES, MAX_BRANCHES - 1);
                    int randomPlacmentChild = UnityEngine.Random.Range(MIN_BRANCHES, MAX_BRANCHES - 1);
                    int randomChildID = UnityEngine.Random.Range(0, idArr.Length-1);
                    //placment = randomPlacmentParent;
                    if (jointArray2D[randomPlacmentParent, 0] == -1)
                    {
                        jointArray2D[randomPlacmentParent, 0] = idArr[randomChildID];
                        jointArray2D[randomPlacmentParent, 1] = randomPlacmentChild;
                        inserted = true;
                        idArr = RemoveFromArray(idArr, randomChildID);
                    }
                }
            }
        }
        creature.JointArray = jointArray2D;
    }

    private void GenJointArray(Creature creature, int[,] parentJointArray)
    {
        int branches = creature.ChildArray.Length;
        bool[] usedCon = GetUsedConnections(creature, parentJointArray);

        if (branches == 0) // Checking for end of graph objects
        {
            jointArray2D = new int[0, 0];
        }
        else
        {
            int[] idArr = creature.GetChildIDs();

            jointArray2D = GenNegativeJointArr(MAX_BRANCHES, JOINT_FIELDS);
            //int placment = 0;
            //For each child object
            for (int i = 0; i < branches; i++)
            {
                bool inserted = false;
                while (!inserted)
                {
                    int randomPlacmentParent = UnityEngine.Random.Range(MIN_BRANCHES, MAX_BRANCHES - 1);
                    int randomPlacmentChild = UnityEngine.Random.Range(MIN_BRANCHES, MAX_BRANCHES - 1);
                    int randomChildID = UnityEngine.Random.Range(0, idArr.Length - 1);
                    //placment = randomPlacmentParent;
                    if (jointArray2D[randomPlacmentParent, 0] == -1 && !usedCon[randomPlacmentChild])
                    {
                        jointArray2D[randomPlacmentParent, 0] = idArr[randomChildID];
                        jointArray2D[randomPlacmentParent, 1] = randomPlacmentChild;
                        inserted = true;
                        idArr = RemoveFromArray(idArr, randomChildID);
                    }
                }
            }
        }
        creature.JointArray = jointArray2D;
    }

    private bool[] GetUsedConnections(Creature creature, int[,] parentJointArray)
    {
        int id = creature.ID;
        bool[] usedConnections = new bool[MAX_BRANCHES];
        for(int i=0; i< usedConnections.Length; i++)
        {
            if(parentJointArray[i,0] == id)
            {
                usedConnections[parentJointArray[i, 1]] = true;
            }
        }
        return usedConnections;
    }

    private int[] RemoveFromArray(int[] idArr, int oldIndex) 
    {
        int oldLength = idArr.Length;
        int[] newArr = new int[oldLength - 1];
        for(int i = 0; i < oldIndex; i++)
        {
            newArr[i] = idArr[i]; 
        }
        for (int i = oldIndex+1; i < oldLength; i++)
        {
            newArr[i-1] = idArr[i];

        }
        return newArr;
    }

    public void JointMuscleArraySetup(Creature creature)
    {
        if (creature != null)
        {
            GenJointArray(creature);
            GenMuscleArray(creature);
            JointMuscleArraySetupBFS(creature);
        }

    }

    private void JointMuscleArraySetupBFS(Creature creature)
    {
        
        
            foreach (Creature c0 in creature.ChildArray)
            {
                if (c0.ChildArray.Length > 0)
                {
                    int[,] parentJointArray = creature.JointArray; 
                    GenJointArray(c0, parentJointArray);
                    GenMuscleArray(c0);
                }
                
            }

            foreach (Creature c1 in creature.ChildArray)
            {
                JointMuscleArraySetupBFS(c1);
            }
        

    }

    public float[,] GenNegativeMuscleArr(int col, int row)
    {
        float[,] arr = new float[col, row];
        for(int i=0; i< col; i++)
        {
            for(int j=0; j<row; j++)
            {
                arr[i, j] = -1;
            }
        }
        return arr;
    }

    public int[,] GenNegativeJointArr(int col, int row)
    {
        int[,] arr = new int[col, row];
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                arr[i, j] = -1;
            }
        }
        return arr;
    }

}
