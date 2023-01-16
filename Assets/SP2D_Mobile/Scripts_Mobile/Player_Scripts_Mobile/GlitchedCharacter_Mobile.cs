using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {
	
	public class GlitchedCharacter_Mobile : MonoBehaviour {

	[Range(0.0f, 1.0f)] // slide bar.
	public float maxScale = 1.0f;// This sets the maximum scale at which the glitch character comes when appearing across the vortex.
	[Range(0.0f, 1.0f)] // slide bar.
	public float minScale = 0f;// This sets the minimum scale when the character appears through the vortex. If it is zero the character appears out of nowhere.
	[Range(0.0f, 10.0f)] // slide bar.
	public float scaleSpeed = 1.5f;// the speed as the glitched character changes their size when it appears through the vortex.
	private Vector3 targetScale;// this variable creates a new vector with given  the x, y, z components.
	private LevelManager_Mobile vortex;// Here we call the vortex variable of the LevelManager Script.

	// Use this for initialization
	void Awake () {

		vortex = FindObjectOfType<LevelManager_Mobile> ();	

	}
	
	// Update is called once per frame
	void Update () {
	
				this.transform.localScale = Vector3.Lerp (transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
		
				if (vortex.openTheVortex == true) {
			
					StartCoroutine ("GlitchedPlayer");
			
				}
			}
	
		// With this feature control the time between the vortex opens, glitched character appears (changing its scale from 0 to 1), 
	public IEnumerator GlitchedPlayer()
	{

	yield return new WaitForSeconds(0.5f);
    targetScale.Set (maxScale, maxScale, maxScale);
	yield return new WaitForSeconds(1);
	this.transform.localScale = new Vector3(1, 1, 1);
}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////