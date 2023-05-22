using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolAI : MonoBehaviour
{

    public List<Transform> points;     //Reference to waypoints
    public int nextID = 0;     //The int value for the next point index
    int idChangeValue = 1;     //The value of that applies to ID for changing
    public float enemySpeed = 2;     //Speed of movement

    private void Reset() // If gameobject is reset (function)
    {
        Init(); // Launch Initial hierarchy changes
    }

    void Init() // Creates the hierarchy objects for the enemy (Mainly the waypoints it moves across)
    {
        //Make box collider trigger
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<CircleCollider2D>().isTrigger = true;
        //Create Root Object
        GameObject root = new GameObject(name + "_Root");
        //Reset Poisiton of Root to enemy object
        root.transform.position = transform.position;
        //Set enemy object as child of root
        transform.SetParent(root.transform);
        //Create Waypoints object
        GameObject waypoints = new GameObject("Waypoints");
        //Reset waypoints poisiton to root
        //Make waypoints object child of root
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        //Create two points and reset their posiiton to waypoints objects
        //Make the points children of waypoint object
        GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform);p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2"); p2.transform.SetParent(waypoints.transform);p2.transform.position = root.transform.position;
        //Init points list the nadd the points to it
        points = new List<Transform>(); //list of points for enemy to traverse
        points.Add(p1.transform); // add 1st point for enemy to go to
        points.Add(p2.transform); // add 2nd point for enemy to go to
    }

    private void Update() // every frame
    {
        MoveToNextPoint(); // keep enemy moving to the next point
    }

    void MoveToNextPoint() // function for enemy to move to its next designated point
    {
        //Get the next Points transform
        Transform goalPoint = points[nextID];
        //Flip the enemy transform to look into the points direction
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-4, 4, 4);
        else
            transform.localScale = new Vector3(4, 4, 4);
        //Move the enenmy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, enemySpeed*Time.deltaTime);
        //Check the distance between enemy and goal point to trigger next point
        if(Vector2.Distance(transform.position, goalPoint.position) <0.2f)
        {
            //Check if we reach the end waypoint (make the change -1)
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            //Check if we are at the start waypoint (make the change +1)
            if (nextID == 0)
                idChangeValue = 1;
            //Apply the change on the nextID
            nextID += idChangeValue; 
        }
    } 
}
