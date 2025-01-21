using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.Multiplayer.Center.Common;

[RequireComponent(typeof(SpriteRenderer))]

public class Matchable : Movable
{
    private Cursor cursor;
    private int type;

    public int Type 
    {
        get
        {
            return type;
        }
    }

    private SpriteRenderer spriteRenderer;
    
    public Vector2Int position;
    
    

    private void Awake()
    {
        cursor = Cursor.Instance;
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }

    public void SetType(int type, Sprite sprite) 
    {
        this.type = type;   
        spriteRenderer.sprite = sprite;

    }

    private void OnMouseDown()
    {
        
        cursor.SelectFirst(this);
    }

    private void OnMouseUp()
    {
        cursor.SelectFirst(null);
        
    }

    private void OnMouseEnter()
    {
        
        cursor.SelectSecond(this);
    }
    public override string ToString()
    {
        return gameObject.name;
    }
}
