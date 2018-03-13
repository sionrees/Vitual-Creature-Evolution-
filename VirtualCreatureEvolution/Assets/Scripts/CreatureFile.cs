using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class CreatureFile{
    //[SerializeField] List<Creature> clist;
    [SerializeField] Creature creature;
    private BinaryFormatter formatter;
    private const string CREATURE_FILENAME = "Creature_Population.dat";

    public CreatureFile()
    {
        //this.clist = new List<Creature>();
        this.formatter = new BinaryFormatter();
    }

    public void AddCreature(Creature c)
    {
        //clist.Add(c);
        creature = c;
    }

    public Creature GetCreature()
    {
        //return clist;
        return creature;
    }

    //Saves a List of Creatures
    public void Save()
    {
        try
        {
            //Debug.Log("Creatures saving...");
            FileStream writeFileStream = new FileStream(CREATURE_FILENAME, FileMode.Create, FileAccess.Write);
            //Debug.Log("FileStream opens");
            formatter.Serialize(writeFileStream, creature);
            //Debug.Log("Creature serialized");
            writeFileStream.Close();
            
        }
        catch(Exception e)
        {
            Debug.Log("Population save failed!!!");
            Debug.Log(e.Message);
        }
    }

    //Loads a List of Creatures 
    public void Load()
    {
        if (File.Exists(CREATURE_FILENAME))
        {
            try
            {
                FileStream readFileStream = new FileStream(CREATURE_FILENAME,FileMode.Open, FileAccess.Read);
                creature = (Creature)formatter.Deserialize(readFileStream);
                //Debug.Log("Creature loaded from file!");
                readFileStream.Close();
                
            }
            catch(Exception e)
            {
                Debug.Log("Creature List exists but failed to load");
                Debug.Log(e.StackTrace);
            }
        } 
    }
}
