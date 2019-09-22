using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sound", menuName = "Sounds/CreateNewSound")]
public class SoundCreator : ScriptableObject
{
    public string m_soundname;
    public AudioClip m_audiosound;
    public int m_fontsize;
}
