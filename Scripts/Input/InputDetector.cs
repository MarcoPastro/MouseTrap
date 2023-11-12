using System;
using UnityEngine;

public class InputDetector : MonoBehaviour
{

    /*private Vector2 firstTouchPosition;
    private Vector2 lastTouchPosition;
    /*[SerializeField]
    private bool detectSwipeOnlyAfterRelease = true;
    [SerializeField]
    private float minDistanceFroSwipe = 0.02f;*/
    public static event Action<InputData> OnInput = delegate { };
    public GameObject centerPoint;
    [SerializeField]
    private float minDistanceForNotCenterVertical = 1.2f;
    private float minDistanceForNotCenterHorizontal = 1.2f;
    private Vector3 touchPosition;

    // Update is called once per frame
    void Update()
    {
        /*foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                firstTouchPosition = touch.position;
                lastTouchPosition = touch.position;
            }
            if (touch.phase == TouchPhase.Moved) //(!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                lastTouchPosition = touch.position;
                //DetectSwipe();
            }
            if (touch.phase == TouchPhase.Ended)
            {
                lastTouchPosition = touch.position;
                DetectSwipe();
            }
        }*/
        foreach (Touch touch in Input.touches)
        {
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            CheckPosition();
        }
    }
    private void CheckPosition()
    {
        if (TapCheckMet())
        {
            var input = InputType.Tap;
            SendInput(input);
        }
        else
        {
            if (IsVerticalTouch())
            {
                var input = centerPoint.transform.position.y - touchPosition.y > 0 ? InputType.Down : InputType.Up;
                SendInput(input);
            }
            else
            {
                var input = centerPoint.transform.position.x - touchPosition.x  < 0 ? InputType.Right : InputType.Left;
                SendInput(input);
            }
        }
    }
    private bool TapCheckMet()
    {
        bool r = false;
        if(VerticalDistance()> HorizontaltDistance())
        {
            r = VerticalDistance() < minDistanceForNotCenterVertical;
        }
        else
        {
            r = HorizontaltDistance() < minDistanceForNotCenterHorizontal;
        }
        return r;
    }
    private bool IsVerticalTouch()
    {
        return VerticalDistance() > HorizontaltDistance();
    }
    private float VerticalDistance()
    {
        return Math.Abs(centerPoint.transform.position.y - touchPosition.y);
    }
    private float HorizontaltDistance()
    {
        return Math.Abs(centerPoint.transform.position.x - touchPosition.x);
    }
    private void SendInput(InputType input)
    {
        InputData inputData = new InputData()
            {
                Input = input,
                TouchPosition = touchPosition
            };
        OnInput(inputData);
    }
        /*private void DetectSwipe()
        {

            if (TapCheckMet())//prende tutti gli input e non ne scarta
            {
                Debug.Log("Tap");
                var input = InputType.Tap;
                SendInput(input);
            }
            else
            {
                if (IsVerticalSwipe())
                {

                    var input = lastTouchPosition.y - firstTouchPosition.y > 0 ? InputType.Up : InputType.Down;
                    SendInput(input);
                }
                else
                {
                    Debug.Log("LRFT OR RIGHT");
                    var input = lastTouchPosition.x - firstTouchPosition.x > 0 ? InputType.Right : InputType.Left;
                    SendInput(input);
                }
                firstTouchPosition = lastTouchPosition;
            }
        }*/
        /*private bool TapCheckMet()
        {
            return VerticalMovementDistance() < minDistanceFroSwipe || HorizontalMovementDistance() < minDistanceFroSwipe;
        }
        private bool IsVerticalSwipe()
        {
            return VerticalMovementDistance() > HorizontalMovementDistance();
        }
        private float VerticalMovementDistance()
        {
            return Math.Abs(lastTouchPosition.y - firstTouchPosition.y);
        }
        private float HorizontalMovementDistance()
        {
            return Math.Abs(lastTouchPosition.x - firstTouchPosition.x);
        }
        private void SendInput(InputType input)
        {
            InputData inputData = new InputData()
            {
                Input = input,
                StartPosition = firstTouchPosition,
                EndPosition = lastTouchPosition
            };
            OnInput(inputData);
        }
    }
    public struct InputData
    {
        public Vector2 StartPosition;
        public Vector2 EndPosition;
        public InputType Input;
    }*/
    }
public struct InputData
{
    public Vector2 TouchPosition;
    public InputType Input;
}
public enum InputType
{
    Up,
    Down,
    Left,
    Right,
    Tap
}
