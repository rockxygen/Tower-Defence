﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;

    public float panSpeed = 30f;
    public float panBorder = 10f;
    public float scrollSpeed = 5f;

    public float minY = 10f;
    public float maxY = 80f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }

        if (!doMovement)
        {
            return;
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorder)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorder)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorder)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorder)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        //float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 position = new Vector3(transform.position.x, 57.6f, -81.90f);
        //position.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        //position.y = Mathf.Clamp(position.y, minY, maxY);

        Debug.Log(position);

        //transform.position = new Vector3(47.7f, 57.6f, -81.90f);
        transform.position = position;
    }
}
