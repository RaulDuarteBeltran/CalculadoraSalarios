using System;
using System.Collections.Generic;
using Common.AbstractClasses;
using Common.Entities;
using Common.Interfaces;

namespace Common.Utility
{
    public class SimpleEmployeeStringParser : StringParser
    {
        public SimpleEmployeeStringParser()
        {
        }

        public override IList<Employee> Parse(string stringToParse)
        {
            string[] employeeStrings = stringToParse.Split("\n");
            IList<Employee> parsedEmployees = new List<Employee>();
            foreach (string employeeString in employeeStrings)
            {
                //Here we obtain the employee name, as it's the only thing
                //before the initial asignment, marked by the "="
                int asignmentIndex = employeeString.IndexOf("=");
                string name = employeeString.Substring(0, asignmentIndex);
                //Now we create an employee
                SimpleEmployee employee = new SimpleEmployee(name);

                //We need to create a list to store the indexes right before
                //the time period.
                List<int> asignmentPositions = new List<int>();
                //The first asignation occurs right after the "=", so we add that
                asignmentPositions.Add(asignmentIndex);
                //The rest we need to find with the ",".
                //We can begin after the asignment position
                for(int i = asignmentIndex; i < employeeString.Length; i++)
                {
                    if (employeeString[i] == ',')
                    {
                        asignmentPositions.Add(i);
                    }
                }

                //Now that we have the asignment indexes, we can begin to extract
                IWorkedScheduleParser parser = new SimpleWorkedScheduleParser();
                //With this parser we are asuming that the timeSpan can only
                //be in one timeGroup.
                //Now we obtain each time period string, parse it and asignit to the employee.
                foreach (int aIndex in asignmentPositions)
                {
                    int startingPosition = aIndex + 1;
                    int length = 13;
                    string periodSubstring = employeeString.Substring(startingPosition, length);
                    IWorkedSchedule parsedSchedule = parser.Parse(periodSubstring);
                    employee.AddWorkedSchedule(parsedSchedule);
                }
                //Once we finish adding the employee schedules, we add
                //the employee to the list.
                parsedEmployees.Add(employee);
                
            }

            return parsedEmployees;
        }
    }
}
