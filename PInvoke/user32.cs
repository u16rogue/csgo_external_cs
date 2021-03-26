using System.Runtime.InteropServices;

namespace csgo_external_cs.PInvoke
{
    public static class user32
    {
        // https://www.pinvoke.net/default.aspx/user32.getasynckeystate
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
    }
}
