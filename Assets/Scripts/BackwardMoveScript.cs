using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackwardMoveScript : MonoBehaviour
{
    [SerializeField] private Transform targetPointOne;
    [SerializeField] private Transform targetPointTwo;
    [SerializeField] private float speed;
    [SerializeField] private bool goMuve;

    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = targetPointOne.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1);

        if (goMuve)
        {
           transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        if (transform.position == target)
        {
            if (target == targetPointOne.position)
            {
                target = targetPointTwo.position;
            } else if(target == targetPointTwo.position)
            {
                target = targetPointOne.position;
            }
        }
    }
}
