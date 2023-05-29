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
        // ���������, ��������� �� �������� � ���� ��������� ����
        Vector3 direction = player.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);

        if (angle < 20.0f)
        {
            // ���� �������� � ���� ���������, �� ��� �������� �������������
            if (direction.magnitude > 10.0f)
            {
                transform.Translate(0, 0, speed * Time.deltaTime);
            }

            // ��� �������������� � ������� ���������
            direction.y = 0;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotSpeed);
        }
        else
        {
            // ���� �������� �� � ���� ���������, �� ��� ����������� �����
            Vector3 patrolPoint = patrolPoints[currentPoint].position;
            direction = patrolPoint - transform.position;
            direction.y = 0;

            if (direction.magnitude < accuracy)
            {
                // ���� ��� ������ ����� ��������������, �� ��������� � ���������
                currentPoint++;

                if (currentPoint >= patrolPoints.Length)
                {
                    currentPoint = 0;
                }
            }

            // ��� �������� � ��������� ����� ��������������
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

            // ��� �������������� � ������� ��������� ����� ��������������
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
        }
    }
}
