using UnityEngine;
using System.Collections;


public class TiletleUiMove : MonoBehaviour
{
	//public Transform target;
	
	void Start(){
		//iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));

		//iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(5,5,5), "time", 0.5f, "easeType", "easeInOutCubic", "loopType", "pingPong"));

		//iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(0,0,0), "time", 5f, "easeType", "linear", "loopType", "pingPong"));

		/*
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("path")
			, "time", 5f
			, "easetype", iTween.EaseType.linear
			, "looktarget", target
			, "looktime", 1f));
		*/


		iTween.MoveTo(gameObject, iTween.Hash("path", 
			iTweenPath.GetPath("title_path"), "time", 5f, "easetype", iTween.EaseType.linear, "loopType", "pingPong"));
		

		//t_path
		/*
		iTween.MoveTo(gameObject, iTween.Hash("path",
			iTweenPath.GetPath("t_path"), "time", 5f, "easetype", iTween.EaseType.linear, "loopType", "pingPong"));
		*/
	}


}

