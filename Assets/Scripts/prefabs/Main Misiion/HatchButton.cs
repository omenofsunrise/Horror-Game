using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HatchButton : MonoBehaviour
{
    public float fireRate = 3f; // Время между выстрелами
    private float nextFireTime = 0f; 
    public GameObject cryer;
    public GameObject newTrap;
    public GameObject hatch;
    public bool keyIsFound;
    public GameObject keyPrefab;
    public GameObject fireSkull;
    public GameObject worm;
    public GameObject nightmare;
    public float spawnDistance = 5f;
    public Image fillImage; // Ссылка на изображение для заполнения
    public float fillTime = 15f; // Время заполнения в секундах
    public string playerTag = "Player"; // Тег объектов Player
    public AudioSource closedSound;

    private bool holdingF = false;
    private float holdTimer = 0f;
    private bool clicked = false;
    private bool opened = false;

    void Update()
    {
        keyIsFound = Hatch.keyFound;
        if (!clicked)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                FirstClick();
            }
        }
        else
        {
            if (!opened)
            {
                if (keyIsFound)
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        holdingF = true;
                        holdTimer = 0f;
                        StartCoroutine(FillImage());
                    }

                    if (Input.GetKeyUp(KeyCode.F))
                    {
                        holdingF = false;
                        StopCoroutine(FillImage());
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextFireTime)
                    {
                        nextFireTime = Time.time + 1f / fireRate;
                        closedSound.PlayOneShot(closedSound.clip, closedSound.volume);
                        //place sound of trying to open here
                    }
                }

            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Escape();
                }
            }
        }
    }

    void FirstClick()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnWorm();
            SpawnFireSkull();
        }
        SpawnNightmare();
        closedSound.PlayOneShot(closedSound.clip, closedSound.volume);
        clicked = true;
        GameObject[] missionObjects = GameObject.FindGameObjectsWithTag("Mission");

        // Изменить текст в компоненте TextMeshPro каждого объекта Mission
        foreach (GameObject missionObject in missionObjects)
        {
            // Получить компонент TextMeshPro
            TextMeshProUGUI textMesh = missionObject.GetComponent<TextMeshProUGUI>();

            if (textMesh != null)
            {
                // Изменить текст
                textMesh.text = "Find the key";
            }
            else { Debug.Log("asdasd"); }
        }

        SpawnObject(keyPrefab);
        SpawnObject(newTrap);
        SpawnObject(cryer);
    }

    private IEnumerator FillImage()
    {
        while (holdingF && holdTimer < fillTime)
        {
            holdTimer += Time.deltaTime;
            float fillAmount = holdTimer / fillTime;
            fillImage.fillAmount = fillAmount;
            yield return null;
        }

        if (holdingF)
        {
            // Ваш метод, который нужно выполнить после удержания кнопки F в течение fillTime секунд
            //animator
            hatch.GetComponent<Hatch>().animator.SetBool("opened", true);
            opened = true;
        }
        else
        {
            fillImage.fillAmount = 0f; // Сбрасываем заполнение изображения при отпускании кнопки F
        }
    }
    void Escape()
    {
        SceneManager.LoadScene("WonSpace");
    }

    void SpawnWorm()
    {
        // Вычисляем случайную позицию вокруг игрока
        Vector2 randomPosition = Random.insideUnitCircle.normalized * spawnDistance;
        Vector3 spawnPosition = transform.position + new Vector3(randomPosition.x, randomPosition.y, 0);

        // Создаем экземпляр врага на вычисленной позиции
        GameObject enemy = Instantiate(worm, spawnPosition, Quaternion.identity);
    }

    void SpawnNightmare()
    {
        // Вычисляем случайную позицию вокруг игрока
        Vector2 randomPosition = Random.insideUnitCircle.normalized * spawnDistance;
        Vector3 spawnPosition = transform.position + new Vector3(randomPosition.x, randomPosition.y, 0);

        // Создаем экземпляр врага на вычисленной позиции
        GameObject enemy = Instantiate(nightmare, spawnPosition, Quaternion.identity);
    }

    void SpawnFireSkull()
    {
        // Вычисляем случайную позицию вокруг игрока
        Vector2 randomPosition = Random.insideUnitCircle.normalized * spawnDistance;
        Vector3 spawnPosition = transform.position + new Vector3(randomPosition.x, randomPosition.y, 0);

        // Создаем экземпляр врага на вычисленной позиции
        GameObject enemy = Instantiate(fireSkull, spawnPosition, Quaternion.identity);
    }

    void SpawnObject(GameObject prefab)
    {
        float minX = -64;
        float maxX = 63;
        float minY = -34;
        float maxY = 36;
        float Z = -3;





        float randomX;
        float randomY;
        Vector3 spawnPos;
        randomX = Random.Range(minX, maxX);
        randomY = Random.Range(minY, maxY);
        spawnPos = new Vector3(randomX, randomY, Z);


        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}