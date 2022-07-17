using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackwardMoveScript : MonoBehaviour
{
  
    [SerializeField] private Transform[] targetPoint;
    [SerializeField] private float speed;
    [SerializeField] private bool goMuve;

    private Vector3 target;
    private int curentNumberPoint;
    private bool forward = true; //� �������� true ��� �������� �� �������� ����� �� 0 �� N. � �������� false � �� �������� �������� �� N �� 0.

    void Start()
    {
        if (targetPoint.Length != 0)
        {
            target = targetPoint[curentNumberPoint].position;
        }

        checkMuve();


    }

    void Update()
    {
        transform.Rotate(0, 0, 1);

        if (goMuve)
        {
           transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        if (transform.position == target)
        {

            Debug.Log("�������� ����� ����������");

            if (target == targetPoint[curentNumberPoint].position)
            {
                Debug.Log("����� ���������� �������� ");

                if (forward)
                {
                    curentNumberPoint++;
                } else
                {
                    curentNumberPoint--;
                }
                Debug.Log(curentNumberPoint);

                if (curentNumberPoint >= targetPoint.Length)
                {
                    curentNumberPoint = targetPoint.Length - 1;
                    Debug.Log(curentNumberPoint);
                    forward = false;
                }
                else if (curentNumberPoint < 0)
                {
                    curentNumberPoint = 0;
                    Debug.Log(curentNumberPoint);

                    forward = true;
                }

                target = targetPoint[curentNumberPoint].position;
            }

        }
       
    }

    private void checkMuve()
    {
         if (forward)
            {
                curentNumberPoint = 0;
            } else
            {
                curentNumberPoint = targetPoint.Length - 1;
            }
    }

}
