using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayRaceScript : MonoBehaviour
{
    [SerializeField] private Transform[] bolls;
    [SerializeField] private Transform[] points;
    [SerializeField] private Transform childTransform;
    [SerializeField] private float speed;


    private bool bolsRun;

    private Vector3 target;
    private Transform curentBollTransform;
    private int curentBollActiv = 0;
    private int curentPoint = 0; 



    // Start is called before the first frame update
    void Start()

    {
        if (points.Length != 0)
        {
            target = points[curentPoint].position;
        }

        if (bolls.Length != 0)
        {
            curentBollTransform = bolls[curentBollActiv];
        }


    }

    // Update is called once per frame
    void Update()
    {
        //curentBollTransform.Rotate(0, 0, 1);

        curentBollTransform.position = Vector3.MoveTowards(curentBollTransform.position, target, speed * Time.deltaTime);


        if (curentBollTransform.position == target)
        {

            if (target == points[curentPoint].position)
            {
                curentBollActiv++;
                curentPoint++;

                if (curentPoint >= points.Length)
                {
                    curentPoint = 0;
                }

                if (curentBollActiv >= bolls.Length)
                {
                    curentBollActiv = 0;
                }

                Debug.Log(curentBollActiv);

                curentBollTransform = bolls[curentBollActiv];
                target = points[curentPoint].position;
                childTransform.SetParent(curentBollTransform);
            }

            


        }




    }
}
