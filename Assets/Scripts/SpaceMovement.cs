using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class SpaceMovement : MonoBehaviour
{
    Actions actions;
    InputAction move;
    Camera mainCamera;
    private InputAction mousePositon;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] float duration = 5;
    private void OnEnable()
    {
        mainCamera = Camera.main;
        actions.SpaceMovement.Enable();
        move=actions.SpaceMovement.MousePositon;
        actions.SpaceMovement.Click.started += Move;
    }
    private void OnDisable()
    {
        actions.SpaceMovement.Disable();
        actions.SpaceMovement.Click.started -= Move;
    }
    private void Awake()
    {
        actions=new Actions();
    }
    private void Move(InputAction.CallbackContext obj)
    {
        Debug.Log("Move");
        var (success, position) = GetMousePosition();
        if (success)
        {
            Debug.Log($@"sucess:{success}");
            // Calculate the direction
            var direction = position - transform.position;
            transform.DOMove(GetMousePosition().position, duration);
            
        }
    }
    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(move.ReadValue<Vector2>());

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
