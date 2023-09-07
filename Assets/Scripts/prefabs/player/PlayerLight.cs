using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    public AudioSource horror;
    public float fireRate = 1f;
    public float intensityValue = 0.1f;
    public float duration = 100f;

    private float nextFireTime = 0f;


    public void LightDamage()
    {
        Transform playerTransform = gameObject.transform;
        foreach (Transform child in playerTransform)
        {

            if (child.CompareTag("Light"))
            {
                if (Time.time >= nextFireTime)
                {
                    nextFireTime = Time.time + 1f / fireRate;
                    horror.PlayOneShot(horror.clip, 1f);
                }
                // �������� ��������� Light 2D � ������������� �������������
                UnityEngine.Rendering.Universal.Light2D light2D = child.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
                if (light2D != null)
                {

                    light2D.intensity = intensityValue;

                    //��������� ����������� ��� ������ ������������� ����� ��������� �����������������
                    StartCoroutine(ResetIntensity(light2D, duration));


                }
            }
        }
    }

    private System.Collections.IEnumerator ResetIntensity(UnityEngine.Rendering.Universal.Light2D light2D, float delay = 3f)
    {
        // ���� ��������� �����������������
        yield return new WaitForSeconds(delay);

        // ���������� ������������� ������� �� 1
        light2D.intensity = 0.6f;
    }
}