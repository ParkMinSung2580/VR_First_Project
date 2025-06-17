using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //나중에 오브젝트 풀링에서 가져오게 하기
    [SerializeField] private GameObject m_ratPrefab; // 쥐 프리팹을 연결할 변수
    [SerializeField] private Transform[] m_spawnPoints; // 쥐가 생성될 위치들
    [SerializeField] private float m_spawnInterval = 0.1f; // 쥐 생성 간격 (초)

    [SerializeField] private float m_roomHalfSize = 23f; // 방의 반지름 25 벽때문에 -2 해주기

    private float[] m_spawnPosx;
    private float[] m_spawnPosy;

    private float m_randomPosx;
    private float m_randomPosy;

    private Vector3 m_spawnPos;

    void Start()
    {
        StartCoroutine(SpawnRatRoutine2());
    }

    //스폰포인트로 지정하여 소환
    IEnumerator SpawnRatRoutine()
    {
        while (GameManager.Instance.IsGamePlay) // 게임이 끝날 때까지 무한 반복
        {
            yield return new WaitForSeconds(m_spawnInterval);

            int spawnIndex = Random.Range(0, m_spawnPoints.Length);
            Transform selectedPoint = m_spawnPoints[spawnIndex];

            Instantiate(m_ratPrefab, selectedPoint.position, selectedPoint.rotation);
        }
    }

    //맵끝에서 랜덤으로 소환
    //매직넘버 사용 주석처리 -23 -> m_roomHalfSize
    // 25,24로 하면 벽에 붙어서 소환되서 바로 없어짐 주의
    IEnumerator SpawnRatRoutine2()
    {
        while (GameManager.Instance.IsGamePlay) // 게임이 끝날 때까지 무한 반복
        {
            yield return new WaitForSeconds(m_spawnInterval);
            int value = Random.Range(0, 5);
            switch(value)
            {
                //x -23 고정
                case 1:
                    m_spawnPos = new Vector3(-23, 0, Random.Range(-23, 23));
                    Instantiate(m_ratPrefab, m_spawnPos, Quaternion.identity);
                    break;
                //x 23 고정
                case 2:
                    m_spawnPos = new Vector3(23, 0, Random.Range(-23, 23));
                    Instantiate(m_ratPrefab, m_spawnPos, Quaternion.identity);
                    break;
                case 3:
                    m_spawnPos = new Vector3(Random.Range(-23, 23), 0, 23);
                    Instantiate(m_ratPrefab, m_spawnPos, Quaternion.identity);
                    break;
                case 4:
                    m_spawnPos = new Vector3(Random.Range(-23, 23), 0, -23);
                    Instantiate(m_ratPrefab, m_spawnPos, Quaternion.identity);
                    break;
                default:
                    Debug.Log("잘못된 Spawn 포지션");
                    break;
            }
        }
    }
}
