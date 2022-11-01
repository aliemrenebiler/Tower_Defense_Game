using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    private bool moveWithMouse = false;
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            moveWithMouse = !moveWithMouse;
        }

        if(moveWithMouse){
            if(Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                transform.Translate(Vector3.up * panSpeed * Time.deltaTime, Space.Self);
            }
            else if(Input.mousePosition.x <= panBorderThickness)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.Self);
            }
            else if(Input.mousePosition.y <= panBorderThickness)
            {
                transform.Translate(Vector3.down * panSpeed * Time.deltaTime, Space.Self);
            }
            else if(Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.Self);
            }
            
            if(Camera.main.orthographicSize < 50 && Input.GetAxisRaw("Mouse ScrollWheel")<0f)
            {
                Camera.main.orthographicSize -= Input.GetAxisRaw("Mouse ScrollWheel")%1 * 50 * panSpeed * Time.deltaTime;
            }
            else if(Camera.main.orthographicSize > 10 && Input.GetAxisRaw("Mouse ScrollWheel")>0f)
            {
                Camera.main.orthographicSize -= Input.GetAxisRaw("Mouse ScrollWheel")%1 * 50 * panSpeed * Time.deltaTime;
            }
        }
        else
        {
            if(Input.GetKey("w"))
            {
                transform.Translate(Vector3.up * panSpeed * Time.deltaTime, Space.Self);
            }
            else if(Input.GetKey("a"))
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.Self);
            }
            else if(Input.GetKey("s"))
            {
                transform.Translate(Vector3.down * panSpeed * Time.deltaTime, Space.Self);
            }
            else if(Input.GetKey("d"))
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.Self);
            }
            
            if(Camera.main.orthographicSize < 50 && Input.GetKey("q"))
            {
                Camera.main.orthographicSize += panSpeed * Time.deltaTime;
            }
            else if(Camera.main.orthographicSize > 10 && Input.GetKey("e"))
            {
                Camera.main.orthographicSize -= panSpeed * Time.deltaTime;
            }
        }
    }
}
