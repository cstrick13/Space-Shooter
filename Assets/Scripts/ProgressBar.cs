using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("GameObject/UI/Linear Progress Bar")]
    public static void AddLinearProgressBar(){
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/Linear Progress Bar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }
#endif

    public SwitchSceneCounter timeProgressed;
    public Slider progress;
    public float fillAmount;
    private float startingTime;
    public Image mask;
    public Image fill;
    public Color color;
    public RectTransform handle; // Handle that moves along the bar

    void Start(){
        startingTime = Time.time;
    }

    void Update(){
        GetCurrentFill();
    }

    void GetCurrentFill(){
        fillAmount = (Time.time - startingTime) / (timeProgressed.delaySeconds * 2);
        UpdateHandlePosition(fillAmount);

        
    }

    void UpdateHandlePosition(float fillAmount){
        if (handle != null)
        {
            // Move handle along X-axis
            progress.value = fillAmount;
        }
    }
}