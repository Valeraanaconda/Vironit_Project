using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Создаем отдельный класс для записи всех данных объекта
[Serializable]
public class Data
{
    public List<Transform> TRANSposition = new List<Transform>();
    public List<Vector3> position = new List<Vector3>();
    public List<Quaternion> rotation = new List<Quaternion>();
    public List<Vector3> velocity = new List<Vector3>();
    public List<Vector3> angularVelocity = new List<Vector3>();
}

[Serializable]
public class SaveLoadManager : MonoBehaviour
{
    private void Start()
    {
        if(File.Exists("E:/" + "Save.txt")) 
        {
            LoadData();
        }
    }
    // Делаем поле публичным для добавления объектов, которые необходимо сохранять
    public List<GameObject> sphere;

    // Экзепляр класса Data
    Data enemy = new Data();

    public void SaveData()
    {
        for (int i = 0; i < sphere.Count; i++)
        {
            enemy.position.Add(sphere[i].transform.position);
            enemy.rotation.Add(sphere[i].transform.rotation);
            if (sphere[i].GetComponent<Rigidbody>() != null)
            {
                enemy.velocity.Add(sphere[i].GetComponent<Rigidbody>().velocity);
                enemy.angularVelocity.Add(sphere[i].GetComponent<Rigidbody>().angularVelocity);
            }
        }
        string json = JsonUtility.ToJson(enemy, true);
        File.WriteAllText("E:/" + "Save.txt", json);
    }

    public void LoadData()
    {
        string json = File.ReadAllText("E:/" + "Save.txt");
        Data returnData = JsonUtility.FromJson<Data>(json);
        for (int i = 0; i < sphere.Count; i++)
        {
            sphere[i].transform.position = returnData.position[i];
            sphere[i].transform.rotation = returnData.rotation[i];
            if (sphere[i].GetComponent<Rigidbody>() != null)
            {
                sphere[i].GetComponent<Rigidbody>().velocity = returnData.velocity[i];
                sphere[i].GetComponent<Rigidbody>().angularVelocity = returnData.angularVelocity[i];
            }
        }
    }
}




