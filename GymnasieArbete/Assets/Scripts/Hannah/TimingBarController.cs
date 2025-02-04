using UnityEngine;

public class TimingBarController : MonoBehaviour
{
    public Transform Indicator;
    public Transform greenZone; 

    public float moveSpeed = 0.05f;
    private bool movingRight = true;

    void Update()
    {
        MoveIndicator();

        if (Input.GetMouseButtonDown(0)) 
        {
            CheckSuccess();
        }
    }

    void MoveIndicator()
    {
        float moveAmount = moveSpeed * Time.deltaTime;
        if (movingRight)
        {
            Indicator.localPosition += new Vector3(moveAmount, 0, 0);
            if (Indicator.localPosition.x >= 0.5)
                movingRight = false;
        }
        else
        {
            Indicator.localPosition -= new Vector3(moveAmount, 0, 0);
            if (Indicator.localPosition.x <= -0.5)
                movingRight = true;
        }
    }

    void CheckSuccess()
    {
        float distance = Mathf.Abs(Indicator.position.x - greenZone.position.x);
        if (distance < 0.5f);
    }
}