﻿using System;
using System.Globalization;
using IQFeed.CSharpApiClient.Lookup.Historical.Messages;
using IQFeed.CSharpApiClient.Tests.Common;
using IQFeed.CSharpApiClient.Tests.Common.TestCases;
using NUnit.Framework;

namespace IQFeed.CSharpApiClient.Tests.Lookup.Historical.Messages
{
    public class TickMessageTests
    {
        [Test, TestCaseSource(typeof(CultureNameTestCase), nameof(CultureNameTestCase.CultureNames))]
        public void Should_Parse_TickMessage_Culture_Independant(string cultureName)
        {
            // Arrange
            TestHelper.SetThreadCulture(cultureName);
            var message = "2018-04-17 17:51:22.123456,96.0700,1061909,0,0.0000,0.0000,4145784264,O,19,143A";

            // Act
            var tickMessageParsed = TickMessage.Parse(message);

            var timestamp = DateTime.ParseExact("2018-04-17 17:51:22.123456", TickMessage.TickDateTimeFormat, CultureInfo.InvariantCulture);
            var tickMessage = new TickMessage(timestamp, 96.07f, 1061909, 0, 0.0f, 0.0f, 4145784264, 'O', 19, "143A");

            // Assert
            Assert.AreEqual(tickMessageParsed, tickMessage);
        }
    }
}