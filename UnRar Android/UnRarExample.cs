using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnRarExample : MonoBehaviour {

    public void TestUnrar()
    {
        string arc = "/storage/emulated/0/Download/example.rar";
        string dest = "/storage/emulated/0/Download/example/";

        UnRarPlugin.UnRar(arc, dest);
    }

}
