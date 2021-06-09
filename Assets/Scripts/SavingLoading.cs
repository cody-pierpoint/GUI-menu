using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SavingLoading
{
    //public static void SavePlayer(FirstPersonFlight player)
    //{
    //    Debug.Log("SAVING");
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    string path = Application.dataPath + "/Score.sav";
    //    FileStream stream = new FileStream(path, FileMode.Create);

    //    PlayerData data = new PlayerData(player);
    //    formatter.Serialize(stream, data);
    //    stream.Close();


    //}
    public static PlayerData LoadPlayer()
    {
        Debug.Log("LOADING");
        string path = Application.dataPath + "/Score.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }


    }
}
