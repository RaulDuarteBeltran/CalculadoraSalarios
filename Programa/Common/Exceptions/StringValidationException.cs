using System;
using System.Runtime.Serialization;

namespace Common.Exceptions
{
    [Serializable]
    public class StringValidationException : ApplicationException
    {
        public int LineIndex { get; set; } = 0;
        public int CharacterIndex { get; set; } = 0;
        public string InvalidText { get; set; } = string.Empty;

        public StringValidationException(){ }
        public StringValidationException(int lineIndex, int characterIndex, string invalidText, string message)
            :this(lineIndex, characterIndex, invalidText, message, null) { }
        public StringValidationException(int lineIndex, int characterIndex, string invalidText, string message, Exception inner)
            :base(message, inner)
        {
            LineIndex = lineIndex;
            CharacterIndex = characterIndex;
            InvalidText = invalidText;
        }

        protected StringValidationException(int lineIndex, int characterIndex, string invalidText,
            SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            LineIndex = lineIndex;
            CharacterIndex = characterIndex;
            InvalidText = invalidText;
        }
    }
}
