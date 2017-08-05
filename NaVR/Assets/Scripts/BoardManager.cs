using UnityEngine;

public class BoardManager : MonoBehaviour {

    private const float TILE_SIZE = 1.0F;
    private const float TILE_OFFSET = 0.5F;
    
    private int selectionX = -1;
    private int selectionY = -1;

    private Vector3 widthLine;
    private Vector3 heightLine;

    public GameObject reticle;

    void Start ()
    {       
        widthLine = Vector3.right * 10;
        heightLine = Vector3.forward * 10;     
    }

    void Update() {
       
        Debug.Log("Reticle. X: " + selectionX + " Y: " + selectionY);
        UpdateSelection();
        DrawBoard();
	}

    private void DrawBoard()
    {
        for(int i = 0; i <= 10; i++)
        {
            Vector3 start = Vector3.right * i;
            Debug.DrawLine(start, start + heightLine);
        }

        for (int j = 0; j <= 10; j++)
        {
            Vector3 start = Vector3.forward * j;
            Debug.DrawLine(start, start + widthLine);
        }
    }

    private void UpdateSelection()
    {
        if (!Camera.main)
            return;

        RaycastHit hit;

        if(Physics.Raycast(new Ray(reticle.transform.position, reticle.transform.forward), out hit, 25f, LayerMask.GetMask("ChessBoard")))
        {
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;                 
        }
        else
        {
            selectionX = -1;
            selectionY = -1;
        }
    }
}
