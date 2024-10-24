using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    public Texture2D mouseMoveOutsideTexture;
    public Texture2D mouseMoveInsideTexture;
    public Texture2D mouseNormalTexture;

    private Collider2D _objectToMove;
    private GameObject _objectToResize;

    public float maximumRadius = 4f;
    public float minimumRadius = 0.01f;

    private
    Vector2 pointerPosition;
    bool isClick;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(pointerPosition);
        RaycastHit2D rayIntersect = Physics2D.GetRayIntersection(ray);
        if (rayIntersect.collider != null)
        {
            if (rayIntersect.transform.CompareTag("CircleInside"))
            {
                Cursor.SetCursor(mouseMoveInsideTexture, new Vector2(mouseMoveInsideTexture.width / 2, mouseMoveInsideTexture.height / 2), CursorMode.Auto);
            }

            if (rayIntersect.transform.CompareTag("CircleOutside"))
            {
                _objectToResize = rayIntersect.transform.gameObject;
                Cursor.SetCursor(mouseMoveOutsideTexture, new Vector2(mouseMoveOutsideTexture.width / 2, mouseMoveOutsideTexture.height / 2), CursorMode.Auto);
            }
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }


    }

    public void OnMovePointer(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Disabled:
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Performed:
                pointerPosition = context.ReadValue<Vector2>();

                if (isClick)
                {
                    if (_objectToMove != null)
                    {
                        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(pointerPosition);
                        worldPosition.z = 0;
                        _objectToMove.transform.parent.transform.position = worldPosition;
                        _objectToResize = null;
                    }
                    if (_objectToResize != null)
                    {
                        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(pointerPosition);
                        CircleShape circleShape = _objectToResize.GetComponent<CircleShape>();
                        Vector2 centre = _objectToResize.transform.GetComponent<Renderer>().bounds.center;

                        var distance = Vector2.Distance(centre, worldPosition);
                        circleShape.Radius = Mathf.Clamp(distance, minimumRadius, maximumRadius);

                        AreaEffector2D areaEff2D = _objectToResize.GetComponent<AreaEffector2D>();
                        areaEff2D.forceMagnitude = circleShape.Radius * 50;
                        _objectToMove = null;
                    }
                }

                break;
            case InputActionPhase.Canceled:


                //Cursor.SetCursor()
                break;
            default:
                break;
        }

    }

    public void OnClick(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Disabled:
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Performed:
                isClick = true;


                Ray ray = Camera.main.ScreenPointToRay(pointerPosition);
                RaycastHit2D rayIntersect = Physics2D.GetRayIntersection(ray);

                if (rayIntersect && rayIntersect.transform)
                {
                    if (rayIntersect.transform.CompareTag("CircleInside"))
                    {
                        _objectToMove = rayIntersect.collider;
                    }
                    else if (rayIntersect.transform.CompareTag("CircleOutside"))
                    {
                        _objectToResize = rayIntersect.transform.gameObject;
                    }
                }


                break;
            case InputActionPhase.Canceled:
                isClick = false;

                _objectToMove = null;
                _objectToResize = null;
                break;
            default:
                break;
        }
    }

    //private void PointerMove()
    //{
    //    if (isClick)
    //    {
    //        if (_objectToMove != null)
    //        {
    //            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(pointerPosition);
    //            Vector2 angleVector = worldPosition - (Vector2)_objectToMove.transform.parent.transform.position;
    //            _objectToMove.transform.parent.transform.right = angleVector;
    //        }

    //        if (_objectToResize != null)
    //        {
    //            CircleShape circleShape = _objectToResize.GetComponent<CircleShape>();

    //            Vector2 centre = _objectToResize.transform.GetComponent<Renderer>().bounds.center;

    //            var distance = Vector2.Distance(centre, worldPosition);

    //            circleShape.Radius = distance;
    //            Debug.Log(centre);
    //        }
    //    }

    //}
}
