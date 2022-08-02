using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpriteUp : MonoBehaviour
{
    public static float MoveSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * MoveSpriteUp.MoveSpeed *
                10 * Time.deltaTime;
    }

    public static void UpdateSpeed()
    {
        MoveSpeed += 0.00005f;
    }

    public static void ResetSpeed()
    {
        MoveSpeed = 0.05f;
    }
}