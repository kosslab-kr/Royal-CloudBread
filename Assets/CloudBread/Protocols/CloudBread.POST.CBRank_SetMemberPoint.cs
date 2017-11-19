using UnityEngine;
using System;


namespace CloudBread
{
    public partial class CBRank_SetMemberPoint
    {
        const string _url = "api/CBRank";
        
        [Serializable]
        public struct Post
        {
            [SerializeField]
            public string sid;
            [SerializeField]
            public string point;
        }
		
        [Serializable]
        public struct Receive
        {
            [SerializeField]
            public string rank;
        }

        static public void Request(Post postData_, System.Action<Receive> callback_, System.Action<string> errorCallback_ = null)
        {
            CloudBread.Request(CloudBread.MakeFullUrl(_url), JsonUtility.ToJson(postData_), callback_, errorCallback_);
        }
    }
}