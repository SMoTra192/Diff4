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
        if (PlayerPrefs.GetInt("CompletedLevels") > 5 && PlayerPrefs.GetInt("ReviewOnce") == 0)
        {
            PlayerPrefs.SetInt("ReviewOnce",1);
            review();
            
        }
        //StartCoroutine(review());
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
    }

    private IEnumerator launchPreview()
    {
        var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
        _playReviewInfo = null; // Reset the object
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
// The flow has finished. The API does not indicate whether the user
// reviewed or not, or even whether the review dialog was shown. Thus, no
// matter the result, we continue our app flow.
    }
    
}
