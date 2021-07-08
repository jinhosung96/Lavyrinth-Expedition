using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace JHS
{
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : CSV 파일을 읽어들이는 모듈  <para></para>
    /// 
    /// </summary>
    public class CSVReaderModule
    {
        #region 필드

        static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
        static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
        static char[] TRIM_CHARS = { '\"' };

        #endregion

        #region 공개 메소드

        /// <summary>
        /// 머리행을 기준으로 세로로 파일을 읽어드린다.
        /// </summary>
        /// <param name="file"> 파일 경로 </param>
        /// <returns></returns>
        public List<Dictionary<string, object>> ReadVertical(string file)
        {
            TextAsset data = Resources.Load<TextAsset>(file);

            var list = new List<Dictionary<string, object>>();

            var lines = Regex.Split(data.text, LINE_SPLIT_RE);

            if (lines.Length <= 1) return list;

            var header = Regex.Split(lines[0], SPLIT_RE);
            for (var i = 1; i < lines.Length; i++)
            {
                var values = Regex.Split(lines[i], SPLIT_RE);

                if (!values.Length.Equals(header.Length) || string.IsNullOrEmpty(values[0]) || string.IsNullOrWhiteSpace(values[0])) continue;

                var entry = new Dictionary<string, object>();
                for (var j = 0; j < header.Length && j < values.Length; j++)
                {
                    string value = values[j];
                    value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                    object finalvalue = value;
                    int n;
                    float f;
                    if (int.TryParse(value, out n))
                    {
                        finalvalue = n;
                    }
                    else if (float.TryParse(value, out f))
                    {
                        finalvalue = f;
                    }
                    entry[header[j]] = finalvalue;
                }
                list.Add(entry);
            }
            return list;
        }

        /// <summary>
        /// 머리행과 머리열을 기준으로 파일을 읽어드린다.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public Dictionary<string, Dictionary<string, object>> Read(string file)
        {
            TextAsset data = Resources.Load<TextAsset>(file);

            var dic = new Dictionary<string, Dictionary<string, object>>();

            var lines = Regex.Split(data.text, LINE_SPLIT_RE);

            if (lines.Length <= 1) return dic;

            var header = Regex.Split(lines[0], SPLIT_RE);
            for (var i = 1; i < lines.Length; i++)
            {
                var values = Regex.Split(lines[i], SPLIT_RE);

                if (!values.Length.Equals(header.Length) || string.IsNullOrEmpty(values[0]) || string.IsNullOrWhiteSpace(values[0])) continue;

                var entry = new Dictionary<string, object>();
                for (var j = 0; j < header.Length && j < values.Length; j++)
                {
                    string value = values[j];
                    value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                    object finalvalue = value;
                    int n;
                    float f;
                    if (int.TryParse(value, out n))
                    {
                        finalvalue = n;
                    }
                    else if (float.TryParse(value, out f))
                    {
                        finalvalue = f;
                    }
                    entry[header[j]] = finalvalue;

                }
                dic.Add(values[0], entry);
            }
            return dic;
        }

        #endregion
    }
}
