using UnityEngine;

public class UnRarExample : MonoBehaviour {
    public void TestUnrar()
    {
        string archivePath = "/storage/emulated/0/Download/example.rar";
        string destinationPath = "/storage/emulated/0/Download/example/";

        UnRarPlugin.UnRar(archivePath, destinationPath);
    }
}