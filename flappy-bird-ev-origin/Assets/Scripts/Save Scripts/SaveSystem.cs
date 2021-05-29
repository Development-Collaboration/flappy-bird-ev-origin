
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

// 참조 영상
// https://youtu.be/GoHYSOFiZHc
// https://youtu.be/5roZtuqZyuw
// https://youtu.be/XOjd_qU2Ido



// I personally added static
public static class SaveSystem
{
    private static string location = Application.persistentDataPath + "/Saves/";
    private static string gameScoreDataName = "gameScore.dat";


    public static void Save(GameScore gameScore)
    {

        // Creating Folder
        if (!Directory.Exists(Application.persistentDataPath + "/Saves/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves/");
        }

        //string path = Application.persistentDataPath + "/Saves/" +  "/gameScore.dat";
        string path = location + gameScoreDataName;

        // Current path on my pc : C:\Users\in9_l\AppData\LocalLow\DefaultCompany\Flappy Bird Ev\Saves

        BinaryFormatter formatter = new BinaryFormatter();

        //FileStream stream = new FileStream(path, FileMode.Create);
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

        try
        {
            GameData data = new GameData(gameScore);
            formatter.Serialize(stream, data);
        }
        catch (SerializationException e)
        {
            Debug.LogError("There was an issue serializaing this data: " + e.Message);
        }
        finally
        {
            stream.Close();
        }

        //
        /*
        GameData data = new GameData(gameScore);

        // Write data to the file
        formatter.Serialize(stream, data);
        stream.Close(); // 꼭 close !!!
        */
    }
    public static GameData Load()
    {
        //string path = Application.persistentDataPath + "/Saves/" +  "gameScore.dat";
        string path = location + gameScoreDataName;

        // 안전 검사
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            //
            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();// 꼭 close !!!

            return data;
        }

        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    // Works   
    /*
    public static void Save(GameScore gameScore)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gameScore.dat";

        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(gameScore);

        // Write data to the file
        formatter.Serialize(stream, data);
        stream.Close(); // 꼭 close !!!
    }
    public static GameData Load()
    {
        string path = Application.persistentDataPath + "/gameScore.dat";
        // 안전 검사
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();// 꼭 close !!!

            return data;
        }

        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    
    */

    /*
    public static void Save()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/Game.dat", FileMode.OpenOrCreate);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, );
        }
        catch (SerializationException e)
        {
            Debug.LogError("There was an issue serializing this data: " + e.Message);
        }
        finally
        {
            file.Close();
        }
        file.Close();
    }
    */


    //public static void Save(object saveDate, string saveName = "Save_File", string saveType = ".dat")
    //{
    //    BinaryFormatter formatter = GetBinaryFormatter();

    //    if(!Directory.Exists(Application.persistentDataPath + "/saves"))
    //    {
    //        Directory.CreateDirectory(Application.persistentDataPath + "/saves");
    //    }

    //    #region Application.persistentDataPath Explanation
    //    /*
    //     Instead of Application.persistentDataPath 
    //    You can asign typical location such as "C:/System/"
    //    But in that case there will be issues on cross platform (window, mac, linux)
    //    as well as security issue
    //     */

    //    /*
    //     Since it's binary file
    //    You can Write any Type, name inbetween " "
    //    ex: "~~~~~.anything"
    //    */

    //    #endregion
    //    string path = Application.persistentDataPath + "/saves/" + saveName + saveType;

    //    FileStream fileStream = new FileStream(path, FileMode.Create);
    //    //FileStream fileStream = File.Create(path);

    //    // Writting data to file
    //    formatter.Serialize(fileStream, saveDate);

    //    // Must close;
    //    fileStream.Close();

    //}

    //public static object Load(string saveName = "Save_File", string saveType = ".dat")
    //{
    //    string path = Application.persistentDataPath + "/saves/" + saveName + saveType;

    //    if (!File.Exists(path))
    //    {
    //        Debug.LogErrorFormat("File doesn't exist at {0}", path);
    //        return null;
    //    }

    //    BinaryFormatter formatter = GetBinaryFormatter();

    //    //FileStream fileStream = File.Open(path, FileMode.Open);
    //    FileStream fileStream = new FileStream(path, FileMode.Open);


    //    try
    //    {
    //        object save = formatter.Deserialize(fileStream);
    //        fileStream.Close();
    //        return save;
    //    }
    //    catch
    //    {
    //        Debug.LogErrorFormat("Failed to load file at {0}", path);
    //        fileStream.Close();
    //        return null;
    //    }

    //}

    //public static BinaryFormatter GetBinaryFormatter()
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();

    //    return formatter;
    //}


}