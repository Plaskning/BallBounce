using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Input inputActionMap;
    [SerializeField] Vector2 mousePos;
    [SerializeField] Camera mainCam;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color PressedColor;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnMouseDown()
    {
        spriteRenderer.color = PressedColor;
    }
    public void OnMouseUp()
    {
        spriteRenderer.color = defaultColor;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(gameObject.transform.position, mousePos);

        Gizmos.color = Color.white;
        Gizmos.DrawSphere(mousePos,3f);
    }
}
