using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float forwardForce =400f;
    public float sidwaysForce = 600f;
    public float jumpForce = 7.0f;
    public float speed = 0;
    public Rigidbody rigidBody;
    public LayerMask groundLayers;
    public SphereCollider col;
    public Text scoreText;
    public Text scoreTextEnd;
    public GameObject endMenu;

    private Vector3 lastPosition = Vector3.zero;
    private float score = 0.0f;

    void Start()
    {
        rigidBody.AddForce(0, 0, 400);//normal force
        col = GetComponent<SphereCollider>();
    }

    void FixedUpdate ()
    {
        rigidBody.AddForce(0, 0, forwardForce * Time.deltaTime);//time.delta time means it changes the values depending on how many frames each computer has so the script runs at the same speed for any fps amount.
        if (Input.GetMouseButton(0))//when left clicked
        {
            if (Input.mousePosition.x >Screen.width /2 && Input.mousePosition.y >Screen.height /4)//if clicked on the left side of the screen and above the bottom 1/4
                rigidBody.AddForce(sidwaysForce * Time.deltaTime, 0, 0);//player goes left
            if (Input.mousePosition.x < Screen.width / 2 && Input.mousePosition.y > Screen.height / 4)//if clicked on the right side of the screen and above the bottom 1/4
                rigidBody.AddForce(-sidwaysForce * Time.deltaTime, 0, 0);//player goes right
        }

        if (IsGrounded() && Input.mousePosition.y <Screen.height /4 && gameObject.transform.position.z > -25)//if player is on the ground and touches the bottom 1/4 of the screen
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//jump
        }
        if (IsGrounded() && Input.mousePosition.y < Screen.height / 4 && rigidBody.angularVelocity.magnitude > 4 && gameObject.transform.position.z > -25)//if player is on the ground and rotating a lot
        {//do this to make it jump around the same if rotating or not
            rigidBody.AddForce(Vector3.up * (3/2) * jumpForce, ForceMode.Impulse);//jump 50% higher than normal
        }
        score += Time.deltaTime * speed *10;//make the score go up every second
        scoreText.text = ((int)score).ToString();//display the score

        speed = (transform.position - lastPosition).magnitude;//calculates speed from how far it moves per frame
        lastPosition = transform.position;//where player was last frame

        if (speed <= 0.1 && score > 0.5 || gameObject.transform.position.y <= -1.5)//if player has stopped/hit something or has fallen off the track
        {
            gameObject.SetActive(false);

            if (PlayerPrefs.GetFloat("HighScore") < score)//if score is bigger than highscore
                PlayerPrefs.SetFloat("HighScore", score);//set highscore to new score

            endMenu.SetActive(true);//sets death menu active
            scoreTextEnd.text = ("Score: " + (int)score).ToString();//sets score text
        }
    }
    private bool IsGrounded()//if is on the floor
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);//takes the vector of the collider (player) and checks if its on the ground or not
    }
}