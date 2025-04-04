using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Position
{
    public float X;
    public float Y;
    public float Z;
}

[System.Serializable]
public class Rotation
{
    public float X;
    public float Y;
    public float Z;
}

[System.Serializable]
public class Scale
{
    public float X;
    public float Y;
    public float Z;
}

[System.Serializable]
public class ObjectData
{
    public Position Position;
    public Rotation Rotation;
    public Scale Scale;
    public int ObjectType;
}

[System.Serializable]
public class Objects
{
    public List<ObjectData> ObjectData;
}

[System.Serializable]
public class CarData
{
    public int CarModelIndex;
    public bool HasSpikedWheels;
    public bool HasRocket;
    public bool HasPropeller;
    public bool HasWings;
}

[System.Serializable]
public class LevelData
{
    public Objects Objects;
    public CarData CarData;
}

[System.Serializable]
public class ArrayOfLevelData
{
    public List<LevelData> LevelData;
}

[System.Serializable]
public class RootObject
{
    public ArrayOfLevelData ArrayOfLevelData;
}

public class LevelLoader : MonoBehaviour
{
    public int LevelCount;
    public TextAsset jsonFile; // ���������� ��� JSON ���� ���� � ����������
    public List<GameObject> objectPrefabs; // ������� �������� (������ = ObjectType)

    private void Start()
    {
        LoadLevel(LevelCount); // ��������� ������ �������
    }

    public void LoadLevel(int levelIndex)
    {
        // ������ JSON
        RootObject root = JsonUtility.FromJson<RootObject>(jsonFile.text);

        //// ��������� ���� �� ����� �������
        //if (levelIndex < 0 || levelIndex >= root.ArrayOfLevelData.LevelData.Count)
        //{
        //    Debug.LogError("Invalid level index!");
        //    return;
        //}

        LevelData level = root.ArrayOfLevelData.LevelData[levelIndex];

        // ������� ������� ������
        foreach (ObjectData objData in level.Objects.ObjectData)
        {
            // ��������� ���� �� ������ ��� ����� ���� �������
            if (objData.ObjectType >= 0 && objData.ObjectType < objectPrefabs.Count && objectPrefabs[objData.ObjectType] != null)
            {
                // ������� ������
                GameObject newObj = Instantiate(objectPrefabs[objData.ObjectType]);

                // ������������� �������, ������� � �������
                newObj.transform.position = new Vector3(objData.Position.X, objData.Position.Y, objData.Position.Z);
                newObj.transform.rotation = Quaternion.Euler(objData.Rotation.X, objData.Rotation.Y, objData.Rotation.Z);
                newObj.transform.localScale = new Vector3(objData.Scale.X, objData.Scale.Y, objData.Scale.Z);
            }
            //else
            //{
            //    Debug.LogWarning($"No prefab assigned for object type {objData.ObjectType}");
            //}
        }

        // ����� ����� �������� �������� ������ �� ������ level.CarData
        //Debug.Log($"Car model: {level.CarData.CarModelIndex}, Spiked wheels: {level.CarData.HasSpikedWheels}");
    }
}