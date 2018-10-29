using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Somebody once told me", new [] {"Somebody once told me"})]
        [InlineData("The\nworld is gonna\nroll me", new [] {"The", "world is gonna", "roll me"})]
        [InlineData(" I\n don\'t \n remember \n\n\n any further", new [] {" I", " don\'t ", " remember ", " any further"})]
        public void TestSplitToLines(string lhs, string[] rhs)
        {
            Assert.Equal(lhs.SplitToLines(), rhs);
        }
        
        [Theory]
        [InlineData("Somebody once told me", new [] {"Somebody", "once", "told", "me"})]
        [InlineData("The\nworld is gonna\nroll me", new [] {"The", "world", "is", "gonna", "roll", "me"})]
        [InlineData(" I\n don\'t  \n remember \n\n\n any further", new [] {"I", "don\'t", "remember", "any", "further"})]
        public void TestSplitToWords(string lhs, string[] rhs)
        {
            Assert.Equal(lhs.SplitToWords(), rhs);
        }
        
        [Theory]
        [InlineData("Somebody once told me", "Somebody o")]
        [InlineData("The world is gonna roll me", "The world is ")]
        public void TestGetLeftHalf(string lhs, string rhs)
        {
            Assert.Equal(lhs.GetLeftHalf(), rhs);
        }
        
        [Theory]
        [InlineData("Somebody once told me", "nce told me")]
        [InlineData("The world is gonna roll me", "gonna roll me")]
        public void TestGetRightHalf(string lhs, string rhs)
        {
            Assert.Equal(lhs.GetRightHalf(), rhs);
        }
        
        [Theory]
        [InlineData("Somebody once told me", " ", "", "Somebodyoncetoldme")]
        [InlineData("Somebody once told me", " once ", "", "Somebodytold me")]
        [InlineData("Somebody once told me\nThe world is gonna roll me", "me", "you", "Soyoubody once told you\nThe world is gonna roll you")]
        public void TestReplace(string lhs, string replaced, string replacement, string rhs)
        {
            Assert.Equal(RicksMercilessEncryptor.Replace(lhs, replaced, replacement), rhs);
        }
        
        [Theory]
        [InlineData("Somebody", "\\u0053\\u006F\\u006D\\u0065\\u0062\\u006F\\u0064\\u0079")]
        [InlineData("once", "\\u006F\\u006E\\u0063\\u0065")]
        [InlineData("told", "\\u0074\\u006F\\u006C\\u0064")]
        public void TestCharsToCodes(string lhs, string rhs)
        {
            Assert.Equal(lhs.CharsToCodes(), rhs);
        }
        
        [Theory]
        [InlineData("Somebody once told me", "em dlot ecno ydobemoS")]
        [InlineData("The world is gonna roll me", "em llor annog si dlrow ehT")]
        [InlineData("\n\n\r\r \t\t", "\t\t \r\r\n\n")]
        public void TestGetReversed(string lhs, string rhs)
        {
            Assert.Equal(lhs.GetReversed(), rhs);
        }
        
        [Theory]
        [InlineData("Somebody once told me", "sOMEBODY ONCE TOLD ME")]
        [InlineData("The world is gonna roll me", "tHE WORLD IS GONNA ROLL ME")]
        [InlineData("\n\n\r\r \t\t", "\n\n\r\r \t\t")]
        public void TestInverseCase(string lhs, string rhs)
        {
            Assert.Equal(lhs.InverseCase(), rhs);
        }
        
        [Theory]
        [InlineData("Somebody once told me", "Tpnfcpez!podf!upme!nf")]
        [InlineData("The world is gonna roll me", "Uif!xpsme!jt!hpoob!spmm!nf")]
        [InlineData("\n\n\r\r \t\t", "\v\v\x0e\x0e!\n\n")]
        public void TestShiftInc(string lhs, string rhs)
        {
            Assert.Equal(lhs.ShiftInc(), rhs);
        }
        
        [Theory]
        [InlineData("0000:0000 // 0000:0001", new [] {0L})]
        [InlineData("0000:0000 /* 0000:0001 */ 0000:0002", new [] {0L, 2L})]
        [InlineData("0000:0000 /* 0000:0001\n0000:0002 */ 0000:0003", new [] {0L, 3L})]
        [InlineData("0000:0000 /* 0000:0001\n0000:0002 // 0000:0003 0000:0004 */ 0000:0005", new [] {0L, 5L})]
        public void TestGetUsedObjects(string lhs, long [] rhs)
        {
            Assert.Equal(lhs.GetUsedObjects(), rhs);
        }
    }
}
