using UnityEngine;

public class FirstSetup : MonoBehaviour
{
    public RectTransform cursorImage;
    public float xoffset, yoffset;

    void Start()
    {
        Application.targetFrameRate = 60;
        Cursor.visible = false; // Hide system cursor
    }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        // Offset values (tweak these as needed)
       

        // Apply offset
        cursorImage.position = mousePosition + new Vector2(xoffset, yoffset);
    }

}
