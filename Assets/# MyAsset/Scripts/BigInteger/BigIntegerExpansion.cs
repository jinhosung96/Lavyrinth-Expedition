using System;
using System.Numerics;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : BigInteger 기능 확장 <para></para>
    /// 
    /// </summary>
    #endregion
    public static class BigIntegerExpansion
    {
        #region 정적 메소드

        public static string GetRoughNumber(this ref BigInteger value)
        {
            int length = value.ToString().Length;
            if (length > 3)
            {
                int remainder = length % 3;
                if (remainder != 0)
                {
                    return $"{value.ToString().Substring(0, remainder)}.{value.ToString().Substring(remainder, 1)}";
                }
                else return $"{value.ToString().Substring(0, 3)}.{value.ToString().Substring(3, 1)}";
            }
            else
            {
                return value.ToString();
            }
        }

        public static string GetUnit(this ref BigInteger value)
        {
            int length = value.ToString().Length;
            if (length > 3)
            {
                int unitIndex = ((length - 1) / 3) - 1;
                char unit = 'a';
                unit = (char)(unit + unitIndex % 26);

                return new String(unit, (unitIndex / 26) + 1);
            }

            return "";
        }

        #endregion
    }
}
