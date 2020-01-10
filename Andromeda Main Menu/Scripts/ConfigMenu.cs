using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigMenu : MonoBehaviour
{
    public List<GameObject> Buttons;
    public GameObject playSub;


    private bool PlayIsActive= false;
    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void OnClickPlay()
    {
        //PlayIsActive = !PlayIsActive;
        //playSub.SetActive(PlayIsActive);

        if (PlayIsActive == false)
        {
            playSub.GetComponent<Animator>().SetTrigger("PlayIsActive");
            PlayIsActive = true;
        }

        //if (PlayIsActive == true)
        else
        {
            playSub.GetComponent<Animator>().SetTrigger("PlayIsInactive");
            PlayIsActive = false;
        }

    }
}
