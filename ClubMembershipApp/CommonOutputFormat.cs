namespace ClubMembershipApp
{
    public enum FontTheme
    {
        Default,
        Danger,
        Success
    }
    public static class CommonOutputFormat
    {
        public static void ChangeFontColor(FontTheme fontTheme)
        {
            switch (fontTheme)
            {
                case FontTheme.Default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case FontTheme.Danger:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case FontTheme.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}
