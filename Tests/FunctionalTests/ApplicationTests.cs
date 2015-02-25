using System;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;


namespace Tests
{
    [TestFixture]
    public class ApplicationTests
    {
        Process proc;
        StreamWriter stdin;
        StreamReader stdout;

        [SetUp]
        public void StartApp()
        {
            proc = new Process();
            proc.StartInfo.FileName = "RoboCleaner.exe";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();

            stdin = proc.StandardInput;
            stdout = proc.StandardOutput;
        }

        [TearDown]
        public void StopApp()
        {
            if (!proc.WaitForExit(10))
            {
                proc.Kill();
            }
        }

        [Test]
        public void Should_prefix_result_string()
        {
            stdin.Write("1\n0 0\nN 1\n");
            Assert.That(stdout.ReadLine().StartsWith("=> Cleaned: "));
        }

        [Test]
        public void Should_report_unique_spots()
        {
            stdin.WriteLine("2");
            stdin.WriteLine("10 22");
            stdin.WriteLine("E 2");
            stdin.WriteLine("N 1");

            var result = stdout.ReadToEnd();

            Assert.AreEqual("=> Cleaned: 4", result);
        }

        [Test]
        public void Should_only_handle_a_preset_number_of_commands()
        {
            stdin.WriteLine("2");
            stdin.WriteLine("0 0");
            stdin.WriteLine("N 1");
            stdin.WriteLine("N 1");
            stdin.WriteLine("N 10000"); // not used

            var result = stdout.ReadToEnd();

            Assert.AreEqual("=> Cleaned: 3", result);
        }

        [Test]
        public void Should_accept_large_input()
        {
            stdin.WriteLine("10000");
            stdin.WriteLine("-50000 -50000");
            for (int i = 0; i < 2500; i++)
            {
                stdin.WriteLine("N 1000");
                stdin.WriteLine("E 1000");
                stdin.WriteLine("S 1000");
                stdin.WriteLine("W 1000");
            }

            var result = stdout.ReadToEnd();

            Assert.AreEqual("=> Cleaned: 4000", result);
        }
    }
}

