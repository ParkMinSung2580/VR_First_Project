using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatRandomAnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator m_animator;

    private void OnEnable()
    {
        m_animator = GetComponent<Animator>();
    }

    private string[] m_animationNames = { "Spin", "Run", "Roll" };

    private void Start()
    {
        gameObject.GetComponent<RatRandomAnimationPlayer>().PlayRandomAnimation();
    }

    public void PlayRandomAnimation()
    {
        int index = Random.Range(0, m_animationNames.Length);
        m_animator.Play(m_animationNames[index]);
    }
}
