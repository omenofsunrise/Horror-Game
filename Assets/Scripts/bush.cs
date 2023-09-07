using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bush : MonoBehaviour
{
    private AudioSource audioSource;

    private float timer = 0f;
    private float interval = 1f;
    private int chance = 150;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // ���������, ������ �� ���� �������
        if (timer >= interval)
        {
            timer = 0f;

            // ���������� ��������� ����� �� 1 �� 20
            int randomValue = Random.Range(0, chance);

            // ���� ������ ����� 1, ������������� ����
            if (randomValue == 1)
            {
                PlaySound();
            }
        }
    }

    private void PlaySound()
    {
        audioSource.Play();
    }
}