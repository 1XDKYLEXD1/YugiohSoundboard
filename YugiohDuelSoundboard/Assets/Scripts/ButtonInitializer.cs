using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System.IO;

//100pixels between x and y is (-)40
public class ButtonInitializer : MonoBehaviour
{
    List<SoundCreator> m_buttonsounds;
    [SerializeField] Button m_soundbutton;
    [SerializeField] Dropdown m_selectionmenu;

    [SerializeField] Vector2 m_buttonspawnpos;

    [SerializeField] GameObject m_parentobject;

    [SerializeField] int m_maxhorizontalrow;
    [SerializeField] int m_horizontalbuttonspacing;
    [SerializeField] int m_verticalbuttonspacing;

    //[SerializeField] TextMeshProUGUI DEBUG_TEXT;

    void Awake()
    {
        m_buttonspawnpos = Vector2.zero;

        //Werkt goed... alleen voor PC zorg dat ook voor mobiel werkt.
        //DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/Resources/Sounds/SoundObjects");
        //DirectoryInfo[] info = dir.GetDirectories();

        //foreach (DirectoryInfo folder in info)
        //{
        //    List<string> directioryfolders = new List<string>() { folder.Name };
        //    m_selectionmenu.AddOptions(directioryfolders);
        //}

        for (int o = 0; o < m_selectionmenu.options.Count; o++)
        {
            m_buttonspawnpos = new Vector2(-65, 385);
            m_buttonsounds = Resources.LoadAll<SoundCreator>("Sounds/SoundObjects/" + m_selectionmenu.options[o].text).ToList<SoundCreator>();
            GenerateButtonGrid(o);
        }
    }

    void GenerateButtonGrid(int _selection)
    {
        int currentbuttonid = 0;

        GameObject buttondivider = new GameObject();
        buttondivider.name = m_selectionmenu.options[_selection].text;
        buttondivider.transform.SetParent(m_parentobject.transform, false);

        if (_selection != 0)
        {
            buttondivider.gameObject.SetActive(false);
        }

        for (int yheight = 0; yheight < Mathf.Ceil((float)m_buttonsounds.Count / 2); yheight++)
        {
            for (int xwidth = 0; xwidth < m_maxhorizontalrow; xwidth++)
            {
                if (currentbuttonid <= m_buttonsounds.Count - 1)
                {
                    m_buttonspawnpos.x += 100 * xwidth;

                    Button newbutton = (Button)Instantiate(m_soundbutton, new Vector3(m_buttonspawnpos.x, m_buttonspawnpos.y, 0), Quaternion.identity);
                    newbutton.transform.SetParent(buttondivider.transform, false);
                    newbutton.GetComponentInChildren<Text>().text = m_buttonsounds[currentbuttonid].m_soundname;
                    newbutton.GetComponentInChildren<Text>().fontSize = m_buttonsounds[currentbuttonid].m_fontsize;
                    newbutton.GetComponent<AudioSource>().clip = m_buttonsounds[currentbuttonid].m_audiosound;
                }
                else
                {
                    break;
                }
                currentbuttonid += 1;
            }

            m_buttonspawnpos.x = m_horizontalbuttonspacing;
            m_buttonspawnpos.y -= m_verticalbuttonspacing;
        }
    }
}
