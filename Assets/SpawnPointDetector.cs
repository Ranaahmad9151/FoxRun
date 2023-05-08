using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bitboys.SuperPlaftormer2D
{
    public class SpawnPointDetector : MonoBehaviour
    {
        [SerializeField] public GameObject mushroomCheckPoint;
        private LevelManager_Mobile _levelManager;
        private CheckPointManager _checkPointManager;
        private PlayerCheckPoint _playerCheckPoint;

        // Start is called before the first frame update
        void Start()
        {
            _checkPointManager = FindObjectOfType<CheckPointManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("mushroom"))
            {
                print("Collision with: " + collision.gameObject.name);
                mushroomCheckPoint = collision.gameObject;
                _checkPointManager.respawnPoint = mushroomCheckPoint;
                //levelManager.currentCheckPoint = mushroomCheckPoint;
            }
        }
    }
}
