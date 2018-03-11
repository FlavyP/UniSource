using UnityEngine;
using System.Collections;
using Vuforia;
using UnityEngine.UI;

public class DetectTarget : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
	public GameManager sceneChanger;

    void Start () {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

    }
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (sceneChanger.CanScanTargets())
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		    {
                PlayerPrefs.SetString("Hero", gameObject.GetComponent<IEditorImageTargetBehaviour>().TrackableName);

                if (sceneChanger.battleManager != null && !sceneChanger.battleManager.isBattleFinished())
                {
                    sceneChanger.battleManager.cardScanned(gameObject.GetComponent<IEditorImageTargetBehaviour>().TrackableName);
                    sceneChanger.CanScanTargets(false);
                } else
                {
			        sceneChanger.loadLevel("World Map");
                }

            }
        }

    }
}
