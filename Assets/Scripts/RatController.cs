using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{
    [SerializeField] private GameObject m_toPlayerDir;

    public float m_speed = 2.0f;
    private Rigidbody m_rigidbody;

    void Start()
    {
        m_toPlayerDir = Camera.main.gameObject;
        m_rigidbody = GetComponent<Rigidbody>();
        gameObject.transform.LookAt(m_toPlayerDir.transform);
    }

    void Update()
    {
        //Vector3 forward = new Vector3(transform.forward.x, 0f, transform.forward.z).normalized;
        m_rigidbody.velocity = transform.forward * m_speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Mallet"))
        {
            // ������ �ø��� (GameManager�� ����)
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(1);
            }

            //���߿� ������Ʈ Ǯ�� ����
            Destroy(gameObject);
        }
    }
}
