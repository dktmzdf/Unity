using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    //public Texture BackGround;
    public Texture2D myTexture;
    public Material MyMaterial;
    public GameObject myBack;
    public float speed;

    
    public GameObject[] prefabs;
    // Start is called before the first frame update
    void Start()
    {
        
        Color32[] col = myTexture.GetPixels32();
        
        for (int i = 0; i < myTexture.height; i++)
        { 
            for (int j = 0; j < myTexture.width; j++)
            {


                //Debug.Log();
                for (int k = 0; k < prefabs.Length; k++)
                {
                    
                    if (col[myTexture.height * i + j] ==
                        prefabs[k].transform.GetChild(0).GetComponent<MeshRenderer>().material.color)
                        Instantiate(prefabs[k], new Vector3(myTexture.height - i, myTexture.width - j, 0), Quaternion.identity);
                }
                
                    
            }
        }
        speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

       
    }
    /*
    void MoveTexture()
    {
        float offset = speed * Time.deltaTime;
        myBack.GetComponent<Renderer>().material.mainTexture = BackGround;
        myBack.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(offset,0);
        //myBack.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));

        //float scaleX = Mathf.Cos(Time.time) * 0.5f * speed;
        //float scaleY = Mathf.Sin(Time.time) * 0.5f * speed;
    }*/
}
