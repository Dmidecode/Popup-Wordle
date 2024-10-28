using System.IO;
using UnityEditor;
using UnityEngine;

public class InitScene : MonoBehaviour
{
    void Awake()
    {
        string path = "Assets/Scenes/test.txt";
        var lines = File.ReadAllLines(path);
    }
}
