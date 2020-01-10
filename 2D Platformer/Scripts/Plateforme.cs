using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateforme : MonoBehaviour
{
     public enum BUMPERS
    {
        LEFT_BUMPER,
        RIGHT_BUMPER
    }
    #region Public & Serialized Members
    [Header("Plateforme Settings")]

    public GameObject m_player;

    public GameObject m_bumperLeft;
    public GameObject m_bumperRight;
    [SerializeField][Range(0.1f,5f)] private float _speed = 3f;

    public BUMPERS m_firstBumperToReach;

    #endregion

    #region Private  & Protected Members
    private GameObject _firstBumper;
    private Transform _target;


    #endregion

    #region System
    private void Start()
    {
        switch (m_firstBumperToReach)
        {
            case BUMPERS.LEFT_BUMPER:
                _firstBumper = m_bumperRight;
                break;

            case BUMPERS.RIGHT_BUMPER:
                _firstBumper = m_bumperLeft;

                break;
        }

        transform.position = _firstBumper.transform.position;
    }

    private void Update()
    {
        PlateformeTarget();
        PlateformeTravel();

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //à l'arriver du joueur sur l aplateforme celle ci devient le parent du joueur il suit ainsi sa position
        if (other.gameObject == m_player)
        {
            m_player.transform.parent = transform;
        }

        
    }

    // a la sortie du joueur de la plateforme celle ci n'est plus sont parent.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == m_player)
        {
            m_player.transform.parent = null;
        }
    }

    #endregion

    #region Main Methodes

    private void PlateformeTarget()
    {
        if(gameObject.transform.position == m_bumperLeft.transform.position)
        {
            _target = m_bumperRight.transform;
        }

        if (gameObject.transform.position == m_bumperRight.transform.position)
        {
            _target = m_bumperLeft.transform;
        }

    }

    private void PlateformeTravel()
    {
        float _step = _speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _step); //La plateforme se dirige dans la direction d'un bumper.
    }
    #endregion
}
