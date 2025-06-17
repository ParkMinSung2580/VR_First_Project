using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //���߿� ������Ʈ Ǯ������ �������� �ϱ�
    [SerializeField] private GameObject m_ratPrefab; // �� �������� ������ ����
    [SerializeField] private Transform[] m_spawnPoints; // �㰡 ������ ��ġ��
    [SerializeField] private float m_spawnInterval = 0.1f; // �� ���� ���� (��)

    [SerializeField] private float m_roomHalfSize = 23f; // ���� ������ 25 �������� -2 ���ֱ�

    private float[] m_spawnPosx;
    private float[] m_spawnPosy;

    private float m_randomPosx;
    private float m_randomPosy;

    private Vector3 m_spawnPos;

    void Start()
    {
        StartCoroutine(SpawnRatRoutine2());
    }

    //��������Ʈ�� �����Ͽ� ��ȯ
    IEnumerator SpawnRatRoutine()
    {
        while (GameManager.Instance.IsGamePlay) // ������ ���� ������ ���� �ݺ�
        {
            yield return new WaitForSeconds(m_spawnInterval);

            int spawnIndex = Random.Range(0, m_spawnPoints.Length);
            Transform selectedPoint = m_spawnPoints[spawnIndex];

            Instantiate(m_ratPrefab, selectedPoint.position, selectedPoint.rotation);
        }
    }

    //�ʳ����� �������� ��ȯ
    //�����ѹ� ��� �ּ�ó�� -23 -> m_roomHalfSize
    // 25,24�� �ϸ� ���� �پ ��ȯ�Ǽ� �ٷ� ������ ����
    IEnumerator SpawnRatRoutine2()
    {
        while (GameManager.Instance.IsGamePlay) // ������ ���� ������ ���� �ݺ�
        {
            yield return new WaitForSeconds(m_spawnInterval);
            int value = Random.Range(0, 5);
            switch(value)
            {
                //x -23 ����
                case 1:
                    m_spawnPos = new Vector3(-23, 0, Random.Range(-23, 23));
                    Instantiate(m_ratPrefab, m_spawnPos, Quaternion.identity);
                    break;
                //x 23 ����
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
                    Debug.Log("�߸��� Spawn ������");
                    break;
            }
        }
    }
}
