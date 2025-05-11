using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector timelineToPlay;

    public void PlayTimeline()
    {
        if (timelineToPlay != null)
        {
            timelineToPlay.Play();
        }
    }
}
