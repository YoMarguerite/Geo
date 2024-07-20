using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPrefsDefine : MonoBehaviour
{
    static bool isSet = false;

    [System.Serializable]
    public class Preferences
    {
        public string name;
        public int value;
        public bool affect;
    }

    public List<Preferences> default_value = new List<Preferences>();

    private void Awake()
    {
        print(Debug.isDebugBuild);
        if (Debug.isDebugBuild && !isSet)
        {
            default_value.ForEach(value => {
                if (value.affect) {
                    PlayerPrefs.SetInt(value.name, value.value);
                }
            });
        }
        isSet = true;
    }
}
