using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(Rigidbody2D))] //rigidbody olmadan kod çalışmaz
public class Player : MonoBehaviour
{
    Rigidbody2D body2D; //baglantı kurma
    public float playerSpeed; //hız
    public bool isGrounded; //diger code sayfalarıyla baglantılı ancak inspecterda cıkmaz
    public float jumpPower;//birinci zıplama
    public float doublejumpPower;//ikinci zıplama
    internal bool doubleCanJump;
    bool faceingRight = true;
    Transform groundCheck; 
    const float groundCheckRadius = 0.2f; // const sayıya esitleme
    public LayerMask groundLayer;
    //player can
    internal int maxPlayerHealth = 100;
    public int currentPlayerHealth;
    internal bool isHurt;
    Damage giveDamage;
    //player can bitis
    //player olum
    internal bool isDead;
   

    void Start()
    {
        body2D = GetComponent<Rigidbody2D>(); //baglantı kurma
        body2D.gravityScale = 5; //otomatik degistirme
        body2D.freezeRotation = true ; //otamatik degistirme
        body2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous; //otamatik degistirme

        groundCheck = transform.Find("Check"); //Groundchecki bulma

        giveDamage = FindObjectOfType<Damage>();

        currentPlayerHealth = maxPlayerHealth; // oyun başı canı fulleme
}
    void Update()
    {
        ReduceHealth();
        isDead = currentPlayerHealth <= 0;
        //can alırsak max candan fazla yükselmesin
   
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        float h = Input.GetAxis("Horizontal"); //x eksene 
        float v = Input.GetAxis("Vertical"); //y ekseni

        body2D.velocity = new Vector2(h * playerSpeed, body2D.velocity.y); //wasd yon tusları ve controllerla calistirma
        //if else ile yapmaktan daha pratik ve kısa

        Flip(h);
    }
    public void Jump() //zıplama fonksiyonu
    {
        body2D.AddForce(new Vector2(0, jumpPower));

    } 
    public void DoubleJump()
    {
        body2D.AddForce(new Vector2(0, doublejumpPower), ForceMode2D.Impulse);

    } // cift zıplama fonksiyonu

    void Flip(float h)
    {
        if(h > 0 && !faceingRight || h < 0 && faceingRight)
        {
            faceingRight = !faceingRight;

            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

    } //sag sola donme fonksiyonu

    void ReduceHealth() //can azaltma fonksiyonu
    {
        if(isHurt)
        {
            currentPlayerHealth -= giveDamage.damage; //candan - zarar = yeni can
            isHurt = false;
        }

    }
    
}
