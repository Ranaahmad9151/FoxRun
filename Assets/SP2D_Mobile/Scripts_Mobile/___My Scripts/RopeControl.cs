using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
namespace Bitboys.SuperPlaftormer2D
{
    public class RopeControl : MonoBehaviour
    {
        public float swingForce = 10.0f;
        public float delayBeforeSecondHang = 0.4f;

        private static Transform collidedChain;
        private static List<Transform> chains;

        private Transform playerTranfrom;
        private int chainIndex = 0;
        private Collider2D[] colliders;
        private PlayerController_Mobile pController;
        //private Animator anim;

        private bool OnRope = false;
        private float timer = 0.0f;
        private float direction;
        float dirX;
        // Start is called before the first frame update
        void Start()
        {
            playerTranfrom = transform;
            colliders = GetComponentsInChildren<Collider2D>();
            pController = GetComponent<PlayerController_Mobile>();
            //anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if(OnRope)
            {
                playerTranfrom.position = collidedChain.position;
                playerTranfrom.localRotation = Quaternion.AngleAxis(direction * 0, Vector3.forward);


                if(CrossPlatformInputManager.GetButtonDown("Jump"))
                {
                    StartCoroutine(JumpOff());
                    //pController.jumpForce = 500;
                }

                dirX = CrossPlatformInputManager.GetAxis("Horizontal");

                if(dirX>dirX&& !pController.facingRight)
                {
                    //pController.flip();
                }
                else if(dirX<0&& pController.facingRight)
                {
                    //pController.flip();
                }

                collidedChain.GetComponent<Rigidbody2D>().AddForce(Vector2.right * dirX * swingForce);
            }
        }

        IEnumerator JumpOff()
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right;
            playerTranfrom.parent = null;
            OnRope = false;
            pController.enabled = true;

            yield return new WaitForSeconds(delayBeforeSecondHang);
            if(pController.isGrounded)
            {
                //playerTranfrom.position = new Vector3(playerTranfrom.rotation.x, playerTranfrom.rotation.y, 0);
                foreach (var col in colliders)
                {
                    col.enabled = true;
                }
            }
            

        }

        IEnumerator OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag=="Rope2D")
            {
                var joint = collision.gameObject.GetComponent<HingeJoint2D>();

                if(joint&& joint.enabled)
                {
                    pController.enabled = false;

                    foreach(var col in colliders)
                    {
                        col.enabled = false;
                    }

                    var chainsParent = collision.transform.parent;
                    chains = new List<Transform>();

                    foreach(Transform child in chainsParent)
                    {
                        chains.Add(child);
                    }

                    collidedChain = collision.transform;
                    chainIndex = chains.IndexOf(collidedChain);
                    playerTranfrom.parent = collidedChain;
                    OnRope = true;

                    direction = Mathf.Sign(Vector3.Dot(-collidedChain.right, Vector3.up));


                }

            }

            return null;
        }
        private IEnumerator OnCollisionExit2D(Collision2D collision)
        {
            playerTranfrom.position = new Vector3(playerTranfrom.rotation.x, playerTranfrom.rotation.y, 0);
            return null;
        }
    }
}