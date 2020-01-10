using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // la camera va suivre le joueur avec un Lerp
    //Le script à besoin de connaitre le GO que la camera doit suivre
    //il faut utiliser Vector3.Lerp pour connaitre la position que doit avoir la camera
    // !! La camera doit suivre le joeur en X et Y. si la camera rejoint la position Z du joueur il ne sera plus affiché



    [Header("Camera Settings")]
    public bool m_autoFollow;
    public GameObject m_followTarget;
    [Tooltip("Camera follow speed")]
    [SerializeField][Range(0f,1f)] private float _smoothLerp = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        if(m_followTarget is null || m_autoFollow)
        {
            m_followTarget = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 _camPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
        Vector3 _camPosition = gameObject.transform.position;
        Vector3 _playerPosition = new Vector3(m_followTarget.transform.position.x, m_followTarget.transform.position.y, gameObject.transform.position.z );
        transform.position = Vector3.Lerp(_camPosition, _playerPosition, _smoothLerp);
    }
}
