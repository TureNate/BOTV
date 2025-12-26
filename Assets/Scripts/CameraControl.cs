using UnityEngine;


public class CameraControl : MonoBehaviour
{
    [SerializeField] private Camera Camera;
    [SerializeField] private float cameraspeed = 5f;
    [SerializeField] private float cameraScrollSpeed = 12f;

    private Vector3 Origin;
    private Vector3 Difference;

    private bool drag = false;

    void Start()
    {

    }

    // Update is called once per frame
        //Премещение камеры курсором у конца экрана
      
             

    private void LateUpdate()
    {
        if (Input.mousePosition.x < Screen.width / 15 && !Input.GetMouseButton(3))
        {
            transform.position = new Vector3(transform.position.x - cameraspeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (Input.mousePosition.y < Screen.height / 15 && !Input.GetMouseButton(3))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - cameraspeed * Time.deltaTime, transform.position.z);
        }
        if (Input.mousePosition.x > Screen.width - Screen.width / 15 && !Input.GetMouseButton(3))
        {
            transform.position = new Vector3(transform.position.x + cameraspeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (Input.mousePosition.y > Screen.height - Screen.height / 15 && !Input.GetMouseButton(3))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + cameraspeed * Time.deltaTime, transform.position.z);
        }
        //Перемещение камеры колесом мышы
        {
            //Удаление камеры
            if (Input.mouseScrollDelta.y > 0 && Camera.GetComponent<Camera>().orthographicSize < 65)
            {
                Camera.GetComponent<Camera>().orthographicSize += cameraScrollSpeed * Time.deltaTime;
            }
            //Приближение камеры
            else if (Input.mouseScrollDelta.y < 0 && Camera.GetComponent<Camera>().orthographicSize > 5)
            {
                Camera.GetComponent<Camera>().orthographicSize -= cameraScrollSpeed * Time.deltaTime;
            }
        }

        if (Input.GetMouseButton(3))
        {
            Difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (drag == false)
            {
                drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }

            if(drag)
            {
                Camera.main.transform.position = Origin - Difference; 
            }
        }
    }

