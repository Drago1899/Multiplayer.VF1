using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerController : MonoBehaviour
{
    [SerializeField] int m_speed;
    Rigidbody2D m_rb2D;
    Vector2 m_movement;
    public Animator animator;

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
        m_movement.x = Input.GetAxisRaw("Horizontal");
        m_movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", m_movement.x);
        animator.SetFloat("Vertical", m_movement.y);
        animator.SetFloat("Speed", m_movement.sqrMagnitude);

        m_rb2D.MovePosition(m_rb2D.position + m_movement * m_speed * Time.deltaTime);

    }

}

