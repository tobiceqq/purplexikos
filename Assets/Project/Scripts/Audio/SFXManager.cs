using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    [Header("Audio Source")]
    [SerializeField] private AudioSource sfxSource;

    [Header("Movement SFX")]
    [SerializeField] private AudioClip walkClip;
    [SerializeField] private AudioClip runClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip doubleJumpClip;
    [SerializeField] private AudioClip hyperRollClip;
    [SerializeField] private AudioClip climbClip;

    [Header("Combat SFX")]
    [SerializeField] private AudioClip enemyDamageClip;

    [Header("Volume")]
    [Range(0f, 1f)][SerializeField] private float walkVolume = 0.4f;
    [Range(0f, 1f)][SerializeField] private float runVolume = 0.5f;
    [Range(0f, 1f)][SerializeField] private float jumpVolume = 0.6f;
    [Range(0f, 1f)][SerializeField] private float doubleJumpVolume = 0.65f;
    [Range(0f, 1f)][SerializeField] private float hyperRollVolume = 0.7f;
    [Range(0f, 1f)][SerializeField] private float climbVolume = 0.45f;
    [Range(0f, 1f)][SerializeField] private float enemyDamageVolume = 0.8f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void PlayWalk()
    {
        PlaySound(walkClip, walkVolume);
    }

    public void PlayRun()
    {
        PlaySound(runClip, runVolume);
    }

    public void PlayJump()
    {
        PlaySound(jumpClip, jumpVolume);
    }

    public void PlayDoubleJump()
    {
        PlaySound(doubleJumpClip, doubleJumpVolume);
    }

    public void PlayHyperRoll()
    {
        PlaySound(hyperRollClip, hyperRollVolume);
    }

    public void PlayEnemyDamage()
    {
        PlaySound(enemyDamageClip, enemyDamageVolume);
    }

    public void PlayClimb()
    {
        PlaySound(climbClip, climbVolume);
    }

    private void PlaySound(AudioClip clip, float volume)
    {
        if (clip == null)
        {
            Debug.LogWarning("Missing SFX AudioClip on SFXManager.");
            return;
        }

        if (sfxSource == null)
        {
            Debug.LogWarning("Missing AudioSource on SFXManager.");
            return;
        }

        sfxSource.PlayOneShot(clip, volume);
    }
}