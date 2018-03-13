using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureTest : MonoBehaviour {
    Assembler assembler;
    bool physixSwitch = false;
    void Awake()
    {
        Creature creature = new Creature(15);
        assembler = new Assembler();
        JointMuscleSetup jms = new JointMuscleSetup();
        jms.JointMuscleArraySetup(creature);
        assembler.StartCreatureBuild(creature);

        
    }
    private void Start()
    {
        //assembler.CollidersOff();
        //assembler.GravityOff();
    }
    private void FixedUpdate()
    {
        
    }
    
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            PhysixOnOff();
        }
            
    }

    private void PhysixOnOff()
    {
        Debug.Log("Space pressed!!!");
        if (physixSwitch)
        {
            assembler.CollidersOff();
            assembler.GravityOff();
            physixSwitch = false;
        }
        else
        {
            assembler.CollidersOn();
            assembler.GravityOn();
            physixSwitch = true;
        }
    }
    

    /// <summary>
    /// Creature BFS completes the main body of the breath first search. 
    /// It is called By print creature.
    /// </summary>
    /// <param name="c"></param>
    public void CreatureBFS(Creature c)
    {
            foreach (Creature creature0 in c.ChildArray)
            {
                try
                {
                    if(creature0 != null)
                    {
                        Debug.Log("Title: " + creature0.ThisObject + "; ID: " + creature0.ID + "; Child of: " + c.ID);
                        //PrintUsedConnections(c.GetUsedConnections());
                    }
                }
                catch (Exception e)
                {
                    Debug.Log(e.StackTrace);
                }
            }
            foreach (Creature creature1 in c.ChildArray)
            {
                if (creature1 != null)
                {
                    CreatureBFS(creature1);
                }
                
            }
    }

    public void PrintCreature(Creature c)
    {
        Debug.Log("Title: " + c.ThisObject + " ID: " + c.ID);
        //PrintUsedConnections(c.GetUsedConnections());
        CreatureBFS(c);
    }

    public void PrintUsedConnections(int[] usedArr)
    {
        Debug.Log("j0: " + usedArr[0]+ " j1: " + usedArr[1] + " j2: " 
            + usedArr[2] + " j3: " + usedArr[3] + " j4: " + usedArr[4] 
            + " j5: " + usedArr[5]);
    }


}
