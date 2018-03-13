using UnityEngine;

public class ComponentPicker {
	private string[] prefabEVCComponents = { "LargeCapsule", "MediumCapsule",
		"SmallCapsule", "LargeSphere", "MediumSphere", "SmallSphere" };
    
    private const int idSeed = 0;
    private static int idGen = idSeed;

    private const float MIN_FRICTION = 0.0f;
    private const float MAX_FRICTION = 1.0f;


    public string SelectComponent()
    { 
        int randomNum = Random.Range(0, 5);
        return prefabEVCComponents[randomNum];
    }

    public string SelectComponent(int num)
    {
        
        return prefabEVCComponents[num];
    }

    public int GetNewID()
    {
        //Debug.Log("Before ++ "+idGen);
        return idGen++;
    }

    public float GenDynamicFriction()
    {
        return Random.Range(MIN_FRICTION, MAX_FRICTION);
    }

    public float GenStaticFriction()
    {
        return Random.Range(MIN_FRICTION, MAX_FRICTION);
    }

    public float GenBounciness()
    {
        //Ranges are same as friction
        return Random.Range(MIN_FRICTION, MAX_FRICTION);
    }
}
