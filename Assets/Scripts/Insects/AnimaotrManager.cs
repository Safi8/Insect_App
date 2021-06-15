using UnityEngine;

public class AnimaotrManager : MonoBehaviour
{
    //public Transform leftHand;
    //public GameObject goHand;
    //public float distance;
    //public float radius = 2f;

    //private OptionsMenuMeneger menuMeneger;
    //private void Start()
    //{
    //    menuMeneger = GetComponent<OptionsMenuMeneger>();
    //}
    //private void Update()
    //{
    //    //if (menuMeneger.isInsectAnime)
    //    //    AnimationButtonOn();
    //    //else AnimationButtonOff();
    //    AnimationButtonOn();
    //}

    //public void AnimationButtonOn()
    //{
    //    distance = Vector3.Distance(leftHand.position, transform.position);
    //    //БЕГ
    //    if (distance <= 1.5 && goHand.activeInHierarchy == true)
    //    {
    //        GetComponent<Animator>().Play("Run");
    //    }
    //    else GetComponent<Animator>().Play("Idle");
    //}
    //public void AnimationButtonOff()
    //{
    //    //GetComponent<Animator>().Play("Idle");
    //}





    public void AnimeRun()
    {
        GetComponent<Animator>().Play("Run");
    }
    public void AnimeIdle()
    {
        GetComponent<Animator>().Play("Idle");
    }
}
