using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// Use BinaryFormatters to write to and read from files
// Contains basic functions for reading and writing strings to files
// Use custom SaveLoad scripts for different purposes to parse the strings in different formats
// I.E. Narrative Conditions are saved one-per-line and split that way
public static class SaveLoad
{
    /// <summary>
    /// Save an inputted string to a file of a certain name
    /// </summary>
    /// <param name="text">The text to be saved to file</param>
    /// <param name="fileName">The name of the file, omitting the path (ex. "testFile.json")</param>
    public static void Save(string text, string fileName)
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            Stream saveFile = File.Open(Application.persistentDataPath + "/" + fileName, FileMode.Create);

            Debug.Log("[SaveLoad] Saving text:\n" + text);

            bf.Serialize(saveFile, text);

            saveFile.Close();
        }
        catch (System.Exception e)
        {
            Debug.LogError("[SaveLoad] An error has occurred while saving to file:\n" + e.Message);
        }
    }

    /// <summary>
    /// Load a string of text from a file with a certain format
    /// </summary>
    /// <param name="fileName">The name of the file to load, omitting the path (ex. "testFile.json")</param>
    /// <returns></returns>
    public static string Load(string fileName)
    {
        try
        {
            if(FileExists(fileName))
            {
                BinaryFormatter bf = new BinaryFormatter();

                Stream loadFile = File.Open(Application.persistentDataPath + "/" + fileName, FileMode.Open);

                string text = bf.Deserialize(loadFile) as string;

                loadFile.Close();

                Debug.Log("[SaveLoad] Loading text:\n" + text);

                return text;
            }

            // A file was not found, so just return an empty string
            return "";
        }
        catch(System.Exception e)
        {
            Debug.LogError("[SaveLoad] An error has occured while reading from file:\n" + e.Message);
        }

        return null;
    }

    /// <summary>
    /// Append text to the end of a file
    /// </summary>
    /// <param name="text">The text to append</param>
    /// <param name="fileName">The name of the file, omitting the file path</param>
    public static void SaveAppend(string text, string fileName)
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            string beforeText = Load(fileName);

            Stream saveFile = File.Open(Application.persistentDataPath + "/" + fileName, FileMode.Create);

            bf.Serialize(saveFile, beforeText + text);

            saveFile.Close();
        }
        catch (System.Exception e)
        {
            Debug.LogError("[SaveLoad] An error has occurred while saving to file:\n" + e.Message);
        }
    }

    /// <summary>
    /// Delete a file with specified name from the persistent data path
    /// </summary>
    /// <param name="fileName">The name of the file, omitting the file path</param>
    public static void DeleteFile(string fileName)
    {
        if (FileExists(fileName))
        {
            File.Delete(Application.persistentDataPath + "/" + fileName);
        }
    }

    /// <summary>
    /// Whether a specified file exists based on its name
    /// </summary>
    /// <param name="fileName">The name of the file to search for, omitting the file path</param>
    /// <returns>Returns true if the file is found and false otherwise</returns>
    public static bool FileExists(string fileName)
    {
        return File.Exists(Application.persistentDataPath + "/" + fileName);
    }
}
