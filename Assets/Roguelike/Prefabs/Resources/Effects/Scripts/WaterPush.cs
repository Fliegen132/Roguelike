using Roguelike.Units;
using UnityEngine;

public class WaterPush : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float currentTime;

    private void Update()
    {
        if (currentTime >= maxTime)
        {
            gameObject.SetActive(false);
            currentTime = 0;
        }
        else
            currentTime += Time.deltaTime;

        // Используем метод Translate для смещения объекта по направлению его transform.forward
        transform.Translate(transform.forward * Time.deltaTime * 6, Space.World);
    }
}