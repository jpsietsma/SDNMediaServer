using System;
using System.Collections.Generic;
using System.Text;

namespace MediaClasses.Exceptions
{
    /// <summary>
    /// Invalid file type has been detected by sort scanner.
    /// </summary>
    public class InvalidFileTypeException : Exception
    {
        /// <summary>
        /// Message indicating the exception error.
        /// </summary>
        /// 
        public new string Message { get; set; }

        /// <summary>
        /// Inner exception
        /// </summary>
        public new Exception InnerException { get; set; }

        /// <summary>
        /// Exception of InvalidFileTypeException represents invalid filetype enountered by sort scanner.
        /// </summary>
        /// <param name="fileType"></param>
        public InvalidFileTypeException(string fileType)
        {
            switch (fileType)
            {
                case "pdf":
                    {
                        Message = $@"{ fileType } - Document file scanned.";
                        break;
                    }
                case "doc":
                    {
                        Message = $@"{ fileType } - Word document scanned.";
                        break;
                    }
                case "xml":
                    {
                        Message = $@"{ fileType } - Excel document scanned.";
                        break;
                    }
                case "jpg":
                    {
                        Message = $@"{ fileType } - Image image file scanned.";
                        break;
                    }
                case "jpeg":
                    {
                        Message = $@"{ fileType } - Image image file scanned.";
                        break;
                    }
                case "bmp":
                    {
                        Message = $@"{ fileType } - Image image file scanned.";
                        break;
                    }
                case "docx":
                    {
                        Message = $@"{ fileType } - Document file scanned.";
                        break;
                    }
                case "xlxs":
                    {
                        Message = $@"{ fileType } - Excel file scanned.";
                        break;
                    }
                case "nfo":
                    {
                        Message = $@"{ fileType } - Information document scanned.";
                        break;
                    }
                case "srt":
                    {
                        Message = $@"{ fileType } - Subtitle file scanned.";
                        break;
                    }
                default:
                    {
                        Message = "{ fileType } - Invalid Filetype detected by sort scanner.";
                        break;
                    }                   
            }

            new InvalidFileTypeException(Message, 1);
        }


        private InvalidFileTypeException(string message, int intern):base(message: message)
        {

        }

    }
}
