using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bitboys.SuperPlaftormer2D
{
    public class FirePooling : MonoBehaviour
    {
        public static FirePooling instance;
        public List<GameObject> firePool = new List<GameObject>();
        private int amountPool = 1;
        [SerializeField]
        private GameObject bulletPrefab;
        public GameObject obj;
        // Start is called before the first frame update
        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            for (int i = 0; i < amountPool; i++)
            {
                obj = Instantiate(bulletPrefab);
                obj.SetActive(false);
                firePool.Add(obj);
            }
        }
        public GameObject GetFirePool()
        {
            for (int i = 0; i < this.firePool.Count; i++)
            {
                if (!this.firePool[i].activeInHierarchy)
                {
                    return this.firePool[i];
                }
            }

            return null;
        }
        public void RemoveFirePool()
        {
            foreach(GameObject bullet in firePool)
            {
                bullet.SetActive(false);
            }
        }
    }
}