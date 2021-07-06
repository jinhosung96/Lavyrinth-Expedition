namespace JHS
{
    /// <summary>
    /// 
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 디버그 최적화  <para></para>
    ///
    /// </summary>
    public static class Debug
    {
        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public static void Log(object msg) => UnityEngine.Debug.Log($"# {msg}");

        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public static void LogError(object msg) => UnityEngine.Debug.LogError($"# {msg}");

        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public static void LogWarning(object msg) => UnityEngine.Debug.LogWarning($"# {msg}");
    }
}