using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Creature {
    [SerializeField] Creature[] childArray;
    [SerializeField] string thisObject;
    [SerializeField] int iD;
    [SerializeField] int[,] jointArray;
    [SerializeField] float[,] muscleArray;
    [SerializeField] float dynamicFriction;
    [SerializeField] float staticFriction;
    [SerializeField] float bounciness;
    //[SerializeField] int[] usedConnections = new int[6]; //6 is the total number of connections on a component!
    private const int MAX_BRANCHES = 4;
    private const int MIN_BRANCHES = 0;

    

    //Random new creature constructor
    
    public Creature(int partCount)
    {
        int pc = partCount; 
        pc -=1; //This component is taken away from the total number of components allowed
        ComponentPicker compPick = new ComponentPicker(); //Random Gen -> SEED?
        thisObject = compPick.SelectComponent();//Random Gen -> SEED?
        DynamicFriction = compPick.GenDynamicFriction(); //Random Gen -> SEED?
        StaticFriction = compPick.GenStaticFriction();//Random Gen -> SEED?
        Bounciness = compPick.GenBounciness();//Random Gen -> SEED?
        ID = compPick.GetNewID();
        Debug.Log("Title: " + ThisObject + "; ID: " + ID);


        if (pc >= 2) //Random Gen -> SEED?
        {
            int tempMaxBranch = 0;
            if(pc > MAX_BRANCHES)
            {
                tempMaxBranch = MAX_BRANCHES;
            }
            else
            {
                tempMaxBranch = pc;
            }
            int lowerBoundBranches = UnityEngine.Random.Range(0, 2);  //Random Gen -> SEED?
            int branches = UnityEngine.Random.Range(lowerBoundBranches, tempMaxBranch); //Random Gen -> SEED?
            childArray = new Creature[branches];
            //pc -= branches;
            for (int i = 0; i < branches; i++)
            {
                int pcPassed = UnityEngine.Random.Range(MIN_BRANCHES, pc); //Random Gen -> SEED?
                pc -= pcPassed;
                Creature c = new Creature(pcPassed); 
                childArray[i] = c;
             }
            
        }
        else if (pc == 1)
        {//Deals with last child object

            childArray = new Creature[1];
            Creature c = new Creature(pc);
            childArray[0] = c;
        }
        else
        {
            childArray = new Creature[0];
        }
    }

    /*
    public Creature(Seed seed, int id, bool noChild)
    {
        if (seed != null)
        {

            ComponentPicker compPick = new ComponentPicker();
            thisObject = compPick.SelectComponent(seed.PartType);
            DynamicFriction = seed.Dynamicfriction;
            StaticFriction = seed.StaticFriction;
            Bounciness = seed.Bounciness;
            ID = id;
            if (noChild)
            {
                childArray = new Creature[0];
            }
            else
            {
                childArray = new Creature[4];
            }
            
        }
    }

    public static Creature GenCreatureFromSeed(SeedPod seedPod)
    {
        JointMuscleSetup jointMuscles = new JointMuscleSetup();
        Seed seed = seedPod.Pod[0];
        int creatureMainChildCount = seedPod.ChildCount(seed);
        Creature creature = new Creature(seed, 0, false);
        jointMuscles.SeedJointMuscleSetUp(creature, seed, 0);
       
        for (int i=0; i< 5; i++)
        {
            if (i == 0)
            {
                if (seed.ChildA)
                {
                    
                    creature.ChildArray[0] = new Creature(seedPod.Pod[1], 1, false);
                }
                if (seed.ChildB)
                {
                    
                    creature.ChildArray[1] = new Creature(seedPod.Pod[2], 2, false);
                }
                if (seed.ChildC)
                {
                    
                    creature.ChildArray[2] = new Creature(seedPod.Pod[3], 3, false);
                }
                if (seed.ChildD)
                {
                    
                    creature.ChildArray[3] = new Creature(seedPod.Pod[4], 4, false);
                }
                
            }
            else if(i == 1 && seed.ChildA)
            {
                Creature newParent = creature.ChildArray[i-1];
                Seed newSeed = seedPod.Pod[i];
                jointMuscles.SeedJointMuscleSetUp(newParent, newSeed, i);

                if (newSeed.ChildA)
                {

                    newParent.ChildArray[0] = new Creature(seedPod.Pod[5], 1, true);
                }
                if (newSeed.ChildB)
                {

                    newParent.ChildArray[1] = new Creature(seedPod.Pod[6], 2, true);
                }
                if (newSeed.ChildC)
                {

                    newParent.ChildArray[2] = new Creature(seedPod.Pod[7], 3, true);
                }
                if (newSeed.ChildD)
                {

                    newParent.ChildArray[3] = new Creature(seedPod.Pod[8], 4, true);
                }


            }
            else if(i == 2 && seed.ChildB)
            {
                Creature newParent = creature.ChildArray[i-1];
                Seed newSeed = seedPod.Pod[i];
                jointMuscles.SeedJointMuscleSetUp(newParent, newSeed, i);

                if (newSeed.ChildA)
                {

                    newParent.ChildArray[0] = new Creature(seedPod.Pod[9], 9, true);
                }
                if (newSeed.ChildB)
                {

                    newParent.ChildArray[1] = new Creature(seedPod.Pod[10], 10, true);
                }
                if (newSeed.ChildC)
                {

                    newParent.ChildArray[2] = new Creature(seedPod.Pod[11], 11, true);
                }
                if (newSeed.ChildD)
                {

                    newParent.ChildArray[3] = new Creature(seedPod.Pod[12], 12, true);
                }

            }
            else if(i ==3 && seed.ChildC)
            {
                Creature newParent = creature.ChildArray[i-1];
                Seed newSeed = seedPod.Pod[i];
                jointMuscles.SeedJointMuscleSetUp(newParent, newSeed, i);

                if (newSeed.ChildA)
                {

                    newParent.ChildArray[0] = new Creature(seedPod.Pod[13], 13, true);
                }
                if (newSeed.ChildB)
                {

                    newParent.ChildArray[1] = new Creature(seedPod.Pod[14], 14, true);
                }
                if (newSeed.ChildC)
                {

                    newParent.ChildArray[2] = new Creature(seedPod.Pod[15], 15, true);
                }
                if (newSeed.ChildD)
                {

                    newParent.ChildArray[3] = new Creature(seedPod.Pod[16], 16, true);
                }

            }
            else if (i == 4 && seed.ChildD)
            {
                Creature newParent = creature.ChildArray[i-1];
                Seed newSeed = seedPod.Pod[i];
                jointMuscles.SeedJointMuscleSetUp(newParent, newSeed, i);

                if (newSeed.ChildA)
                {

                    newParent.ChildArray[0] = new Creature(seedPod.Pod[17], 17, true);
                }
                if (newSeed.ChildB)
                {

                    newParent.ChildArray[1] = new Creature(seedPod.Pod[18], 18, true);
                }
                if (newSeed.ChildC)
                {

                    newParent.ChildArray[2] = new Creature(seedPod.Pod[19], 19, true);
                }
                if (newSeed.ChildD)
                {

                    newParent.ChildArray[3] = new Creature(seedPod.Pod[20], 20, true);
                }

            }
            
        }
        return creature;
    }
    */

    public int[] GetChildIDs()
    {
        int[] idArr = new int[childArray.Length];
        for (int i = 0; i < childArray.Length; i++)
        {
            idArr[i] = childArray[i].ID;
        }

        return idArr;
    }
    

    public float DynamicFriction
    {
        get
        {
            return dynamicFriction;
        }

        set
        {
            dynamicFriction = value;
        }
    }

    public float StaticFriction
    {
        get
        {
            return staticFriction;
        }

        set
        {
            staticFriction = value;
        }
    }

    public float Bounciness
    {
        get
        {
            return bounciness;
        }

        set
        {
            bounciness = value;
        }
    }

    public Creature[] ChildArray
    {
        get
        {
            return childArray;
        }

        set
        {
            childArray = value;
        }
    }

    public string ThisObject
    {
        get
        {
            return thisObject;
        }

        set
        {
            thisObject = value;
        }
    }

    public int ID
    {
        get
        {
            return iD;
        }

        set
        {
            iD = value;
        }
    }

    public int[,] JointArray
    {
        get
        {
            return jointArray;
        }

        set
        {
            jointArray = value;
        }
    }

    public float[,] MuscleArray
    {
        get
        {
            return muscleArray;
        }

        set
        {
            muscleArray = value;
        }
    }
}
