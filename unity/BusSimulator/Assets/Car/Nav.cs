using UnityEngine;
using System.Collections;

public class Nav : MonoBehaviour
{
	NavMeshAgent agent;
	public ObjectivesManager manager;
	//public Transform target;
	LineRenderer line;
	// Use this for initialization
	void Start ()
	{	
		line = GetComponent<LineRenderer> ();
		agent = GetComponent<NavMeshAgent> ();


	}
	
	// Update is called once per frame
	void Update ()
	{
		getpath ();
	}

	void getpath ()
	{
		line.SetPosition (0, transform.position);
		agent.SetDestination (manager.getObjectZero ().position);
		//yield WaitForEndOfFrame();
		DrawPath (agent.path);
		agent.Stop ();
	}

	void DrawPath (NavMeshPath path)
	{
		if (path.corners.Length < 2)
			return;
		line.SetVertexCount (path.corners.Length);
		for (int i = 1; i < path.corners.Length; i++) {
			line.SetPosition (i, path.corners [i]);
		}
	}
}
