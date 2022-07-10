using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonHelper
{
    /// <summary>
    /// (HH:)MM:SS(.CC)の形式で返します（コンマ付き、時間付き、切り上げを選べます）.
    /// </summary>
    /// <returns></returns>
    static public string BuildTimeText(float secTime, bool isRoundUp = false, bool appendComma = false, bool appendHour = false)
    {
        string timeText = "";

        int ignoreCommaTime = (isRoundUp) ?  (int)Math.Ceiling(secTime) : (int)secTime;
        // 一応負の領域に入らないように制限
        ignoreCommaTime = ( ignoreCommaTime < 0 ) ? 0 : ignoreCommaTime;

        int minite = ignoreCommaTime / 60;
        int sec = ignoreCommaTime % 60;

        if ( appendHour )
        {
            int hour = minite / 60;
            minite = minite % 60;

            timeText += string.Format("{0:D2}:", hour);
        }

        timeText += string.Format("{0:D2}:{1:D2}", minite, sec);

        if( appendComma )
        {
            int comma = 0;

            // 切り上げしてるのにコンマが出るのは...　ねぇ...?
            if ( !isRoundUp )
            {
                float commaOnlyTime = secTime - (float)(ignoreCommaTime);
                // 小数第２まで表示とします.
                comma = (int)(commaOnlyTime * 100);
            }

            timeText += string.Format(".{0:D2}", comma);
        }

        return timeText;
    }

    // st rd nd th のアレ
    static public string GetNumberOrdinal(int num)
    {
        // 0ってどうするんだ... とりあえず 20th、30thに習う形としてth
        if( num == 0 )
        {
            return "th";
        }

        // **10 といったような、2桁目が"1"の場合
        if( (num % 100) / 10 == 1 )
        {
            // 218... とかだったら　2hundled righteen になる...はず（？）
            return "th";
        }


        // ここまで来たら特例のth(?)は無い　はず.
        // ということで、下一桁を見て判断.
        switch ( num % 10 )
        {
            case 1: return "st";
            case 2: return "nd";
            case 3: return "rd";

            default: break;
        }

        // 上記switchにもかからなかったらやっぱりth
        return "th";
    }
}
