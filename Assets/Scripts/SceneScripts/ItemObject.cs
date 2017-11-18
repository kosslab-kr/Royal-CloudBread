using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{

    public RectTransform prefab;
    public Text countText;
    public ScrollRect scrollView;
    public RectTransform content;

    List<ExampleItemView> views = new List<ExampleItemView>();

    // Use this for initialization
    void Start()
    {
    }

    void Update()
    {

    }

    // Update is called once per frame
    public void UpdataItems()
    {
        int newCount = 20;
        int.TryParse(countText.text, out newCount); //InputField에서 받은 랭킹 갯수를 int로 파싱
        StartCoroutine(FetchItemModelsFromServer(newCount, results => OnReceivedNewModels(results)));
        //FetchItemModelFromServer라는 가상의 서버에서 데이터를 만들어 테스트
        //FetchItemModelsFromServer의 Action으로 생성된 results(ModelArray)를 OnReceivedNewModels=>에 전달 전달

    }


    //Model을 View에 전달
    void OnReceivedNewModels(ExampleItemModel[] models)
    {
        //기존에 Views가 있다면 클리어 처리 (새로 랭킹을 업데이트한것을 보여주기 위한 방법
        foreach (Transform child in content)
            Destroy(child.gameObject);
        //Views (ItemsList 클리어)
        views.Clear();
        int i = 0;
        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject; //prefab형태의 item을 인스탄스로 만들어 준다.
            instance.transform.SetParent(content, false);   //스크롤 뷰의 컨텐츠의 자식으로 instance를 설정
            var view = InitializeItemView(instance, model, i);   //view에 각 데이터 바인딩  각각 prefab, 데이터, 아이템 인덱스
            views.Add(view);
            i++;
        }
    }
    //View (item의 텍스트들을 생성)
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

        var results = new ExampleItemModel[count]; //Model array 생성
        for (int i = 0; i < count; i++)
        {
            results[i] = new ExampleItemModel();       //모델 데이터 생성
            results[i].ranking = "item" + i;           //임의의 데이터 할당
            results[i].playerName = "name" + i;
            results[i].playerScore = "Score" + i;
        }

        onDone(results); //results(ExampleItemMdel을 람다식의 파라메터로 전달)
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
            //
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