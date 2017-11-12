using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour {

    public RectTransform prefab;
    public Text countText;
    public ScrollRect scrollView;
    public RectTransform content;

    List<ExampleItemView> views = new List<ExampleItemView>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	public void UpdataItems ()
    {
        int newCount;
        int.TryParse(countText.text, out newCount);
        StartCoroutine(FetchItemModelsFromServer(newCount, results => OnReceivedNewModels(results)));
	}

    void OnReceivedNewModels(ExampleItemModel[] models)
    {
        foreach (Transform child in content)
            Destroy(child.gameObject);

        views.Clear();
        int i = 0;
        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            var  view = InitializeItemView(instance, model, i);
            views.Add(view);
            i++;
        }
    }

    ExampleItemView InitializeItemView(GameObject viewGameObject, ExampleItemModel model, int itemIndex)
    {
        ExampleItemView view = new ExampleItemView(viewGameObject.transform);

        view.ranking.text = model.ranking;
        view.playerName.text = model.playerName;
        view.playerScore.text = model.playerScore;

        return view;
    }

    IEnumerator FetchItemModelsFromServer(int count, Action<ExampleItemModel[]> onDone)
    {
        //서버 딜레이 시뮬레이팅
        yield return new WaitForSeconds(2f);

        var results = new ExampleItemModel[count];
        for (int i = 0; i  < count; i++)
        {
            results[i] = new ExampleItemModel();
            results[i].ranking = "item" + i;
            results[i].playerName = "name" + i;
            results[i].playerScore = "Score" + i;
        }

        onDone(results);
    }

    public class ExampleItemView
    {
        public Text ranking;
        public Text playerName;
        public Text playerScore;

        //public ExampleItemModel model
        //{
        //    set
        //    {
        //        if (value != null)
        //        {
        //            ranking.text = value.ranking;
        //            playerName.text = value.playerName;
        //            playerScore.text = value.playerScore;
        //        }
        //    }
        //}

        public ExampleItemView(Transform rootView)
        {
            ranking = rootView.Find("RankingText").GetComponent<Text>();
            playerName = rootView.Find("NameText").GetComponent<Text>();
            playerScore = rootView.Find("ScoreText").GetComponent<Text>();

        }
    }

    public class ExampleItemModel
    {
        public string ranking;
        public string playerName;
        public string playerScore;

    }
}
