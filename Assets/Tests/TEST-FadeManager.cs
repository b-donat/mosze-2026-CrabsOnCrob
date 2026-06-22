/*
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

public class FadeManagerTests
{
    private FadeManager CreateFadeManager()
    {
        GameObject go = new GameObject("FadeManager");
        FadeManager fm = go.AddComponent<FadeManager>();

        GameObject canvas = new GameObject("Canvas");
        canvas.AddComponent<Canvas>();

        GameObject imgObj = new GameObject("FadeImage");
        imgObj.transform.SetParent(canvas.transform);

        Image img = imgObj.AddComponent<Image>();
        img.color = new Color(0, 0, 0, 0);

        fm.fadeImage = img;
        fm.fadeSpeed = 5f;

        return fm;
    }

    [UnityTest]
    public IEnumerator FadeOut_IncreasesAlpha()
    {
        var fm = CreateFadeManager();

        float start = fm.fadeImage.color.a;

        yield return fm.StartCoroutine(fm.FadeOut());

        float end = fm.fadeImage.color.a;

        Assert.Greater(end, start);
    }

    [UnityTest]
    public IEnumerator FadeIn_DecreasesAlpha()
    {
        var fm = CreateFadeManager();

        Color c = fm.fadeImage.color;
        c.a = 1f;
        fm.fadeImage.color = c;

        yield return fm.StartCoroutine(fm.FadeIn());

        Assert.Less(fm.fadeImage.color.a, 1f);
    }
}*/