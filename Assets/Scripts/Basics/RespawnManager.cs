using System.Collections;
using UnityEngine;
public class RespawnManager : MonoBehaviour
{
    public float deathDelay = 3f;
    [SerializeField] private GameObject wastedScreen;
    [Header("Meme Sounds")]
    [SerializeField] private AudioClip birthSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioSource audioSource;
    private Vector3 respawnPoint;
    private Rigidbody2D rb;
    private PlayerMovement playerMovement;
    private CollapsingPlatform[] collapsingPlatforms;
    private WindZone[] windZones;
    private PressureButton[] pressureButtons;
    private GiantSawTrigger[] giantSawTriggers;
    private SawTeleporterLink[] sawTeleporterLinks;
    private Teleporter[] teleporters;
    private SawEnemy[] allSaws;
    private TimedPlatform[] timedPlatforms;
    private FallingObjectSpawner[] fallingSpawners;
    private PulsatingSaw[] pulsatingSaws;
    private DescendingSpike[] descendingSpikes;
    private SpikeActivator[] spikeActivators;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        respawnPoint = transform.position;
        collapsingPlatforms = FindObjectsByType<CollapsingPlatform>(FindObjectsSortMode.None);
        windZones = FindObjectsByType<WindZone>(FindObjectsSortMode.None);
        pressureButtons = FindObjectsByType<PressureButton>(FindObjectsSortMode.None);
        giantSawTriggers = FindObjectsByType<GiantSawTrigger>(FindObjectsSortMode.None);
        sawTeleporterLinks = FindObjectsByType<SawTeleporterLink>(FindObjectsSortMode.None);
        teleporters = FindObjectsByType<Teleporter>(FindObjectsSortMode.None);
        allSaws = FindObjectsByType<SawEnemy>(FindObjectsSortMode.None);
        timedPlatforms = FindObjectsByType<TimedPlatform>(FindObjectsSortMode.None);
        fallingSpawners = FindObjectsByType<FallingObjectSpawner>(FindObjectsSortMode.None);
        pulsatingSaws = FindObjectsByType<PulsatingSaw>(FindObjectsSortMode.None);
        descendingSpikes = FindObjectsByType<DescendingSpike>(FindObjectsSortMode.None);
        spikeActivators = FindObjectsByType<SpikeActivator>(FindObjectsSortMode.None);
        if (wastedScreen != null)
            wastedScreen.SetActive(false);
        if (birthSound != null && audioSource != null)
            audioSource.PlayOneShot(birthSound);
    }
    public void SetCheckpoint(Vector3 newPoint)
    {
        respawnPoint = newPoint;
    }
    public void Respawn()
    {
        StartCoroutine(DeathSequence());
    }
    private IEnumerator DeathSequence()
    {
        playerMovement.Die();
        foreach (var spike in descendingSpikes)
            spike.ResetSpike();
        if (deathSound != null && audioSource != null)
            audioSource.PlayOneShot(deathSound);
        if (wastedScreen != null)
            wastedScreen.SetActive(true);
        yield return new WaitForSeconds(deathDelay);
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        transform.position = new Vector3(respawnPoint.x, respawnPoint.y, 0);
        yield return null;
        rb.simulated = true;
        if (wastedScreen != null)
            wastedScreen.SetActive(false);
        foreach (var platform in collapsingPlatforms)
            platform.Reset();
        foreach (var zone in windZones)
            zone.ResetZone();
        foreach (var button in pressureButtons)
            button.ResetButton();
        foreach (var trigger in giantSawTriggers)
            trigger.ResetTrigger();
        foreach (var link in sawTeleporterLinks)
            link.ResetLink();
        foreach (var tp in teleporters)
            tp.ResetTeleporter();
        foreach (var saw in allSaws)
            saw.ResetSaw();
        foreach (var tp in timedPlatforms)
            tp.ResetPlatform();
        foreach (var spawner in fallingSpawners)
            spawner.ResetSpawner();
        foreach (var ps in pulsatingSaws)
            ps.ResetSaw();
        foreach (var sa in spikeActivators)
            sa.ResetActivator();
        playerMovement.Revive();
        foreach (var spike in descendingSpikes)
            spike.Activate();
    }
    public void RespawnNoScreen()
    {
        StartCoroutine(DeathSequenceNoScreen());
    }
    private IEnumerator DeathSequenceNoScreen()
    {
        playerMovement.Die();
        foreach (var spike in descendingSpikes)
            spike.ResetSpike();
        yield return new WaitForSeconds(deathDelay);
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        transform.position = new Vector3(respawnPoint.x, respawnPoint.y, 0);
        yield return null;
        rb.simulated = true;
        foreach (var platform in collapsingPlatforms)
            platform.Reset();
        foreach (var zone in windZones)
            zone.ResetZone();
        foreach (var button in pressureButtons)
            button.ResetButton();
        foreach (var trigger in giantSawTriggers)
            trigger.ResetTrigger();
        foreach (var link in sawTeleporterLinks)
            link.ResetLink();
        foreach (var tp in teleporters)
            tp.ResetTeleporter();
        foreach (var saw in allSaws)
            saw.ResetSaw();
        foreach (var tp in timedPlatforms)
            tp.ResetPlatform();
        foreach (var spawner in fallingSpawners)
            spawner.ResetSpawner();
        foreach (var ps in pulsatingSaws)
            ps.ResetSaw();
        foreach (var sa in spikeActivators)
            sa.ResetActivator();
        playerMovement.Revive();
        foreach (var spike in descendingSpikes)
            spike.Activate();
    }
}