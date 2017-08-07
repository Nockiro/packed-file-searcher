
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PackedFileSearcher
{
    public static class Extensions
    {
        public static string removeInvalidPathChars(this string str)
        {
            string sanitizedFileNameChars = Path.GetInvalidFileNameChars().Aggregate(str, (current, c) => current.Replace(c.ToString(), string.Empty));
            return Path.GetInvalidPathChars().Aggregate(str, (current, c) => current.Replace(c.ToString(), string.Empty));
        }

        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
    }
}
