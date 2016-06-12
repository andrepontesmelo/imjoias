using System;

namespace Tamir.SharpSsh.jsch
{
    /// <summary>
    /// Summary description for JSchException.
    /// </summary>
    public class JSchException : Exception
    {
        public JSchException(Exception e) : base(e.Message)
        {
        }

        public JSchException() : base()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public JSchException(string msg) : base(msg)
        {
        }
    }
}