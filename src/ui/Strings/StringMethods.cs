using System;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Imaging.Interop;

namespace StartPagePlus.UI.Strings
{
    public static class StringMethods
    {
        public static ImageMoniker ExtensionToMoniker(string value)
        {
            if (value is null)
            {
                throw new ArgumentOutOfRangeException("Value can't be null");
            }

            var ext = value.ToString().TrimStart(new char[] { '.' });

            switch (ext)
            {
                case "sln":
                    return KnownMonikers.Solution;

                case "csproj":
                    return KnownMonikers.CSProjectNode;

                case "":
                    return KnownMonikers.FolderOpened;

                default:
                    return KnownMonikers.ExclamationPoint;
            }
        }
    }
}