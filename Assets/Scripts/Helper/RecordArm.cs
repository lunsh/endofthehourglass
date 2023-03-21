using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordArm : MonoBehaviour
{
    [SerializeField] private Animator recordAnim;

    public void moveArmOnRecord()
    {
        recordAnim.SetBool("MoveArm", true);
        recordAnim.SetBool("MoveArmBack", false);
    }

    public void moveArmBack()
    {
        recordAnim.SetBool("MoveArm", false);
        recordAnim.SetBool("MoveArmBack", true);
    }
}
