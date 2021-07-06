namespace JHS
{    
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 비트마스킹 기능 확장  <para></para>
    ///
    /// </summary>
     #endregion
    public static class BitMaskExtension
    {
        #region 확장 메서드

        /// <summary>
        /// 모든 원소 삭제
        /// </summary>
        /// <param name="n"> 자기 자신 </param>
        public static void BM_Init(this ref int n) => n = 0;
        /// <summary>
        /// 모든 원소 포함
        /// </summary>
        /// <param name="n"> 자기 자신 </param>
        public static void BM_Full(this ref int n) => n = -1;
        /// <summary>
        /// 특정 원소 삭제
        /// </summary>
        /// <param name="n"> 자기 자신 </param>
        /// <param name="i"> 요소 인덱스 </param>
        public static void BM_Drop(this ref int n, int i) => n &= ~(1 << i);
        /// <summary>
        /// 특정 원소 포함
        /// </summary>
        /// <param name="n"> 자기 자신 </param>
        /// <param name="i"> 요소 인덱스 </param>
        public static void BM_Set(this ref int n, int i) => n |= (1 << i);
        /// <summary>
        /// 특정 원소 토글
        /// </summary>
        /// <param name="n"> 자기 자신 </param>
        /// <param name="i"> 요소 인덱스 </param>
        /// <returns></returns>
        public static int BM_Toggle(this ref int n, int i) => n ^= (1 << i);
        /// <summary>
        /// 특정 원소 포함 여부 확인
        /// </summary>
        /// <param name="n"> 자기 자신 </param>
        /// <param name="i"> 요소 인덱스 </param>
        /// <returns></returns>
        public static bool BM_IsSet(this ref int n, int i) => (n & (1 << i)).Equals(0) ? false : true;
        /// <summary>
        /// 마지막 원소 반환
        /// </summary>
        /// <param name="n"> 자기 자신 </param>
        /// <returns></returns>
        public static int BM_getLast(this ref int n) => n & -n;
        /// <summary>
        /// 마지막 원소 삭제
        /// </summary>
        /// <param name="n"> 자기 자신 </param>
        public static void BM_dropLast(this ref int n) => n &= (n - 1);

        public static void BM_Init(this ref long n) => n = 0;
        public static void BM_Full(this ref long n) => n = -1;
        public static void BM_Drop(this ref long n, int i) => n &= ~(1 << i);
        public static void BM_Set(this ref long n, int i) => n |= ((long)1 << i);
        public static long BM_Toggle(this ref long n, int i) => n ^= (1 << i);
        public static bool BM_IsSet(this ref long n, int i) => (n & (1 << i)).Equals(0) ? false : true;
        public static long BM_getLast(this ref long n) => n & -n;
        public static void BM_dropLast(this ref long n) => n &= (n - 1);

        #endregion
    }
}
