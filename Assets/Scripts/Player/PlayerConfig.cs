using UnityEngine;

[CreateAssetMenu(menuName = "Player/Player Configuration")]
public class PlayerConfig : ScriptableObject
{
    //[SerializeField] private AnimatorController[] animators;

    private int money;
    private int currentAnimator;

    public int Money { get => money; set => money = value; }

    /*
   public AnimatorController GetAnimator()
    {
       currentAnimator = PlayerPrefs.GetInt("CurrentSkin");

        return animators[currentAnimator];  
    }
    */
}
