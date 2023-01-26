using UnityEngine;
using UnityEngine.AI;
namespace Bitboys.SuperPlaftormer2D
{

    public class AgentMovement : MonoBehaviour
    {
        private GameObject target;
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

        }

        // Update is called once per frame
        void Update()
        {
            SetTargetPosition();
            SetAgentPosition();
        }
        void SetTargetPosition()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            target = player;
        }
        void SetAgentPosition()
        {
            agent.SetDestination(target.transform.position);
            
                if (this.transform.position.x < target.transform.position.x)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                    if(this.name=="Boss")
                    {
                        GorillaThrowRocks.instance.isMoveRight = false;
                    }
                }
                else
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    if (this.name == "Boss")
                    {
                        GorillaThrowRocks.instance.isMoveRight = true;
                    }
            }
        }
    }
}