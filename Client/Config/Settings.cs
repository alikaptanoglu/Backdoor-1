namespace Client.Config
{
    internal static class Settings
    {
#if DEBUG
        internal static string IP = "127.0.0.1";
        internal static int PORT = 0x22B8;
        internal static int RECONNECT_DELAY = 0x1F4;
        internal static string NAME = "DEBUG";
#else
        internal static string IP = "ENTER IP!!!";
        internal static int PORT = 0x22B8;
        internal static int RECONNECT_DELAY = 0x1388;
        internal static string NAME = "RELEASE";
#endif
    }
}