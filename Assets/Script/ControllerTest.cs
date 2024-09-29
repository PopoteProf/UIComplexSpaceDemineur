using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerTest : MonoBehaviour
{
    

    [SerializeField] private float _xPower = 30;
    [SerializeField] private float _yPower = 100;
    [SerializeField] private float _tiltPower = 1;

    [SerializeField] private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.gyro.rotationRate);
    }

    public void Test(InputAction.CallbackContext ctx)
    {
        Debug.Log("Test");
    }

    public void Tilt(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx.ReadValue<Vector2>());
    }
    public void TiltV3(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx.ReadValue<Vector3>());

        Vector3 vec = ctx.ReadValue<Vector3>();
        vec.x = vec.x * _xPower;
        vec.y = vec.y * _yPower;
        vec.z = 0;
        _rigidbody.velocity = vec;
        _rigidbody.transform.eulerAngles = new Vector3(-90,-ctx.ReadValue<Vector3>().x * _tiltPower,0);
    }
}
