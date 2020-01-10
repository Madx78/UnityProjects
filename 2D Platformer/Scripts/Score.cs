using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    #region Public & Serialized Members

    public GameObject m_player;

    #endregion

    #region Private & Protected Members

    private int score;

    #endregion

    #region System

    void Update()
    {
        score = PlayerPrefs.GetInt("score");
        gameObject.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }

    #endregion


}
