using System;
using System.Windows.Forms;

namespace CoolNameGenerator.Helper
{
    public static class Extentions
    {
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }

        }

        public static T[][] ChunkArray<T>(this T[] array, int chunkCount)
        {
            var result = new T[chunkCount][];
            var arrRemainLen = array.Length;
            var chunkFloatSize = (double)arrRemainLen / chunkCount;
            if (chunkFloatSize < 1 && chunkFloatSize > 0) chunkFloatSize = 1;
            var chunkSize = (int)Math.Round(chunkFloatSize);

            // product some arrays[] with chunkCount number
            for (int cc = 0, srcIndex = 0; cc < chunkCount; cc++, srcIndex += chunkSize, arrRemainLen -= chunkSize)
            {
                if (arrRemainLen - chunkSize < 0 || cc + 1 == chunkCount)
                {
                    chunkSize = arrRemainLen;
                }

                result[cc] = new T[chunkSize];

                if (chunkSize > 0) Array.Copy(array, srcIndex, result[cc], 0, chunkSize);
            }
            return result;
        }
    }
}
