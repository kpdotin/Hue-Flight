using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class JsonDataService : IDataService
{
    private const string KEY = "Pyzr/lwqUsQqImtgGFTJrEiji/Evu9GOT/Phr7LHj7g=";
    private const string IV = "cYUxco7OvTcYvgnbGJLXRg==";


    public bool SaveData<T>(string RelativePath, T Data, bool Encrypted)
    {
        string path = Application.persistentDataPath + RelativePath;
        
        try
        {
            #region commented out
            //if (File.Exists(path))
            //{
            //    Debug.Log("Data exists. Deleting old file and writing a new one!");
            //    File.Delete(path);
            //}
            //else
            //{
            //    Debug.Log("Creating file for the first time!");
            //}
            //using FileStream stream = File.Create(path);
            //if (Encrypted)
            //{
            //    WriteEncryptedData(Data, stream);
            //}
            //else
            //{
            //    stream.Close();
            //    File.WriteAllText(path, JsonConvert.SerializeObject(Data));
            //}
            #endregion

            File.WriteAllText(path, JsonConvert.SerializeObject(Data,Formatting.Indented));
            return true;
        }
        catch(Exception e)
        {
            Debug.LogError($"Unable to save data due to: {e.Message} {e.StackTrace}");
            return false;
        }
    }
    
    void WriteEncryptedData<T>(T Data, FileStream stream)
    {
        using Aes aesprovider = Aes.Create();
        aesprovider.Key = Convert.FromBase64String(KEY);
        aesprovider.IV = Convert.FromBase64String(IV);
        using ICryptoTransform cryptoTransform = aesprovider.CreateEncryptor();
        using CryptoStream cryptoStream = new CryptoStream(
            stream,
            cryptoTransform,
            CryptoStreamMode.Write
            );


        Debug.Log($"Initialization Vector: {Convert.ToBase64String(aesprovider.IV)}");
        Debug.Log($"Key: {Convert.ToBase64String(aesprovider.Key)}");
    }
    public T LoadData<T>(string RelativePath, bool Encrypted)
    {
        string path  =  Application.persistentDataPath + RelativePath;
        if (!File.Exists(path))
        {
            Debug.LogError($"Cannot load file at {path}.File does not exist!");
            throw new FileNotFoundException($"{path} does not exist!");
        }
        try
        {
            T data;
            if (Encrypted)
            {
                data = ReadEncryptedData<T>(path);
            }
            else 
            {
                data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            }
            return data;
        }
        catch(Exception e)
        {
            Debug.LogError($"Failed to Load Data due to: {e.Message} {e.StackTrace}");
            throw e;
        }
    }

    private T ReadEncryptedData<T>(string path)
    {
        byte[] fileBytes = File.ReadAllBytes(path);
        
        using Aes aesprovider = Aes.Create();
        aesprovider.Key = Convert.FromBase64String(KEY);
        aesprovider.IV = Convert.FromBase64String(IV);

        using ICryptoTransform cryptoTransform = aesprovider.CreateDecryptor(
            aesprovider.Key,
            aesprovider.IV
            );

        using MemoryStream decryptionStream = new MemoryStream(fileBytes);
        using CryptoStream cryptoStream = new CryptoStream(
            decryptionStream,
            cryptoTransform,
            CryptoStreamMode.Read
            );

        using StreamReader reader = new StreamReader(cryptoStream);
        
        string result = reader.ReadToEnd();

        Debug.Log($"Decrypted result (if the following is not legible, probably wrong key or iv): {result}");
        return JsonConvert.DeserializeObject<T>(result);
    }
}
