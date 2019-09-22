using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadscreenHandler : MonoBehaviour
{
    [SerializeField] Slider m_progressbar;
    [SerializeField] List<string> m_funnytexts;
    [SerializeField] TextMeshProUGUI m_funnytext;
    ButtonInitializer m_buttoninitializer;

    //float m_funnytextchangetimer;

    void Start()
    {
        ChangeText();
        LoadLevel(1);
    }

    public void LoadLevel(int sceneindex)
    {
        StartCoroutine(LoadAsync(sceneindex));
    }

    IEnumerator LoadAsync(int sceneindex)
    {
        AsyncOperation asyncloading = SceneManager.LoadSceneAsync(sceneindex);


        while(!asyncloading.isDone)
        {
            float progress = Mathf.Clamp01(asyncloading.progress / 0.9f);

            //m_funnytextchangetimer += 1;

            m_progressbar.value = progress;

            //if (m_funnytextchangetimer > 40)
            //{
            //    ChangeText();
            //    m_funnytextchangetimer = 0;
            //    Debug.Log(m_funnytextchangetimer);
            //}

            Debug.Log("Loading");

            yield return null;
        }
    }

    void ChangeText()
    {
        m_funnytext.text = m_funnytexts[Random.Range(0, m_funnytexts.Count)];
    }
}
