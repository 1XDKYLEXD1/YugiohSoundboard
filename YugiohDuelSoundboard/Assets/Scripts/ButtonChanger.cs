using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChanger : MonoBehaviour
{
    [SerializeField] List<GameObject> m_selections;
    [SerializeField] GameObject m_parentobject;

    void Start()
    {
        m_selections = new List<GameObject>();

        foreach(Transform child in m_parentobject.transform)
        {
            m_selections.Add(child.gameObject);
        }
    }

    public void OnSelectionChange(Dropdown _menu)
    {
        for (int selec = 0; selec < m_selections.Count; selec++)
        {
            if(selec == _menu.value)
            {
                m_selections[selec].SetActive(true);
            }
            else
            {
                m_selections[selec].SetActive(false);
            }
        }
    }
}
