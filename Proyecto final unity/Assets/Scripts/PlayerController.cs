using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public string playerName = "Nombre de jugador";
    [SerializeField] public int playerLives;
    [SerializeField] public float playerSpeed = 5.0f;
    [SerializeField] public float playerRotationSpeed = 3f;
    [SerializeField] private Vector2 characterRotation = new Vector2();
    [SerializeField] public bool sizex2 = false;
    [SerializeField] private Rigidbody rbPlayer;
    [SerializeField] private Animator animPlayer;

    // Start is called before the first frame update
    void Start()
    {
        playerName = "Nombre de jugador";
        playerLives = 3;
        Debug.Log("Game starting");
        Debug.Log(transform.position);
        rbPlayer = GetComponent<Rigidbody>();
        animPlayer.SetBool("Run",false);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(xSpeed,ySpeed,zSpeed);
        MovePlayer();
        RotatePlayer();
    }

    void ReloadOneLife()
    {
        playerLives++;
    }

    void ReloadMaxLives()
    {
        playerLives = 3;
    }

    void LostLife()
    {
        playerLives--;
    }

    void MovePlayer()
    {
        float ejeHorizontal = Input.GetAxisRaw("Horizontal");
        float ejeVertical = Input.GetAxisRaw("Vertical");
        Debug.Log(ejeHorizontal + "   " + ejeVertical);
        //rbPlayer.AddForce(playerSpeed * Time.deltaTime * new Vector3(ejeHorizontal, 0, ejeVertical),ForceMode.Impulse);

        if(Input.GetAxisRaw("Horizontal")==0 && Input.GetAxisRaw("Vertical") ==0)
        {
            animPlayer.SetBool("Run", false);
        }
        else
        {
            animPlayer.SetBool("Run", true);
                transform.Translate(playerSpeed * Time.deltaTime * new Vector3(ejeHorizontal, 0, ejeVertical));
            animPlayer.SetBool("Run", true);
        }
        
    }
    void RotatePlayer()
    {
        characterRotation.x += Input.GetAxis("Mouse X") * playerRotationSpeed;
        characterRotation.y += Input.GetAxis("Mouse Y") * playerRotationSpeed;
        Quaternion rotation = Quaternion.Euler(0, characterRotation.x, 0);
       // transform.localRotation = Quaternion.Euler(0, characterRotation.x, 0);
       rbPlayer.rotation = Quaternion.Euler(0, characterRotation.x, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {


    }
}
