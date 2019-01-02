using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigibodyMove : MonoBehaviour {

    public  GameObject Player;
    CharacterController ck;
    public int Key;
    Rigidbody jk;
    public float Speed=0;
    float MoveX, MoveY;
    Vector3 vector3 = Vector3.zero;
    Animator animator;
	void Start () {
        ck = Player.GetComponent<CharacterController>();
        jk = Player.GetComponent<Rigidbody>();
        animator= Player.GetComponent<Animator>();
    }
	void Update () {
        switch (Key)
        {
            //case 1:
            //    Move(jk, Speed);
            //    break;
            case 2:
                Move(ck, Speed);
                break;
            //case 3:
            //    MoveA(ck, Speed);
            //    break;
        }  
    }
    //private void Move(Rigidbody Player,float Speed)
    //{
    //    MoveX = Input.GetAxis("Horizontal");
    //    MoveY = Input.GetAxis("Vertical");
    //    if (MoveX!=0||MoveY!=0)
    //    {
    //    animator.SetBool("isWork",true);
    //    Player.MovePosition(Player.position + Player.transform.forward * MoveY * Time.deltaTime * Speed);
    //    Player.MoveRotation(Player.rotation * Quaternion.Euler(Player.transform.up * MoveX * Speed));
    //    }
    //    else
    //    animator.SetBool("isWork", false);
    //}
    private void Move(CharacterController Player,float Speed)
    {
        MoveX = Input.GetAxis("Horizontal");
        MoveY = Input.GetAxis("Vertical");
        if (MoveX != 0 || MoveY != 0)
        {
            animator.SetBool("isWork", true);
            Player.transform.Rotate(Player.transform.up*MoveX*Speed);
        Player.SimpleMove(Player.transform.forward.normalized*MoveY*Speed);
        }
        else
            animator.SetBool("isWork", false);
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("Skill1");
            
        }
       
    }
    //private void MoveA(CharacterController Player, float Speed)
    //{
    //    MoveX = Input.GetAxis("Horizontal");
    //    MoveY = Input.GetAxis("Vertical");
    //    if (!Player.isGrounded)
    //    {
    //        vector3 =transform.TransformDirection( new Vector3(MoveX,0,MoveY))*Speed;
    //    }
    //    Player.Move(vector3*Time.deltaTime);
    //}
    //void MoveB(CharacterController Player, float Speed)
    //{
    //    MoveX = Input.GetAxis("Horizontal");
    //    MoveY = Input.GetAxis("Vertical");
    //    Player.SimpleMove(Quaternion.Euler(0,Camera.main.transform.position.y,0)*new Vector3(MoveX,0,MoveY)  );
    //}
}
