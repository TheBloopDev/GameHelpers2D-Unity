using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]

public class BoxHelper2D : MonoBehaviour
{
    public GameObject SpriteToFade;
    public LayerMask PlayerLayer;
    public float RadiusOfDetection = 5;
    private float Alpha;
    private Color Color;
    private bool detecting = false;
    private CircleCollider2D circle;
    // Start is called before the first frame update
    void Start()
    {
        circle = this.gameObject.GetComponent<CircleCollider2D>();
        circle.radius = RadiusOfDetection;
        circle.isTrigger = true;

    }

    // Update is called once per frame
    void Update()
    {
        //Mathf.Clamp(Alpha,0,1);
        Color = SpriteToFade.GetComponent<SpriteRenderer>().color;
        if(detecting){
            Alpha += 0.01f;
            SpriteToFade.GetComponent<SpriteRenderer>().color = new Color(Color.r,Color.g,Color.b,Alpha);
            if(Alpha > 0.99){
                Alpha = 1;
            }
        }

        else{
            Alpha -= 0.01f;
            
            SpriteToFade.GetComponent<SpriteRenderer>().color = new Color(Color.r,Color.g,Color.b,Alpha);
            if(Alpha < 0.01){
                Alpha = 0;
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(PlayerLayer == (PlayerLayer | (1 << collision.gameObject.layer))){
            detecting = true;
            //Color = SpriteToFade.gameObject.GetComponent<SpriteRenderer>().color;
            //SpriteToFade.gameObject.GetComponent<SpriteRenderer>().color = new Color(Color.r,Color.g,Color.b, Mathf.Lerp(SpriteToFade.gameObject.GetComponent<SpriteRenderer>().color.a, 255, TimeToFadeOver));
            print(collision.gameObject.layer);
        }
    }
    void OnTriggerExit2D(Collider2D collision){
        if(PlayerLayer == (PlayerLayer | (1 << collision.gameObject.layer))){
            detecting = false;
            //Color = SpriteToFade.gameObject.GetComponent<SpriteRenderer>().color;
            //SpriteToFade.gameObject.GetComponent<SpriteRenderer>().color = new Color(Color.r,Color.g,Color.b, Mathf.Lerp(SpriteToFade.gameObject.GetComponent<SpriteRenderer>().color.a, 255, TimeToFadeOver));
            print(collision.gameObject.layer);
        }
    }
}
    
