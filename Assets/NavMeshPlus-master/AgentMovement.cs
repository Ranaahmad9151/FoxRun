using UnityEngine;
using UnityEngine.AI;
public class AgentMovement : MonoBehaviour
{
    private Vector3 target;
    private GameObject player;
    NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        //target = new Vector3(target.x, target.y, 0);
       // player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetPosition();
        SetAgentPosition();
    }
    void SetTargetPosition()
    {
        player =GameObject.FindGameObjectWithTag("Player");
        target = player.transform.position;
        /*if(Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }*/
    }
    void SetAgentPosition()
    {
        //agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
        agent.SetDestination(target);
        /*var angle = Mathf.Atan2(target.x, target.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
    }
}
