using UnityEngine;
using System.Collections;
using Pathfinding;

public class AIMouvement : MonoBehaviour {

    public Transform target;
    public float speed = 2;
    public float nextWaypointDistance = 0.5f;
    [SerializeField] protected float repathRate = 0.2f;

    protected Seeker seeker;
    protected Transform tr;
    protected Path path = null;
    protected bool haveAPath = false;
    protected int currentWaypoint = 0;

    // Use this for initialization
    void OnStart()
    {

    }

	void OnEnable ()
    {
        seeker = GetComponent<Seeker>();

        tr = transform;

    }

    protected IEnumerator RepeatTrySearchPath()
    {
        while (true)
        {
            TrySearchPath();
            yield return new WaitForSeconds(repathRate);
        }
    }

    public void TrySearchPath()
    {
        if (target == null) throw new System.InvalidOperationException("Target is null");
        //We should search from the current position
        path = seeker.StartPath(tr.position, target.transform.position);
    }

    // Update is called once per frame
    void Update () {


        if (!haveAPath)
        {
            StartCoroutine(RepeatTrySearchPath());
            //path = seeker.StartPath(tr.position, target.transform.position);
            haveAPath = true;
        }
        if (path == null)
        {
            //We have no path to move after yet
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            Debug.Log("End Of Path Reached");
            return;
        }

        Vector3 dir = (path.vectorPath[currentWaypoint] - tr.position).normalized;
        dir *= speed * Time.deltaTime;
        tr.position = tr.position + dir;

        tr.LookAt(target);
        tr.Rotate(0,90,-90);

        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector3.Distance(tr.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }

    }
}
