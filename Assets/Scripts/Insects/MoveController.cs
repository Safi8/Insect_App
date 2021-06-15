using UnityEngine;
using UnityEngine.AI;

public class MoveController : MonoBehaviour
{
    public Transform targetForFollow;
    public Transform apple;
    public GameObject targetGO;

    public float distance;
    public float untouchableDistance;
    public float radius = 1f; // Радиус

    NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (targetGO.activeInHierarchy == true)
            FollowMove(targetForFollow);
        else
            FollowMove(apple);
    }
    public void FollowLook(Transform followObject)
    {
        //transform.LookAt(targetForFollow);
        transform.LookAt(followObject);
    }
    //void FollowMove()
    //{
    //    distance = Vector3.Distance(targetForFollow.position, transform.position);

    //    // Дистанция > радиуса взаимодействия
    //    if(distance >= radius)
    //    {
    //        GetComponent<NavMeshAgent>().enabled = false;
    //        GetComponent<AnimaotrManager>().AnimeIdle();
    //    }
    //    // Дистанция в радиусе преследования
    //    //if((0.05 < distance) && (distance <= 1.5))
    //    if((distance < radius) && (targetGO.activeInHierarchy == true))
    //    {
    //        GetComponent<NavMeshAgent>().enabled = true;
    //        GetComponent<NavMeshAgent>().destination = targetForFollow.position;
    //        //navMeshAgent.SetDestination(targetForFollow.transform.position);
    //        GetComponent<AnimaotrManager>().AnimeRun();
    //        //if (distance < 0.05)
    //        //    GetComponent<NavMeshAgent>().enabled = false;
    //    }
    //    if (distance <= 0.05) // Дистанция неприкосновенности
    //    {
    //        GetComponent<NavMeshAgent>().enabled = false;
    //        FollowLook();
    //        GetComponent<AnimaotrManager>().AnimeRun();
    //    }
    //}
    void FollowMove(Transform followObject)
    {
        distance = Vector3.Distance(followObject.position, transform.position);

        // Дистанция > радиуса взаимодействия
        if (distance >= radius)
        {
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<AnimaotrManager>().AnimeIdle();
        }
        // Дистанция в радиусе преследования
        //if((0.05 < distance) && (distance <= 1.5))
        if (distance < radius)
        {
            GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<NavMeshAgent>().destination = followObject.position;
            //navMeshAgent.SetDestination(targetForFollow.transform.position);
            GetComponent<AnimaotrManager>().AnimeRun();
            //if (distance < 0.05)
            //    GetComponent<NavMeshAgent>().enabled = false;
        }
        if (distance <= 0.05) // Дистанция неприкосновенности
        {
            GetComponent<NavMeshAgent>().enabled = false;
            FollowLook(followObject);
            //RotationTowardObject();
            GetComponent<AnimaotrManager>().AnimeRun();
        }
    }
    Vector3 targetPosition;
    public void Awake()
    {
        targetPosition = this.transform.position;
    }
    void RotationTowardObject()
    {
        Vector3 rot = transform.position - targetPosition;
        transform.rotation = Quaternion.LookRotation(rot);
    }
}
