using UnityEngine;
using System.IO;


// Requires junrar library .jar
// tested: junrar-2.0.0.jar
// https://github.com/junrar/junrar


/// <summary>
/// Plugin for extracting .rar files
/// Currently supports android
/// </summary>
public static class UnRarPlugin
{
    /// <summary>
    /// Extracts .rar archive file
    /// </summary>
    /// <param name="archive">Archive file (.rar, .cbr)</param>
    /// <param name="destination">Destination path</param>
    public static void UnRar(string archive, string destination)
    {
        if (!File.Exists(archive))
        {
            Debug.LogWarning("Rar Archive does not exist");
            return;
        }

        if (!Directory.Exists(destination))
        {
            Debug.LogWarning("Rar Destination does not exist");
            return;
        }

        Extract(archive, destination);
    }

    /// <summary>
    /// Extracts .rar archive file
    /// </summary>
    /// <param name="archive">Archive file (.rar, .cbr)</param>
    /// <param name="destination">Destination path</param>
    /// <param name="createDestination">Create folder for destination</param>
    public static void UnRar(string archive, string destination, bool createDestination)
    {
        if (!File.Exists(archive))
        {
            Debug.LogWarning("Rar Archive does not exist");
            return;
        }

        if (!Directory.Exists(destination))
        {
            Directory.CreateDirectory(destination);
        }

        if (!Directory.Exists(destination))
        {
            Debug.LogWarning("Rar Destination does not exist");
            return;
        }

        Extract(archive, destination);
    }

    /// <summary>
    /// Extracts .rar archive file to current folder
    /// </summary>
    /// <param name="archive">Archive file (.rar, .cbr)</param>
    /// <param name="createFolder">Create folder or extract here</param>
    public static void UnRar(string archive, bool createFolder)
    {
        if (!File.Exists(archive))
        {
            Debug.LogWarning("Rar Archive does not exist");
            return;
        }

        FileInfo arcFile = new FileInfo(archive);
        string destination = arcFile.Directory.Name + "/" + arcFile.Name;

        if (createFolder)
            Directory.CreateDirectory(destination);
        else
        {
            destination = arcFile.Directory.Name;
        }

        if (!Directory.Exists(destination))
        {
            Debug.LogWarning("Rar Destination does not exist");
            return;
        }

        Extract(archive, destination);
    }

    static void Extract(string archive, string destination)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        using (var jo = new AndroidJavaObject("com.github.junrar.Junrar"))
        {
            jo.CallStatic("extract", archive, destination);
        }
#endif

        // TODO: handle other platforms 
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
#endif

#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
#endif

#if UNITY_IOS && !UNITY_EDITOR
#endif
    }
}
