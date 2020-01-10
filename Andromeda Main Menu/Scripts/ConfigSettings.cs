using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigSettings : MonoBehaviour
{
    public List<GameObject> subMenus;
    public List<GameObject> buttons;
   

   
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject _menu in subMenus)
        {
            if (_menu == subMenus[0])
            {
                _menu.SetActive(true);
            }
            else
            {
                _menu.SetActive(false);
            }
        }

       
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnClickGame()
    {
        
            
        foreach (GameObject _menu in subMenus)
        {
            if(_menu == subMenus[0])
            {
                _menu.SetActive(true);
            
            }
            else
            {
                _menu.SetActive(false);
            }
        
        }
        

    }
    public void OnClickControls()
    {
        

        foreach (GameObject _menu in subMenus)
        {
            if (_menu == subMenus[1])
            {
                _menu.SetActive(true);
            }
            else
            {
                _menu.SetActive(false);
            }
        }
    }
    public void OnClickVideo()
    {
        
        foreach (GameObject _menu in subMenus)
        {
            if (_menu == subMenus[2])
            {
                _menu.SetActive(true);
            }
            else
            {
                _menu.SetActive(false);
            }
        }
    }

    public void SelectedButtons()
    {
        for (int i = 0; i < subMenus.Count; i++)
        {
            if (subMenus[i].activeSelf)
            {
                buttons[i].GetComponent<Button>().Select();
            }
        }
    }


}
