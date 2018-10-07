using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;


namespace AdventureTime.Tests
{
    [TestClass]
    public class UnitTests
    {
        [Fact]
        public void CurrentIsNotUtc()
        {
            DateTime current = Time.WhatTimeIsIt();
            DateTime utc = Time.WhatTimeIsItInUtc();
            Assert.Equals(current, utc);
        }
    }
}
