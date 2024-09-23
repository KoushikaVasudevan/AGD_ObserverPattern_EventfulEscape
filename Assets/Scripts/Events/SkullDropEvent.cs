using UnityEngine;

public class SkullDropEvent : MonoBehaviour
{
    [SerializeField] private int keysRequiredToTrigger;
    [SerializeField] private Transform skulls;
    [SerializeField] private SoundType soundToPlay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerView>() != null && GameService.Instance.GetPlayerController().KeysEquipped >= keysRequiredToTrigger)
        {
            onSkullDrop();
            GameService.Instance.GetSoundView().PlaySoundEffects(soundToPlay);
            EventService.Instance.OnSkullDrop.AddListener(onSkullDrop);
            GetComponent<Collider>().enabled = false;
        }
    }

    private void onSkullDrop()
    {
        skulls.gameObject.SetActive(true);
    }
}
