using System;
using Xunit;
using System.Collections.Generic;
using Common.AbstractClasses;
using Common.Entities;
using Common.Interfaces;
using Common.Utility;
using Common.Enums;

namespace UnitTestingCalculadoraSalarios.Parsers
{
    public class SimpleWorkedScheduleParserShould
    {
        [Fact]
        public void ReturnParsedWorkedSchedule()
        {
            //Arrange
            IWorkedScheduleParser parser = new SimpleWorkedScheduleParser();
            string scheduleToParse = "MO10:00-12:00";
            IWorkedSchedule expectedSchedule = new SimpleWorkedSchedule(WorkingDays.MO, WorkingTimeGroups.RegularSchedule, new TimeSpan(2,0,0));

            //Act
            IWorkedSchedule parsedSchedule = parser.Parse(scheduleToParse);

            //Assert
            Assert.Equal<WorkingDays>(parsedSchedule.WorkingDay, expectedSchedule.WorkingDay);
            Assert.Equal<WorkingTimeGroups>(parsedSchedule.WorkingTimeGroup, expectedSchedule.WorkingTimeGroup);
            Assert.Equal(parsedSchedule.TimeSpan.Hours, expectedSchedule.TimeSpan.Hours);
        }
    }
}
