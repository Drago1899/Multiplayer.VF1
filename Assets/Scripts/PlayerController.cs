using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int m_speed;
    Rigidbody2D m_rb2D;
    Vector2 m_movement;

    // Start is called before the first frame update
    void Start()
    {
        m_rb2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float m_movementX = Input.GetAxis("Horizontal");
        float m_movementY = Input.GetAxis("Vertical");
        m_movement = new Vector2(m_movementY, m_movementX).normalized;
    }

    private void FixedUpdate() {
        m_rb2D.MovePosition(m_rb2D.position + m_movement * m_speed * Time.deltaTime);
    }
}
