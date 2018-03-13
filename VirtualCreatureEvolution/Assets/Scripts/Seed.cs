

public class Seed{
    private const int MAX_CHILDEREN = 4;
    int partType;
    float dynamicfriction;
    float staticFriction;
    float bounciness;
    bool childA;
    bool childB;
    bool childC;
    bool childD;
    int totalChilderen;
    

    //Joint A
    
    int jointAFromPoint;
    int jointAToPoint;

    //Joint B
    
    int jointBFromPoint;
    int jointBToPoint;

    //Joint C
    
    int jointCFromPoint;
    int jointCToPoint;

    //Joint D
    
    int jointDFromPoint;
    int jointDToPoint;

    bool muscleA;
    bool muscleB;
    bool muscleC;
    bool muscleD;
    int totalMuscles;

    //Muscle A
    int muscleAFromPoint;
    int muscleAToPoint;
    float muscleAForce;
    float muscleATiming;

    //Muscle B
    int muscleBFromPoint;
    int muscleBToPoint;
    float muscleBForce;
    float muscleBTiming;

    //Muscle C
    int muscleCFromPoint;
    int muscleCToPoint;
    float muscleCForce;
    float muscleCTiming;

    //Muscle D
    int muscleDFromPoint;
    int muscleDToPoint;
    float muscleDForce;
    float muscleDTiming;

    public static int MAX_CHILDEREN1
    {
        get
        {
            return MAX_CHILDEREN;
        }
    }

    public int PartType
    {
        get
        {
            return partType;
        }

        set
        {
            partType = value;
        }
    }

    public float Dynamicfriction
    {
        get
        {
            return dynamicfriction;
        }

        set
        {
            dynamicfriction = value;
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

    public bool ChildA
    {
        get
        {
            return childA;
        }

        set
        {
            childA = value;
        }
    }

    public bool ChildB
    {
        get
        {
            return childB;
        }

        set
        {
            childB = value;
        }
    }

    public bool ChildC
    {
        get
        {
            return childC;
        }

        set
        {
            childC = value;
        }
    }

    public bool ChildD
    {
        get
        {
            return childD;
        }

        set
        {
            childD = value;
        }
    }

    public int TotalChilderen
    {
        get
        {
            return totalChilderen;
        }

        set
        {
            totalChilderen = value;
        }
    }

    

    public int JointAFromPoint
    {
        get
        {
            return jointAFromPoint;
        }

        set
        {
            jointAFromPoint = value;
        }
    }

    public int JointAToPoint
    {
        get
        {
            return jointAToPoint;
        }

        set
        {
            jointAToPoint = value;
        }
    }

   

    public int JointBFromPoint
    {
        get
        {
            return jointBFromPoint;
        }

        set
        {
            jointBFromPoint = value;
        }
    }

    public int JointBToPoint
    {
        get
        {
            return jointBToPoint;
        }

        set
        {
            jointBToPoint = value;
        }
    }

    

    

    public int JointCFromPoint
    {
        get
        {
            return jointCFromPoint;
        }

        set
        {
            jointCFromPoint = value;
        }
    }

    public int JointCToPoint
    {
        get
        {
            return jointCToPoint;
        }

        set
        {
            jointCToPoint = value;
        }
    }

    

    

    public int JointDFromPoint
    {
        get
        {
            return jointDFromPoint;
        }

        set
        {
            jointDFromPoint = value;
        }
    }

    public int JointDToPoint
    {
        get
        {
            return jointDToPoint;
        }

        set
        {
            jointDToPoint = value;
        }
    }

    public bool MuscleA
    {
        get
        {
            return muscleA;
        }

        set
        {
            muscleA = value;
        }
    }

    public bool MuscleB
    {
        get
        {
            return muscleB;
        }

        set
        {
            muscleB = value;
        }
    }

    public bool MuscleC
    {
        get
        {
            return muscleC;
        }

        set
        {
            muscleC = value;
        }
    }

    public bool MuscleD
    {
        get
        {
            return muscleD;
        }

        set
        {
            muscleD = value;
        }
    }

    public int TotalMuscles
    {
        get
        {
            return totalMuscles;
        }

        set
        {
            totalMuscles = value;
        }
    }

    

    

    public int MuscleAFromPoint
    {
        get
        {
            return muscleAFromPoint;
        }

        set
        {
            muscleAFromPoint = value;
        }
    }

    public int MuscleAToPoint
    {
        get
        {
            return muscleAToPoint;
        }

        set
        {
            muscleAToPoint = value;
        }
    }

    

    

    public int MuscleBFromPoint
    {
        get
        {
            return muscleBFromPoint;
        }

        set
        {
            muscleBFromPoint = value;
        }
    }

    public int MuscleBToPoint
    {
        get
        {
            return muscleBToPoint;
        }

        set
        {
            muscleBToPoint = value;
        }
    }

    

    

    public int MuscleCFromPoint
    {
        get
        {
            return muscleCFromPoint;
        }

        set
        {
            muscleCFromPoint = value;
        }
    }

    public int MuscleCToPoint
    {
        get
        {
            return muscleCToPoint;
        }

        set
        {
            muscleCToPoint = value;
        }
    }

   

    

    public int MuscleDFromPoint
    {
        get
        {
            return muscleDFromPoint;
        }

        set
        {
            muscleDFromPoint = value;
        }
    }

    public int MuscleDToPoint
    {
        get
        {
            return muscleDToPoint;
        }

        set
        {
            muscleDToPoint = value;
        }
    }

    public float MuscleAForce
    {
        get
        {
            return muscleAForce;
        }

        set
        {
            muscleAForce = value;
        }
    }

    public float MuscleATiming
    {
        get
        {
            return muscleATiming;
        }

        set
        {
            muscleATiming = value;
        }
    }

    public float MuscleBForce
    {
        get
        {
            return muscleBForce;
        }

        set
        {
            muscleBForce = value;
        }
    }

    public float MuscleBTiming
    {
        get
        {
            return muscleBTiming;
        }

        set
        {
            muscleBTiming = value;
        }
    }

    public float MuscleCForce
    {
        get
        {
            return muscleCForce;
        }

        set
        {
            muscleCForce = value;
        }
    }

    public float MuscleCTiming
    {
        get
        {
            return muscleCTiming;
        }

        set
        {
            muscleCTiming = value;
        }
    }

    public float MuscleDForce
    {
        get
        {
            return muscleDForce;
        }

        set
        {
            muscleDForce = value;
        }
    }

    public float MuscleDTiming
    {
        get
        {
            return muscleDTiming;
        }

        set
        {
            muscleDTiming = value;
        }
    }
}
