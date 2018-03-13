using UnityEngine;

public class Turtle{
    private GameObject turtle;

    public Turtle()
    {
        turtle = new GameObject
        {
            name = "Turtle"
        };
        turtle.transform.position = new Vector3(0, 7, 0);
    }
    
    public void MoveTurtleUP(float distance)
    {
        MoveTurtle(0,1,0, distance);
    }

    public void MoveTurtleDOWN(float distance)
    {
        MoveTurtle(0, -1, 0, distance);
    }

    public void MoveTurtleFORWARD(float distance)
    {
        MoveTurtle(0, 0, 1, distance);
    }

    public void MoveTurtleBACKWARD(float distance)
    {
        MoveTurtle(0, 0, -1, distance);
    }

    public void MoveTurtleRight(float distance)
    {
        MoveTurtle(1, 0, 0, distance);
    }

    public void MoveTurtleLeft(float distance)
    {
        MoveTurtle(-1, 0, 0, distance);
    }

    public void MoveTurtle(float x, float y, float z, float distance)
    {
        Vector3 newVector = new Vector3(x, y, z);
        turtle.transform.position += newVector * distance;
    }
    public void MoveTurtleTo(Vector3 position)
    {
        turtle.transform.position = position;
    }

	//Origin faces +Z
	//Positive and Negative
	//Faces +Z
	public void FacePositiveZ()
    {
        Quaternion rotation = Quaternion.AngleAxis(0f, Vector3.up);
        FaceTurtle(rotation);
    }

	//Faces -Z
	public void FaceNegativeZ()
    {
        Quaternion rotation = Quaternion.AngleAxis(180f, Vector3.up);
        FaceTurtle(rotation);
    }
    
	//Faces +Y
	public void FacePositiveY()
	{
		Quaternion rotation = Quaternion.AngleAxis(90f, Vector3.left);
		FaceTurtle(rotation);
	}

	//Faces -Y
	public void FaceNegativeY()
	{
		Quaternion rotation = Quaternion.AngleAxis(-90f, Vector3.left);
		FaceTurtle(rotation);
	}
	//Faces +X
	public void FacePositiveX()
	{
		Quaternion rotation = Quaternion.AngleAxis(90f, Vector3.up);
		FaceTurtle(rotation);
	}

    public void FaceTurtleTo(Vector3 direction)
    {
        Quaternion rotation = Quaternion.AngleAxis(0f, direction);
        FaceTurtle(rotation);
    }

	//Faces -X
	public void FaceNegativeX()
	{
		Quaternion rotation = Quaternion.AngleAxis(-90f, Vector3.up);
		FaceTurtle(rotation);
	}

    private void FaceTurtle(Quaternion q)
    {
        turtle.transform.rotation = q;
    }

	public Vector3 GetTurtlePosition()
	{
		 return turtle.transform.position;
	}
    public Quaternion GetTurtleRotation()
    {
        return turtle.transform.rotation;
    }
}
