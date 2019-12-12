using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Create an instance of the Musinc Mnager and persist through game levels
    private static MusicManager instance;

    // Get reference to the volume Sliders

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Master Volume
    // Music Volume
    // Effects Volume
}
