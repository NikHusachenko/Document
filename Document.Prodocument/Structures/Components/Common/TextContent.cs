﻿using Document.Prodocument.Contracts;
using Document.Prodocument.Extensions;
using Document.Prodocument.Management;

namespace Document.Prodocument.Structures.Components.Common
{
    public sealed class TextContent : ICloneable<TextContent>, IValidable, IDisplayable
    {
        private readonly DocumentSystemContext _systemContext;

        public string Content { get; private set; } = string.Empty;
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public TextMargin Margin { get; set; }

        public bool IsValid => !string.IsNullOrWhiteSpace(Content);

        private TextContent(DocumentSystemContext systemContext) 
            : this(systemContext, string.Empty, false, false) { }

        public TextContent(DocumentSystemContext systemContext, string content) 
            : this(systemContext, content, false, false) { }

        public TextContent(DocumentSystemContext systemContext, string content, bool isBold, bool isItalic)
        {
            _systemContext = systemContext;

            Content = content;
            IsBold = isBold;
            IsItalic = isItalic;
        }

        public void Write(string content)
        {
            Content = content;
            _systemContext.ChangeNotify();
        }

        public TextContent Clone(DocumentSystemContext systemContext) => new TextContent(systemContext)
        {
            Content = Content,
            Margin = Margin,
            IsBold = IsBold,
            IsItalic = IsItalic,
        };

        public void Display()
        {
            string output = Content;
            
            if (IsBold)
            {
                output.DisplayItalic();
            }

            if (IsItalic)
            {
                output.DisplayBold();
            }

            Console.WriteLine(output);
        }
    }

    public enum TextMargin
    {
        None = 1,
        Left = 2,
        Center = 3,
        Right = 4,
    }
}