using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private float rotationSpeed;
    private float scaleSpeed = 0.001f;
    private float colorTimer;
    private bool growCube = false;
    private int rotationNumber;

    void Start()
    {
        // start at a random size - shrink if starting large, grow if starting small
        float startSize = Random.Range(1.0f, 5.0f);
        if (startSize < 2.5f)
        {
            growCube = true;
        }

        transform.position = new Vector3(3, 5, 1);
        transform.localScale = Vector3.one * startSize;

        // randomize number of axis to rotate on and rotation speed
        rotationNumber = Random.Range(1, 4);
        rotationSpeed = Random.Range(10.0f, 25.0f);
        // randomize a starting color
        RandomizeColor();
    }

    void Update()
    {
        // grow or shrink cube according to current variable setting
        if (growCube)
        {
            transform.localScale *= (1 + scaleSpeed * Time.deltaTime);
        }
        else if (growCube == false)
        {
            transform.localScale *= (1 - scaleSpeed * Time.deltaTime);
        }

        // if cube gets too small or large, switch the growCube variable
        if (transform.localScale.x < 0.5f)
        {
            growCube = true;
        }
        if (transform.localScale.x > 10.0f)
        {
            growCube = false;
        }

        // rotate on 1, 2, or 3 axis and increase the rotation speed over time
        if (rotationNumber == 1)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
        else if (rotationNumber == 2)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, 0.0f);
        }
        else if (rotationNumber == 3)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime);
        }
        rotationSpeed += 0.1f;

        // if the rotation speed hits 500, reset it to 10
        if (rotationSpeed > 500.0f)
        {
            rotationSpeed = 10.0f;
        }

        // randomize the color every 3 seconds, using the colorTimer variable to track the time
        if (colorTimer > 3)
        {
            RandomizeColor();
            colorTimer = 0;
        }
        colorTimer += Time.deltaTime;
    }

    void RandomizeColor()
    {
        // randomize a value for each r, g, b, and a
        float colorR = Random.Range(0.0f, 1.0f);
        float colorB = Random.Range(0.0f, 1.0f);
        float colorG = Random.Range(0.0f, 1.0f);
        float colorA = Random.Range(0.0f, 1.0f);

        // set color of cube to the newly randomized values
        Material material = Renderer.material;
        material.color = new Color(colorR, colorB, colorG, colorA);
    }

}