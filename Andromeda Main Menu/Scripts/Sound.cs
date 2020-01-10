using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public Slider volumeControler;

    private float _volume;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
      VolumeControl();
       
       
    }

    public void VolumeControl()
    {
         _volume = volumeControler.value;
        gameObject.GetComponent<AudioSource>().volume = _volume;
    }
}
