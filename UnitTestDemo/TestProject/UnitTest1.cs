using MainApp;
using NUnit.Framework;

/*
 * Benodigde NuGet Packages:
 *  - Microsoft.NET.Test.Sdk
 *  - NUnit
 *  - NUnit3TestAdapter
 */

namespace TestProject
{
    public class Tests
    {
        private Berekeningen berekeningen;
        [SetUp]
        public void Setup()
        {
            // ARRANGE ('setup')
            this.berekeningen = new Berekeningen();
        }

        [TestCase(1.5f, 2.5f, 4.0f)]
        [TestCase(1,2,3)]
        public void TestFloats(float a, float b , float expectedResult) {
            // ACT
            float result = berekeningen.AddTwoNumbers(a, b);
            
            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        #region TestIntegers
        [TestCase(1, 2, 3)]
        [TestCase(-1, 1, 0)]
        [TestCase(131, 985, 1116)]
        [TestCase(740, 727, 1467)]
        [TestCase(982, 468, 1450)]
        [TestCase(95, 526, 621)]
        [TestCase(299, 571, 870)]
        [TestCase(936, 735, 1671)]
        [TestCase(438, 302, 740)]
        [TestCase(740, 480, 1220)]
        [TestCase(511, 270, 781)]
        [TestCase(367, 584, 951)]
        [TestCase(61, 589, 650)]
        [TestCase(65, 686, 751)]
        [TestCase(831, 137, 968)]
        [TestCase(355, 948, 1303)]
        [TestCase(233, 376, 609)]
        [TestCase(410, 774, 1184)]
        [TestCase(332, 663, 995)]
        [TestCase(84, 446, 530)]
        [TestCase(666, 747, 1413)]
        [TestCase(403, 765, 1168)]
        [TestCase(199, 998, 1197)]
        [TestCase(194, 154, 348)]
        [TestCase(249, 51, 300)]
        [TestCase(263, 509, 772)]
        [TestCase(286, 400, 686)]
        [TestCase(303, 727, 1030)]
        [TestCase(564, 571, 1135)]
        [TestCase(304, 504, 808)]
        [TestCase(520, 959, 1479)]
        [TestCase(390, 488, 878)]
        [TestCase(618, 618, 1236)]
        [TestCase(574, 30, 604)]
        [TestCase(821, 498, 1319)]
        [TestCase(681, 680, 1361)]
        [TestCase(357, 296, 653)]
        [TestCase(912, 840, 1752)]
        [TestCase(337, 602, 939)]
        [TestCase(483, 585, 1068)]
        [TestCase(876, 65, 941)]
        [TestCase(198, 648, 846)]
        [TestCase(113, 521, 634)]
        [TestCase(589, 645, 1234)]
        [TestCase(588, 715, 1303)]
        [TestCase(481, 494, 975)]
        [TestCase(115, 613, 728)]
        [TestCase(856, 235, 1091)]
        [TestCase(117, 921, 1038)]
        [TestCase(243, 6, 249)]
        [TestCase(754, 292, 1046)]
        [TestCase(810, 160, 970)]
        [TestCase(776, 324, 1100)]
        [TestCase(873, 307, 1180)]
        [TestCase(670, 256, 926)]
        [TestCase(144, 718, 862)]
        [TestCase(526, 82, 608)]
        [TestCase(437, 326, 763)]
        [TestCase(459, 804, 1263)]
        [TestCase(753, 602, 1355)]
        [TestCase(577, 369, 946)]
        [TestCase(663, 789, 1452)]
        [TestCase(619, 527, 1146)]
        [TestCase(529, 78, 607)]
        [TestCase(304, 282, 586)]
        [TestCase(12, 505, 517)]
        [TestCase(259, 629, 888)]
        [TestCase(473, 455, 928)]
        [TestCase(150, 958, 1108)]
        [TestCase(580, 907, 1487)]
        [TestCase(895, 37, 932)]
        [TestCase(968, 475, 1443)]
        [TestCase(874, 16, 890)]
        [TestCase(725, 707, 1432)]
        [TestCase(925, 874, 1799)]
        [TestCase(37, 84, 121)]
        [TestCase(833, 119, 952)]
        [TestCase(292, 820, 1112)]
        [TestCase(192, 568, 760)]
        [TestCase(827, 550, 1377)]
        [TestCase(2, 244, 246)]
        [TestCase(804, 294, 1098)]
        [TestCase(809, 914, 1723)]
        [TestCase(694, 335, 1029)]
        [TestCase(390, 176, 566)]
        [TestCase(342, 53, 395)]
        [TestCase(175, 961, 1136)]
        [TestCase(267, 693, 960)]
        [TestCase(74, 208, 282)]
        [TestCase(609, 876, 1485)]
        [TestCase(307, 156, 463)]
        [TestCase(382, 908, 1290)]
        [TestCase(946, 430, 1376)]
        [TestCase(692, 895, 1587)]
        [TestCase(53, 368, 421)]
        [TestCase(431, 984, 1415)]
        [TestCase(930, 908, 1838)]
        [TestCase(913, 561, 1474)]
        [TestCase(732, 749, 1481)]
        [TestCase(478, 477, 955)]
        [TestCase(315, 288, 603)]
        [TestCase(745, 320, 1065)]
        [TestCase(67, 96, 163)]
        [TestCase(587, 858, 1445)]
        [TestCase(980, 807, 1787)]
        [TestCase(589, 645, 1234)]
        [TestCase(873, 55, 928)]
        [TestCase(361, 108, 469)]
        #endregion
        public void TestIntegers(int a, int b , int expectedResult) {
            // ACT
            long result = berekeningen.AddTwoNumbers(a, b);
            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }    
        
        [TestCase(1, 2, 3)]
        [TestCase(-999, 1000, 1)]
        public void TestDoubles(double a, double b , double expectedResult) {
            // ACT
            double result = berekeningen.AddTwoNumbers(a, b);
            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }
    }
}