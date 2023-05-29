using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour
{

    public Transform[] patrolPoints;
    public Transform player;

    private int currentPoint = 0;
    private float speed = 2.0f;
    private float accuracy = 1.0f;
    private float rotSpeed = 0.4f;

    void Update()
    {
        // Проверяем, находится ли персонаж в зоне видимости бота
        Vector3 direction = player.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);

        if (angle < 20.0f)
        {
            // Если персонаж в зоне видимости, то бот начинает преследование
            if (direction.magnitude > 10.0f)
            {
                transform.Translate(0, 0, speed * Time.deltaTime);
            }

            // Бот поворачивается в сторону персонажа
            direction.y = 0;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotSpeed);
        }
        else
        {
            // Если персонаж не в зоне видимости, то бот патрулирует точки
            Vector3 patrolPoint = patrolPoints[currentPoint].position;
            direction = patrolPoint - transform.position;
            direction.y = 0;

            if (direction.magnitude < accuracy)
            {
                // Если бот достиг точки патрулирования, то переходим к следующей
                currentPoint++;

                if (currentPoint >= patrolPoints.Length)
                {
                    currentPoint = 0;
                }
            }

            // Бот движется к следующей точке патрулирования
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

            // Бот поворачивается в сторону следующей точки патрулирования
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
        }
    }
}
