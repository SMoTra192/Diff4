using System;
using System.Collections;
using System.Collections.Generic;
using Google.Play.Review;
using UnityEngine;

public class ReviewApp : MonoBehaviour
{
    private ReviewManager _reviewManager;
    private PlayReviewInfo _playReviewInfo;
    private void Start()
    {
        _reviewManager = new ReviewManager();
        //print($"CompletedLevels_{PlayerPrefs.GetInt("CompletedLevels")}///{PlayerPrefs.GetInt("ReviewOnce")}");
        if (PlayerPrefs.GetInt("CompletedLevels") > 5 && PlayerPrefs.GetInt("ReviewOnce") == 0)
        {
            PlayerPrefs.SetInt("ReviewOnce",1);
            StartCoroutine(review());
        }
    }

    private IEnumerator review()
    {
            var requestFlowOperation = _reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
            if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
        _playReviewInfo = requestFlowOperation.GetResult();
            var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
            _playReviewInfo = null; // Reset the object
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
    }

     
    
}
