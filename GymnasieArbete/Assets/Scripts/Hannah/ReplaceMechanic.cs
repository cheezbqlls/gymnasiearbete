using UnityEngine;

public class ReplaceMechanic : MonoBehaviour
{
    private bool isPickedUp = false;
    private Vector3 originalPosition;
    private string brokenPartName;
    private bool hasBeenReplaced = false;

    void Start()
    {
        originalPosition = transform.position;
        brokenPartName = "Broken" + gameObject.name.Substring(3);
    }

    void Update()
    {
        if (isPickedUp)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;

            if (Input.GetMouseButtonUp(0))
            {
                DropObject();
            }
        }
    }

    void OnMouseDown()
    {
        if (!hasBeenReplaced)
        {
            isPickedUp = true;
        }
    }

    void DropObject()
    {
        isPickedUp = false;
        Vector2 dropPosition = transform.position;
        Collider2D[] hits = Physics2D.OverlapPointAll(dropPosition);

        foreach (Collider2D hit in hits)
        {
            if (hit != null && hit.gameObject.name == brokenPartName)
            {
                Destroy(hit.gameObject);
                transform.position = hit.transform.position;
                hasBeenReplaced = true;
                return;
            }
        }

        transform.position = originalPosition;
    }
}