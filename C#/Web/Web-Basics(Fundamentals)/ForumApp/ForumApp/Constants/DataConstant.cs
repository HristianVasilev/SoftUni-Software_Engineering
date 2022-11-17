namespace ForumApp.Constants
{
    public static class DataConstant
    {
        /// <summary>
        /// Post constants
        /// </summary>
        public static class Post
        {
            /// <summary>
            /// Min title length
            /// </summary>
            public const int TitleMinLength = 10;

            /// <summary>
            /// Max title length
            /// </summary>
            public const int TitleMaxLength = 50;

            /// <summary>
            /// Min content length
            /// </summary>
            public const int ContentMinLength = 30;

            /// <summary>
            /// Max content length
            /// </summary>
            public const int ContentMaxLength = 1500;

            /// <summary>
            /// Error messages for Posts
            /// </summary>
            public static class ErrorMessage
            {
                public const string FieldLength = "{0} must be a string between {2} and {1} characters.";
                public const string FieldRequired = "{0} is required!";
            }
        }
    }
}
