using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]
public class Position
{
    public float X; public float Y; public float Z;
}

[System.Serializable]
public class Rotation
{
    public float X; public float Y; public float Z;
}
[System.Serializable]
public class Scale
{
    public float X; public float Y; public float Z;
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
public class CarData
{
    public int CarModelIndex;
    public bool HasSpikedWheels;
    public bool HasRocket;
    public bool HasPropeller;
    public bool HasWings;
}
[System.Serializable]
public class Objects
{
    public List<ObjectData> ObjectData;
}
[System.Serializable]
public class LevelData
{
    public CarData CarData;
    public Objects Objects;
}
[System.Serializable]
public class ArrayOfLevelData
{
    public List<LevelData> LevelData;
}
[System.Serializable]
public class RootObject
{
    public ArrayOfLevelData arrayOfLevelData;
}
public class LevelLoader : MonoBehaviour
{
    public int NumberOfLevel;
    public TextAsset JsonFile;
    public List<GameObject> GameObjectList;

    public void GenerateLevel(int LevelIndex)
    {
        RootObject file = JsonUtility.FromJson<RootObject>(JsonFile.text);
        LevelData level = file.arrayOfLevelData.LevelData[LevelIndex];

        foreach (ObjectData Data in level.Objects.ObjectData)
        {
            GameObject created = Instantiate(GameObjectList[Data.ObjectType]);
            created.transform.position = new Vector3(Data.Position.X,Data.Position.Y,Data.Position.Z);
            created.transform.rotation = Quaternion.Euler(Data.Position.X, Data.Position.Y, Data.Position.Z);
            created.transform.localScale = new Vector3(Data.Position.X, Data.Position.Y, Data.Position.Z);
        }

    }
}

































//[System.Serializable]
//public class Position
//{
//    public float X;
//    public float Y;
//    public float Z;
//}

//[System.Serializable]
//public class Rotation
//{
//    public float X;
//    public float Y;
//    public float Z;
//}

//[System.Serializable]
//public class Scale
//{
//    public float X;
//    public float Y;
//    public float Z;
//}

//[System.Serializable]
//public class ObjectData
//{
//    public Position Position;
//    public Rotation Rotation;
//    public Scale Scale;
//    public int ObjectType;
//}

//[System.Serializable]
//public class Objects
//{
//    public List<ObjectData> ObjectData;
//}

//[System.Serializable]
//public class CarData
//{
//    public int CarModelIndex;
//    public bool HasSpikedWheels;
//    public bool HasRocket;
//    public bool HasPropeller;
//    public bool HasWings;
//}

//[System.Serializable]
//public class LevelData
//{
//    public Objects Objects;
//    public CarData CarData;
//}

//[System.Serializable]
//public class ArrayOfLevelData
//{
//    public List<LevelData> LevelData;
//}

//[System.Serializable]
//public class RootObject
//{
//    public ArrayOfLevelData ArrayOfLevelData;
//}

//public class LevelLoader : MonoBehaviour
//{
//    public int LevelCount;
//    public TextAsset jsonFile; // Перетащите ваш JSON файл сюда в инспекторе
//    public List<GameObject> objectPrefabs; // Префабы объектов (индекс = ObjectType)

//    private void Start()
//    {
//        LoadLevel(LevelCount); // Загружаем первый уровень
//    }

//    public void LoadLevel(int levelIndex)
//    {
//        // Парсим JSON
//        RootObject file = JsonUtility.FromJson<RootObject>(jsonFile.text);
//        //RootObject root = JsonUtility.FromJson<RootObject>(jsonFile.text);

//        //// Проверяем есть ли такой уровень
//        //if (levelIndex < 0 || levelIndex >= root.ArrayOfLevelData.LevelData.Count)
//        //{
//        //    Debug.LogError("Invalid level index!");
//        //    return;
//        //}
//        LevelData lvl = file.ArrayOfLevelData.LevelData[levelIndex];
//        //LevelData level = root.ArrayOfLevelData.LevelData[levelIndex];

//        // Создаем объекты уровня
//        foreach (ObjectData data in lvl.Objects.ObjectData)
//        {
//            GameObject createdObj = Instantiate(objectPrefabs[data.ObjectType]);
//            createdObj.transform.position = new Vector3(data.Position.X, data.Rotation.Y, data.Rotation.Z);
//            createdObj.transform.localScale = new Vector3(data.Scale.X, data.Scale.Y, data.Scale.Z);
//            createdObj.transform.rotation = Quaternion.Euler(data.Rotation.X, data.Rotation.Y, -data.Rotation.Z);

//        }
//        //foreach (ObjectData objData in level.Objects.ObjectData)
//        //{
//        //    Проверяем есть ли префаб для этого типа объекта
//        //    if (objData.ObjectType >= 0 && objData.ObjectType < objectPrefabs.Count && objectPrefabs[objData.ObjectType] != null)
//        //    {
//        //        Создаем объект
//        //        GameObject newObj = Instantiate(objectPrefabs[objData.ObjectType]);

//        //        Устанавливаем позицию, поворот и масштаб
//        //        newObj.transform.position = new Vector3(objData.Position.X, objData.Position.Y, objData.Position.Z);
//        //        newObj.transform.rotation = Quaternion.Euler(objData.Rotation.X, objData.Rotation.Y, objData.Rotation.Z);
//        //        newObj.transform.localScale = new Vector3(objData.Scale.X, objData.Scale.Y, objData.Scale.Z);
//        //    }
//        //    else
//        //    {
//        //        Debug.LogWarning($"No prefab assigned for object type {objData.ObjectType}");
//        //    }
//        //}

//        // Здесь можно добавить создание машины по данным level.CarData
//        //Debug.Log($"Car model: {level.CarData.CarModelIndex}, Spiked wheels: {level.CarData.HasSpikedWheels}");
//    }
//}