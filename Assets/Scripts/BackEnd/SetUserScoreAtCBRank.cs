using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloudBread
{
    public class SetUserScoreAtCBRank : MonoBehaviour
    {

        private void Start()
        {
            var post_data = new CBRank_SetMemberPoint.Post();
            //post_data.sid = ;
        }

        void CBRank_SetMemberPoint_Callback(CBRank_SetMemberPoint.Receive receive_data)
        {

        }
    }
}
