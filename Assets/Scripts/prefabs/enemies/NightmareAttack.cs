using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareAttack : MonoBehaviour
{

    public float attackRange;
    public float fireRate = 1f; // Время между выстрелами
    public float proximityDistance = 2f;
    public float intensityValue = 0.1f;
    public float duration = 100f;
    public float reloadTime = 5f;

    public string playerTag = "Player";
    public string animatorBoolParameter = "attack";



    public Transform attackPoint;

    private bool isReloading = false;

    private UnityEngine.Rendering.Universal.Light2D light2D;
    private float nextFireTime = 0f;


    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // ���������, ����������� �� �����������dasd
        if (isReloading)
        {
            return;
        }

        // ������� ��� ������� � ����� "Player"
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);

        if (players.Length == 0)
        {
            transform.localScale = new Vector3(2.683957f, 2.851704f, 2.683957f);
            animator.SetBool(animatorBoolParameter, false);
            return;
        }
        if (!isReloading)
        {


            // ���������, ���������� �� ������ ��������� �����
            foreach (GameObject player in players)
            {
                float distance = Vector2.Distance(transform.position, player.transform.position);

                if (distance <= proximityDistance)
                {
                    transform.localScale = new Vector3(-2.683957f, 2.851704f, 2.683957f);

                    animator.SetBool(animatorBoolParameter, true);

                    // ��������� �����������
                    isReloading = true;
                    Invoke("FinishReload", reloadTime);

                    return;
                }
            }
        }
        // ���� �� ���� ����� �� ��������� ���������� ������
        animator.SetBool(animatorBoolParameter, false);
    }

    private void FinishReload()
    {
        // ��������� �����������
        isReloading = false;
    }

    private void Attack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, LayerMask.GetMask("Player"));

        foreach (Collider2D enemy in hitPlayers)
        {
            // ������� ��� �������� ������� � ����� "Light" � ������� "Player"
            enemy.GetComponent<PlayerLight>().LightDamage();
        }

    }

   

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
