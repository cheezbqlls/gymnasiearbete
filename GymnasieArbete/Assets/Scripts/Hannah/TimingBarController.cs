using UnityEngine;

public class TimingBarController : MonoBehaviour
{
    public Transform Indicator;
    public Transform greenZone;

    public float moveSpeed = 0.01f;
    private bool movingRight = true;
    private bool isStopped = false;

    void Update()
    {
        if (!isStopped)
        {
            MoveIndicator();

            if (Input.GetMouseButtonDown(0))
            {
                isStopped = true;
                CheckSuccess();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                ResetIndicator();
            }
        }
    }

    void MoveIndicator()
    {
        float moveAmount = moveSpeed * Time.deltaTime;

        if (movingRight)
        {
            Indicator.localPosition += new Vector3(moveAmount, 0, 0);
            if (Indicator.localPosition.x >= 0.5f)
                movingRight = false;
        }
        else
        {
            Indicator.localPosition -= new Vector3(moveAmount, 0, 0);
            if (Indicator.localPosition.x <= -0.5f)
                movingRight = true;
        }
    }

    void CheckSuccess()
    {
        float distance = Mathf.Abs(Indicator.position.x - greenZone.position.x);

        if (distance < 0.5f)
        {
        }
        else
        {
        }
    }

    void ResetIndicator()
    {
        Indicator.localPosition = new Vector3(-2.5f, Indicator.localPosition.y, Indicator.localPosition.z);
        isStopped = false;
        movingRight = true;
    }
}