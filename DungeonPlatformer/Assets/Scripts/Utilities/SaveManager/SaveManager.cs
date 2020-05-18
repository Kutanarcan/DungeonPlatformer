using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager
{
    static readonly string JSON_ENCRYPTED_KEY = "j213#£wewqewq#1232#4½££wewqd{5$2";

    public static void Save<T>(T data, string nameOfTheFile) where T : class
    {
        string json = JsonUtility.ToJson(data);

        byte[] soup = Rijndael.Encrypt(json, JSON_ENCRYPTED_KEY);

        string fileName = Path.Combine(Application.persistentDataPath, nameOfTheFile);

        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        File.WriteAllBytes(fileName, soup);
        Debug.Log(Application.persistentDataPath);
    }

    public static T Load<T>(string nameOfTheFile) where T : class
    {
        string fileName = Path.Combine(Application.persistentDataPath, nameOfTheFile);

        if (!File.Exists(fileName))
        {
            return null;
        }

        byte[] soupBackIn = File.ReadAllBytes(fileName);

        string jsonFromFile = Rijndael.Decrypt(soupBackIn, JSON_ENCRYPTED_KEY);

        T saveDataCopy = JsonUtility.FromJson<T>(jsonFromFile) as T;

        return saveDataCopy;
    }
}
