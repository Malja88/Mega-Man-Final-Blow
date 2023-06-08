using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bullet2;
    [Header("Scripts References")]
    [SerializeField] ItemsScript powerUp;
    [SerializeField] CharacterController2D controller;
    [Header("Animation")]
    [SerializeField] Animator animator;
    [Header("Transform")]
    [SerializeField] Transform firePoint;
    [Header("Sound")]
    [SerializeField] SFXScript sound;
    [Header("Variables")]
    [SerializeField] public float runSpeed;
    float horizontalMove = 0f;
    bool jump = false;
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJump", true);
            sound.PlayJump();
        }
        if (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0))
        {
            Shoot();
            sound.PlayShoot();
            animator.SetBool("isShoot", true);
            runSpeed = 0;
        }
        if (Input.GetButtonUp("Fire1") || Input.GetMouseButtonUp(0))
        {
            animator.SetBool("isShoot", false);
            runSpeed = 18;
        }
        if (Input.GetMouseButtonDown(1) || Input.GetButtonDown("Fire2") && powerUp.weaponPowerUp >= 5)
        {
                sound.SuperWeapon();
                runSpeed = 0;
                animator.SetBool("isShoot2", true);
                Shoot2();
        }
        if(Input.GetMouseButtonUp(1) || Input.GetButtonUp("Fire2"))
        {
            animator.SetBool("isShoot2", false);
            runSpeed = 18;
        }
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
    public void OnLanding()
    {
        animator.SetBool("isJump", false);
    }
    public void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
    public void Shoot2()
    {
        Instantiate(bullet2, firePoint.position, firePoint.rotation);
    }
}