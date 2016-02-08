using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Metier;
using System.Collections.Generic;

namespace UnitTestMetier
{
    [TestClass]
    public class UnitTestMetier
    {
        public Calculate calculate;

        [TestMethod]
        public void DonnerListeDoubleEtObtenirMoyenne()
        {
            //Assert
            calculate = new Calculate();
            List<double> list = new List<double>();
            list.Add(1);
            list.Add(2);
            double actualAverage = 1.5;
            double expectedAverage = 0.0;

            //Act
            expectedAverage = calculate.calculMoyenne(list);

            //Assert
            Assert.AreEqual(expectedAverage, actualAverage);
        }
    }
}
