using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public int rotateMultiplier;
    public float swipeSpeed;
    public float maxX;
    public float minX;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameStarted && !GameManager.Instance.GameEnded)
        {
            if (transform.rotation != Quaternion.identity)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * swipeSpeed);
            }

            if (GameManager.Instance.GameStarted && !GameManager.Instance.GameEnded)
            {
                transform.position += transform.forward * Time.deltaTime * speed;
            }

        }
    }

    public void RotateCharacter(Vector2 position)
    {
        if (!GameManager.Instance.GameEnded)
        {
              position = position.normalized;
                    Quaternion rotation = Quaternion.AngleAxis(position.x * rotateMultiplier, Vector3.up);
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 2);
        }   
      
    }


    public void InputUpdate(Vector2 delta)
    {
        if (!GameManager.Instance.GameEnded)
        {
             Vector3 newPos = transform.position + new Vector3(delta.x * swipeSpeed, 0, 0);
                    newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
                    transform.position = newPos;

        }
       

    }

}
