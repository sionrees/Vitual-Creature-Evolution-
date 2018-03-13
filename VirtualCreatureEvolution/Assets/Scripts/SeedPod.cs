
using System;
using UnityEngine;

public class SeedPod{
    private const int MAX_SEEDS = 21;
    private const int MAX_CHILD = 4;
    private const float MIN_FRICTION = 0.0f;
    private const float MAX_FRICTION = 1.0f;
    private const int JOINT_MIN = 0;
    private const int JOINT_MAX = 5;
    //Muscle force ranges
    private const int MIN_FORCE = 0;
    private const int MAX_FORCE = 15000;
    //Muscle firing timing
    private const float MIN_TIMING = 0.0f;
    private const float MAX_TIMING = 5.0f;
    Seed[] pod = new Seed[MAX_SEEDS];
    bool[] existance = new bool[MAX_SEEDS];

    public SeedPod()
    {
        existance[0] = true;

        for(int i=0;i<MAX_SEEDS; i++)
        {
            if(existance[i] == true)
            {
                Seed seed = new Seed();
                seed.PartType = RandomConnection();
                seed.Dynamicfriction = UnityEngine.Random.Range(MIN_FRICTION, MAX_FRICTION);
                seed.StaticFriction = UnityEngine.Random.Range(MIN_FRICTION, MAX_FRICTION);
                seed.Bounciness = UnityEngine.Random.Range(MIN_FRICTION, MAX_FRICTION); //Ranges for friction work for bounce also

                seed.ChildA = RandBool();
                seed.ChildB = RandBool();
                seed.ChildC = RandBool();
                seed.ChildD = RandBool();
                seed.TotalChilderen = ChildCount(seed);

                if (seed.ChildA)
                {
                    int tempAFrom = RandomConnection();
                    int tempATo = RandomConnection(); 
                    seed.JointAFromPoint = tempAFrom;
                    seed.JointAToPoint = tempATo;
                }
                if (seed.ChildB)
                {
                    seed.JointBFromPoint = RandomConnection();
                    seed.JointBToPoint = RandomConnection();
                }
                if (seed.ChildC)
                {
                    seed.JointCFromPoint = RandomConnection();
                    seed.JointCToPoint = RandomConnection();
                }
                if (seed.ChildD)
                {
                    seed.JointCFromPoint = RandomConnection();
                    seed.JointCToPoint = RandomConnection();
                }

                if (seed.ChildA)
                {
                    seed.MuscleA = RandBool();
                }
                if (seed.ChildB)
                { 
                    seed.MuscleB = RandBool();
                }
                if (seed.ChildC)
                {
                    seed.MuscleC = RandBool();
                }
                if (seed.ChildD)
                {
                    seed.MuscleD = RandBool();
                }
                seed.TotalMuscles = MuscleCount(seed);

                if (seed.MuscleA)
                {
                    int tempAFrom = RandomConnection();
                    int tempATo = RandomConnection();
                    seed.JointAFromPoint = tempAFrom;
                    seed.JointAToPoint = tempATo;
                    seed.MuscleAForce = RandomForce();
                    seed.MuscleATiming = RandomTiming();
                }
                if (seed.MuscleB)
                {
                    seed.JointBFromPoint = RandomConnection();
                    seed.JointBToPoint = RandomConnection();
                    seed.MuscleBForce = RandomForce();
                    seed.MuscleBTiming = RandomTiming();
                }
                if (seed.MuscleC)
                {
                    seed.JointCFromPoint = RandomConnection(); 
                    seed.JointCToPoint = RandomConnection();
                    seed.MuscleCForce = RandomForce();
                    seed.MuscleCTiming = RandomTiming();
                }
                if (seed.MuscleD)
                {
                    seed.JointCFromPoint = RandomConnection();
                    seed.JointCToPoint = RandomConnection();
                    seed.MuscleDForce = RandomForce();
                    seed.MuscleDTiming = RandomTiming();
                }

                if (i == 0)
                {
                    existance[1] = seed.ChildA;
                    existance[2] = seed.ChildB;
                    existance[3] = seed.ChildC;
                    existance[4] = seed.ChildD;
                }else if(i == 1)
                {
                    existance[5] = seed.ChildA;
                    existance[6] = seed.ChildB;
                    existance[7] = seed.ChildC;
                    existance[8] = seed.ChildD;
                }else if(i == 2)
                {
                    existance[9] = seed.ChildA;
                    existance[10] = seed.ChildB;
                    existance[11] = seed.ChildC;
                    existance[12] = seed.ChildD;
                }else if(i == 3)
                {
                    existance[13] = seed.ChildA;
                    existance[14] = seed.ChildB;
                    existance[15] = seed.ChildC;
                    existance[16] = seed.ChildD;
                }else if(i == 4)
                {
                    existance[17] = seed.ChildA;
                    existance[18] = seed.ChildB;
                    existance[19] = seed.ChildC;
                    existance[20] = seed.ChildD;
                }

                pod[i] = seed;

            }
            else
            {
                pod[i] = null;
            }
            

        }
    }

    private float RandomTiming()
    {
        return UnityEngine.Random.Range(MIN_TIMING, MAX_TIMING);
    }

    private int RandomConnection()
    {
        return UnityEngine.Random.Range(JOINT_MIN, JOINT_MAX);
    }

    private float RandomForce()
    {
        return UnityEngine.Random.Range(MIN_FORCE, MAX_FORCE);
    }

    public Seed[] Pod
    {
        get
        {
            return pod;
        }

        set
        {
            pod = value;
        }
    }


    public bool RandBool()
    {
        return (UnityEngine.Random.value > 0.5f);
    }

    public int ChildCount(Seed seed)
    {
        int count = 0;
        if (seed.ChildA) count++;
        if (seed.ChildB) count++;
        if (seed.ChildC) count++;
        if (seed.ChildD) count++;

        return count;
    }

    public int MuscleCount(Seed seed)
    {
        int count = 0;
        if (seed.MuscleA) count++;
        if (seed.MuscleB) count++;
        if (seed.MuscleC) count++;
        if (seed.MuscleD) count++;

        return count;
    }
}
