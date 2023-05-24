using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedTheme : MonoBehaviour
{
    [SerializeField]
    private GameObject[] themeObjctes;

    private void Awake()
    {
        themeObjctes[PlayerPrefs.GetInt("SelectedTheme")].SetActive(true);
    }
   
}
