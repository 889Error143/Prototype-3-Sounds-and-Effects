using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float JumpForce = 10f;
    public float GravityModifier = 1f;
    public bool IsOnGround = true;
    public bool GameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private Rigidbody _playerRb;
    private Animator _playerAnim;
    private AudioSource _playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        //_playerRb.AddForce(Vector3.up * 100);
        Physics.gravity *= GravityModifier;
        _playerAnim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && !GameOver)
        {
            _playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
            _playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            _playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag
              ("Obstacle"))
            {
            GameOver = true;
            Debug.Log("Game Over!");
            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            _playerAudio.PlayOneShot(crashSound, 1.0f);
            }
        
    }
}
