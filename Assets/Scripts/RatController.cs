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

    void OnCollisionEnter(Collision collision)
    {
        // Wall 태그를 가진 오브젝트와 부딪혔을 때
        if (collision.gameObject.CompareTag("Wall"))
        {
            // 이 쥐 오브젝트를 파괴합니다.
            Destroy(gameObject);
        }
        // PlayerHand 태그를 가진 오브젝트와 부딪혔을 때 (플레이어 컨트롤러)
        else if (collision.gameObject.CompareTag("PlayerHand"))
        {
            // 점수를 올리고 (GameManager를 통해)
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(1);
            }

            //나중에 오브젝트 풀링 구현
            Destroy(gameObject);
        }
    }
}
