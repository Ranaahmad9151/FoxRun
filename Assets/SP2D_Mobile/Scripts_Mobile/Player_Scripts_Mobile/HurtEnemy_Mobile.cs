using UnityEngine;
using System.Collections;
namespace Bitboys.SuperPlaftormer2D {
	
public class HurtEnemy_Mobile : MonoBehaviour {
		
	[Range(0, 10)] // slide bar.
	public int damageToGive = 5; // The damage that will cause to the enemy.
	[Range(0.0f, 25.0f)] // slide bar.
	public float bounceOnEnemy = 18f; // the amount of bounce will make when we jump over an enemy.
	private PlayerController_Mobile player;
	// Use this for initialization
	void Start () {
			player = FindObjectOfType<PlayerController_Mobile> ();
			


		}
			
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == "Enemy" && player.falling && !player.goUp || other.transform.name == "FlyingEnemies" && player.falling && !player.goUp){

				other.gameObject.GetComponent<EnemyHealthManager_Mobile>().giveDamage(damageToGive);
				transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.parent.GetComponent<Rigidbody2D>().velocity.x, bounceOnEnemy);
				
			}
		if (/*other.transform.tag == "Enemy" || */other.transform.name == "FlyingEnemies" && player.falling && !player.goUp){

				other.gameObject.GetComponent<EnemyHealthManager_Mobile>().giveDamage(damageToGive);
				transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.parent.GetComponent<Rigidbody2D>().velocity.x, bounceOnEnemy);

		}
            if (other.transform.name == "Enemy" || other.transform.tag == "Fish")
            {

                other.gameObject.GetComponent<EnemyHealthManager_Mobile>().giveDamage(damageToGive);
                transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.parent.GetComponent<Rigidbody2D>().velocity.x, bounceOnEnemy);

            }
			
        }
			

	}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////

