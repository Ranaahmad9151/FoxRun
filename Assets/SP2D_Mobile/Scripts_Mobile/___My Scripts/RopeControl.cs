using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityStandardAssets.CrossPlatformInput;


namespace Bitboys.SuperPlaftormer2D
{
    public class RopeControl : MonoBehaviour
    {
        public float swingForce = 10.0f;
        public float delayBeforeSecondHang = 10f;

        private static Transform collidedChain;
        private static List<Transform> chains;

        private Transform playerTranfrom;
        private int chainIndex = 0;
        private Collider2D[] colliders;
        private PlayerController_Mobile pController;

        private bool OnRope = false;
        private float timer = 0.0f;
        private float direction;
        public float dirX;
        // Start is called before the first frame update
        void Start()
        {
            playerTranfrom = transform;
            colliders = GetComponentsInChildren<Collider2D>();
            pController = GetComponent<PlayerController_Mobile>();
        }

        // Update is called once per frame
        void Update()
        {
            if (OnRope)
            {
                playerTranfrom.position = collidedChain.position;
                playerTranfrom.localRotation = Quaternion.AngleAxis(direction * 0, Vector3.forward);


                if (CrossPlatformInputManager.GetButtonDown("Jump"))
                {
                    StartCoroutine(JumpOff());
                }

                dirX = CrossPlatformInputManager.GetAxis("Horizontal");

                if (dirX > 0 || !pController.facingRight)
                {
                    pController.moveVelocity = pController.moveSpeed;
                    //pController.flip();
                }
                else if (dirX < 0 || pController.facingRight)
                {
                    pController.moveVelocity = -pController.moveSpeed;
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
            if (pController.playerGraphics.localScale.x > 0)
            {
                // playerTranfrom.localPosition = new Vector3(playerTranfrom.localPosition.x + 5, playerTranfrom.localPosition.y, transform.localPosition.z);
                playerTranfrom.GetComponent<Rigidbody2D>().AddForce(transform.right * 10, ForceMode2D.Impulse);
                playerTranfrom.rotation = Quaternion.Euler(playerTranfrom.transform.rotation.x, playerTranfrom.transform.rotation.y, 0);
            }
            else
            {
                playerTranfrom.GetComponent<Rigidbody2D>().AddForce(-transform.right * 10, ForceMode2D.Impulse);
                playerTranfrom.rotation = Quaternion.Euler(playerTranfrom.transform.rotation.x, playerTranfrom.transform.rotation.y, 0);
            }
            yield return new WaitForSeconds(delayBeforeSecondHang);
            foreach (var col in colliders)
            {
                col.enabled = true;
            }
            pController.enabled = true;



        }

        IEnumerator OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Rope2D")
            {
                var joint = collision.gameObject.GetComponent<HingeJoint2D>();

                if (joint && joint.enabled)
                {
                    pController.enabled = false;

                    foreach (var col in colliders)
                    {
                        col.enabled = false;
                    }

                    var chainsParent = collision.transform.parent;
                    chains = new List<Transform>();

                    foreach (Transform child in chainsParent)
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
    }
}