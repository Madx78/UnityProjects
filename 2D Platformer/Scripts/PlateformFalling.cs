using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformFalling : MonoBehaviour
{
    public GameObject Player;
    public GameObject bumperStart;
    public GameObject bumperEnd;
    public GameObject plateforme;
   private Transform _target;
    private Animator _animation;
    private float _step;

    [SerializeField]
    private float _fallSpeed= 30f;

    [SerializeField]
    private float _fallDelay = 2f;
    [SerializeField]
    private float _shakeDelay = 0.1f;

    private bool _isFalling = false;
    private bool _remonte = false;

    private void Start()
    {
         _step = _fallSpeed * Time.deltaTime;
        _animation = plateforme.GetComponent<Animator>();
        _target = bumperStart.transform;
    }

    private void Update()
    {
        Debug.Log("Is falling " + _isFalling);
        PlateformeTarget();
        PlateFormFall();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Player)
        {
            Debug.Log("Player détecté");
            StartCoroutine(Tremblement());
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(Tremblement());  
    }

    IEnumerator Tremblement()
    {

        yield return new WaitForSeconds(_shakeDelay);
        _animation.SetTrigger("Start");
 
        yield return new WaitForSeconds(_fallDelay);
        _isFalling = true;

    }

    private void PlateformeTarget()
    {
        if (gameObject.transform.position == bumperStart.transform.position)
        {
            _target = bumperEnd.transform;
        }

        if (gameObject.transform.position == bumperEnd.transform.position)
        {
            _target = bumperStart.transform;
        }

    }

    private void PlateFormFall()
    {
        if (_isFalling == true )
        {
            //Debug.Log("la position cible est " + _target.position);
            gameObject.transform.position = Vector3.MoveTowards(transform.position, _target.position, _step);

        }

        //On est tombé
        if (transform.position == bumperEnd.transform.position)
        {

            _isFalling = false;
            _animation.SetTrigger("idleBack");
            
        }

        if (transform.position == bumperEnd.transform.position && !_remonte)
        {
            _remonte = true;
            //Debug.Log("Coroutine remonte");
            StartCoroutine(Remonte());
           // gameObject.transform.position = Vector3.MoveTowards(transform.position, _target.position, _step);
        }

        
    }

    IEnumerator Remonte()
    {
        yield return new WaitForSeconds(2f);

        while (gameObject.transform.position != bumperStart.transform.position )
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, _target.position, _step);
            yield return new WaitForEndOfFrame();
        }
        _remonte = false;
        StopAllCoroutines();
    }
}
