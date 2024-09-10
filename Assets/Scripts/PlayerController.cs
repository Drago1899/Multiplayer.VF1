using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SocialPlatforms.Impl;


public class PlayerController : MonoBehaviour
{
    [SerializeField] int m_speed;
    Rigidbody2D m_rb2D;
    Vector2 m_movement;
    public Animator animator;
    [SerializeField] public int Score;

    PhotonView m_pV;

    // Start is called before the first frame update
    void Start()
    {
        m_pV = GetComponent<PhotonView>();
        m_rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (m_pV.IsMine)
        {
            m_movement.x = Input.GetAxisRaw("Horizontal");
            m_movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", m_movement.x);
            animator.SetFloat("Vertical", m_movement.y);
            animator.SetFloat("Vel", m_movement.sqrMagnitude);

            m_rb2D.MovePosition(m_rb2D.position + m_movement * m_speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Diamante"))
        {
            Score++;
            Destroy(collision.gameObject);

        }
        
    }


}

