using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMotor2 : MonoBehaviour
{
    #region Public & Serialize Members
    [Header("Player Motor Settings")]
    public GameObject m_graphics;
    public GameObject m_Spawner;
    public Transform m_groundCheck;
    public float m_radius;
    public LayerMask m_groundLayer;



    [Header("Player Settings")]
    [SerializeField] private float _playerSpeed = 3f;
    [SerializeField] private float _jumpForce =300f;
    [Range(1,5)]public int m_jumpNumber;

    [Header("Score")]
    public int m_score = 0;

    #endregion

    #region Private & Protected Members

    private Animator _playerAnimator;
    private float _xMov;
    private float _yMov;
    private Vector2 _velocity;
    private Rigidbody2D _rb;
    private bool _lookRight = true;
    private bool _isGrounded;
    private float _extraJump;

    #endregion


    #region System
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _playerAnimator = m_graphics.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _xMov = Input.GetAxis("Horizontal");
        Flip();
        ScoreUpdate();
        PlayerDeath();

        Debug.Log(m_score);
        Debug.Log(PlayerPrefs.GetInt("score"));
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(m_groundCheck.position, m_radius, m_groundLayer);

        PerformMouvement();
        PerformJump();
        _rb.velocity = _velocity;
    }

    #endregion


    #region Main Methodes

    void PerformMouvement()
    {
        _velocity = new Vector2(_xMov * _playerSpeed * Time.deltaTime, _rb.velocity.y) ;
       
        _playerAnimator.SetFloat("Run", Mathf.Abs(_xMov));

            
    }

    void PerformJump()
    {
        if(_isGrounded == true)
        {
            _extraJump = m_jumpNumber;
        }

        Debug.Log(_isGrounded);
        if (Input.GetKeyDown(KeyCode.Space) && _extraJump > 0)
        {
            _playerAnimator.SetTrigger("jumpKeyPress");
            _playerAnimator.SetFloat("JumpFall", 1f);
            _velocity = Vector2.up * _jumpForce;
            _extraJump--;
            Debug.Log("jump");
        } else if (Input.GetKeyDown(KeyCode.Space) && _extraJump == 0 && _isGrounded == true)
            {
                _playerAnimator.SetTrigger("jumpKeyPress");
                _playerAnimator.SetFloat("JumpFall", 1f);
                _velocity = Vector2.up * _jumpForce;
            }
    }
    

    void Flip()
    {
        if (_xMov < 0 && _lookRight)
        {
            Vector2 flip = transform.localScale;
            flip.x *= -1;
            transform.localScale = flip;
            _lookRight = false;
        }
        else if(_xMov >0 && !_lookRight)
        {
            Vector2 flip = transform.localScale;
            flip.x *= -1;
            transform.localScale = flip;
            _lookRight = true;
        }
    }

    void ScoreUpdate()
    {
        PlayerPrefs.SetInt("score", m_score);
    }

    void PlayerDeath()
    {
        if(gameObject.transform.position.y < -6)
        {
            gameObject.transform.position = m_Spawner.transform.position;
        }
    }

    #endregion

}
