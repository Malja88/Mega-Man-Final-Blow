using UnityEngine;
public class SFXScript : MonoBehaviour
{
    [SerializeField] public AudioSource shoot;
    [SerializeField] public AudioSource jump;
    [SerializeField] public AudioSource hurt;
    [SerializeField] public AudioSource die;
    [SerializeField] public AudioSource BossBattle;
    [SerializeField] public AudioSource enemyDie;
    [SerializeField] public AudioSource collectHP;
    [SerializeField] public AudioSource collectPowerUp;
    [SerializeField] public AudioSource superWeapon;
    [SerializeField] public AudioSource endOfRound;
    [SerializeField] public AudioSource finalBoss;
    public void PlayShoot()
    {
        shoot.Play();
    }
    public void PlayJump()
    {
        jump.Play();
    }
    public void PlayHurt()
    {
        hurt.Play();
    }
    public void PlayDie()
    {
        die.Play();
    }
    public void PlayBoss()
    {
        BossBattle.Play();
    }
    public void PlayEnemyDie()
    {
        enemyDie.Play();
    }
    public void ColletHealth()
    {
        collectHP.Play();
    }
    public void CollectPU()
    {
        collectPowerUp.Play();
    }
    public void SuperWeapon()
    {
        superWeapon.Play();
    }
    public void StageEnd()
    {
        endOfRound.Play();
    }
    public void FinalBoss()
    {
        finalBoss.Play();
    }
}