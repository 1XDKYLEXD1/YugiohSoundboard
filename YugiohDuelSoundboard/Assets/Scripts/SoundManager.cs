using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public void StopAllAudio()
    {
        AudioSource[] m_sounds = FindObjectsOfType<AudioSource>();
        for (int a = 0; a < m_sounds.Length; a++)
        {
            m_sounds[a].Stop();
        }
    }
}
