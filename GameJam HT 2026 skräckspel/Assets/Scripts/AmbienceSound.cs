using UnityEngine;

public class AmbienceSound : MonoBehaviour
{
    public Collider Area; //The area of sound 
    public GameObject Player; //The object to follow player 

    // Update is called once per frame
    void Update()
    {
        //Locate closet point on the collider to the player
        Vector3 closetPoint = Area.ClosestPoint(Player.transform.position);
        //Set position to closet point to the player
        transform.position = closetPoint; 
    }
}
