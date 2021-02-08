using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray, hiddenArray;

    // Generate a grid layout and populates the tiles with values
    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x, y] = CreateWorldText(null, gridArray[x, y].ToString(), GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, 20, Color.white, TextAnchor.MiddleCenter, TextAlignment.Center);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
        for (int count = 10; count > 0; count--)
        {
            Resource();
        }
        
    }

    // Sets the location for the high resource tile and the values for the tiles adjacent to it
    private void Resource()
    {
        int x = Random.Range(0, 32), y = Random.Range(0, 32);
        
        SetValue(x, y, 50);
        SetValue(x + 1, y, 40);
        SetValue(x - 1, y, 40);
        SetValue(x, y + 1, 40);
        SetValue(x, y - 1, 40);
        SetValue(x + 1, y + 1, 40);
        SetValue(x + 1, y - 1, 40);
        SetValue(x - 1, y + 1, 40);
        SetValue(x - 1, y - 1, 40);
        SetValue(x + 2, y, 30);
        SetValue(x + 2, y + 1, 30);
        SetValue(x + 2, y + 2, 30);
        SetValue(x, y + 2, 30);
        SetValue(x + 1, y + 2, 30);
        SetValue(x - 2, y - 2, 30);
        SetValue(x, y - 2, 30);
        SetValue(x - 1, y - 2, 30);
        SetValue(x - 1, y + 2, 30);
        SetValue(x - 2, y, 30);
        SetValue(x - 2, y - 1, 30);
        SetValue(x - 2, y + 1, 30);
        SetValue(x - 2, y + 2, 30);
        SetValue(x - 1, y - 2, 30);
        SetValue(x + 2, y - 2, 30);
        SetValue(x + 2, y - 1, 30);
        SetValue(x + 1, y - 2, 30);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    // Handles how to set a value of a tile
    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    // handles how to get values of a tile
    public int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return 0;
        }
    }

    public int GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    // Creates parameters for how text will look
    public TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        return textMesh;
    }
}