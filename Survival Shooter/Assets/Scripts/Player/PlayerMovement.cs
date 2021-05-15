using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLenght = 100f;

    private void Awake()
    {
        //dapata nilai mask dari layer floor
        floorMask = LayerMask.GetMask("Floor");
        //dapat komponen animator 
        anim = GetComponent<Animator>();
        //dapat konponen rigidbody
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //dapat input horizontal (-1,0,1)
        float h = Input.GetAxisRaw("Horizontal");
        //dapat nilai input vertical (-1,0,1)
        float v = Input.GetAxisRaw("Vertical");
        Move(h,v);
        Turning();
        Animating(h,v);
    }

    //Method player dapat berhalan 
    public void Move(float h, float v)
    {
        //set nilai x dan y
        movement.Set(h, 0f, v);

        //normalisasi nilai vector agar total panjang dari vector adalah 1
        movement = movement.normalized * speed * Time.deltaTime;

        //Move to position
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        //buat ray dari posisi mouse di layar
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //buat raycast untuk floorHit
        RaycastHit floorHit;

        //lakukan raycast
        if (Physics.Raycast(camRay, out floorHit, camRayLenght, floorMask))
        {
            //Mendapatkan vector dari posisi player dan posisi floorHit
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            //Mendapatkan look rotation bar =u ke hit position
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            //Rotasi olayer
            playerRigidbody.MoveRotation(newRotation);
        }

    }

    public void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }

    public void Raise(float speedUp)
    {
        speed += speedUp;
    }
}
