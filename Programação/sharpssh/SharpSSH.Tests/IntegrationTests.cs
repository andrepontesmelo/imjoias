using System.Configuration;
using System.IO;
using System.Linq;
using Tamir.SharpSsh.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tamir.SharpSsh;

namespace SharpSSH.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        string host = ConfigurationManager.AppSettings["SSH_Host"];
        string user = ConfigurationManager.AppSettings["SSH_User"];
        string pass = ConfigurationManager.AppSettings["SSH_Pass"];
        string path = ConfigurationManager.AppSettings["SSH_Path"];

        [TestMethod]
        //[Ignore]
        public void TestListFiles()
        {
            var ssh = new SFTPUtil(host, user, pass);

            var list = ssh.ListFiles("/var");

            Assert.IsTrue(list.Any());
        }

        [TestMethod]
        //[Ignore]
        public void TestSSHExec()
        {
            var ssh = new SshExec(host, user, pass);

            ssh.Connect();

            string s = ssh.RunCommand("pwd");

            Assert.IsFalse(string.IsNullOrWhiteSpace(s));
        }


        [TestMethod]
        [Ignore]
        public void TestGetFile()
        {
            var ssh = new SFTPUtil(host, user, pass);

            ssh.GetFile("/home/mattgwagner/.bash_profile", "c://");
        }

        [TestMethod]
        [Ignore]
        public void TestGetFileStream()
        {
            var ssh = new SFTPUtil(host, user, pass);

            var fos = File.Create("TEST.WAV");

            ssh.GetFile(path + "/2011-04-20-14-15-08_17816326831_95846543-bf9c-4d80-bbdc-ee2005ccbe34.wav", fos);
        }

        [TestMethod]
        [Ignore]
        public void TestDeleteFile()
        {
            var ssh = new SFTPUtil(host, user, pass);

            ssh.DeleteFile("/home/mattgwagner/Test.TXT");
        }

        [TestMethod]
        [Ignore]
        public void TestPutFile()
        {
            var ssh = new SFTPUtil(host, user, pass);

            ssh.PutFile("c://Test.txt", "/home/mattgwagner/Test.TXT");
        }

        [TestMethod]
        [Ignore]
        public void TestGetLotsOfFiles()
        {
            var ssh = new SFTPUtil(host, user, pass);

            ssh.GetLotsOfFiles(path, @"c:\loop\freeswitch\recordings");
        }
    }
}
