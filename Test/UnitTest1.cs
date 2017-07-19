using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Dmeta.Helpers;
using System.Linq;
using Dmeta.Components;
using System.ComponentModel;
using System.IO;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        public int DoWork { get; private set; }
        public int ProgressChanged { get; private set; }
        public int DoWorkComplete { get; private set; }

        [TestMethod()]
        public void InjectMetadataTest()
        {
            Processing p = new Processing();
            p.InjectMetadata(System.AppDomain.CurrentDomain.BaseDirectory, "test.json");
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void JsonGeneartionTest()
        {
            Processing p = new Processing();

            List<string> imgs = System.IO.Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory, "*.tif", System.IO.SearchOption.AllDirectories).ToList();

            Assert.IsNotNull(imgs);
            Assert.IsTrue(imgs.Count() > 0);

            p.JsonGeneartion(null, Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "input.csv"), System.AppDomain.CurrentDomain.BaseDirectory,ref imgs);

            Assert.IsTrue(File.Exists(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "metadata.json")));
        }

        [TestMethod()]
        public void DistributeIntegerTest()
        {
            int total = 354;
            int div = 5;
            int res = 0;

            List<int> groups = Utility.DistributeInteger(total, div).ToList();

            foreach(int g in groups)
            {
                res += g;
            }

            Assert.IsTrue(res == total);
        }
    }
}
