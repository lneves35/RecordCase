using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RecordCase.Business.Entities;
using RecordCase.Common.Exceptions;
using RecordCase.Core.Enums;
using RecordCase.Model.Entities;

namespace RecordCase.Business.FileFormatParsers
{
    public class FileFormatParserProvider
    {
        private readonly Dictionary<MediaFormatExtension, IFileFormatParser> fileFormatParserCollection = new Dictionary<MediaFormatExtension, IFileFormatParser>();

        public void Add(MediaFormatExtension mediaFormat, IFileFormatParser fileFormatParser)
        {
            fileFormatParserCollection.Add(mediaFormat, fileFormatParser);
        }

        public IFileFormatParser GetParser(string extension)
        {
            MediaFormatExtension? mediaFormat =
                Utils.GetEnumValueFromDescription<MediaFormatExtension>(extension);
            
            if (mediaFormat==null)
                throw new RecordCaseException(String.Format("Media format '{0}' not supported.", extension));

            var parser = fileFormatParserCollection[mediaFormat.Value];

            if (parser == null)
                throw new RecordCaseException(String.Format("Media format '{0}' not supported.", extension));

            return parser;
        }
    }
}
