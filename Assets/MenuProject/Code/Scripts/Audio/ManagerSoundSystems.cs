using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDev3.Project;

public class ManagerSoundSystems : MonoBehaviour
{

    public static string _Level;
    public static string _LevelCurrent;
    public static bool isPlay;

    public string CurrentLevel;

    private void Start()
    {
        _Level = CurrentLevel;
        AudioManager.ChangeScene = true;
    }
}
