using UnityEngine;
using System.Collections;
using gov.nasa.ksc.it.itacl.common;

public class Block : MonoBehaviour, IRequireInput, IRequireTime
{
    public IInput Input { get;  set; }
    public ITime Time { get; set; }
    public float HorizontalSpeed = 0.5f; //units per second
    public Vector2 horizontalBounds;
    public bool IsActive = false;

    private float lastMovement = 0;

	// Use this for initialization
	public void Start () 
    {
        IsActive = true;
	}
	
	// Update is called once per frame
	public void Update () 
    {
        if (Input == null || !IsActive) return;

        handleHorizontal(Input.GetAxis("Horizontal"));

        applyGravity();

	}

    private void handleHorizontal(float hor)
    {

        //move horizontal
        if (CanMove())
        {
            float dir = 0;
            if(hor > 0)
            {
                dir = 1;
            }
            else if( hor < 0)
            {
                dir = -1;
            }

            transform.Translate(transform.right * dir, Space.Self);

            lastMovement = Time.TimeSinceLevelLoaded;

        }
    }

    private void applyGravity()
    {
        
    }

    public bool CanMove()
    {
        return (Time.TimeSinceLevelLoaded - lastMovement) > HorizontalSpeed;
    }
}
