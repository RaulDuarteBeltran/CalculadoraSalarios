using System;
using System.Collections.Generic;
using Common.Exceptions;
using Common.AbstractClasses;

namespace Programa.Modelo.Utility
{
    public class ValidationListStringValidator : StringValidator
    {
        public class ValidationResult
        {
            public bool Result { get; set; }
            public int InvalidTextIndex { get; set; } = 0;
            public string InvalidText { get; set; } = string.Empty;

            public ValidationResult(bool result) : this(result, 0, string.Empty) { }
            public ValidationResult(bool result, int invalidCharacterIndex, string invalidText)
            {
                Result = result;
                InvalidTextIndex = invalidCharacterIndex;
                InvalidText = invalidText;
            }
        }

        private delegate ValidationResult Validator(string stringToValidate);

        private IList<Validator> stringValidators;

        public ValidationListStringValidator() : base()
        {
            stringValidators = new List<Validator>
            {
                new Validator(ValidateCharacters),
                //new Validator(ValidateAsignment),
                //new Validator(ValidateDateFormats),
            };
        }

        private ValidationResult ValidateCharacters(string stringToValidate)
        {
            for (int i = 0; i < stringToValidate.Length; i++)
            {
                char character = stringToValidate[i];
                if (char.IsLetterOrDigit(character)) break;
                else if (character == '=') break;
                else if (character == ':') break;
                else if (character == ',') break;
                else
                {
                    return new ValidationResult(false, i, character.ToString());
                }
            }
            return new ValidationResult(true);
        }

        /*private ValidationResult ValidateDateFormats(string stringToValidate)
        {
            List<int> asignmentPositions = new List<int>();
            for (int i = 0; i < stringToValidate.Length; i++)
            {
                if (stringToValidate[i] == '=' || stringToValidate[i] == ',')
                {
                    asignmentPositions.Add(i);
                }
            }

            //First lets check that the last asignation has a valid length
            int numberOfIndexes = asignmentPositions.Count;
            int lastIndex = asignmentPositions[numberOfIndexes - 1];
            if ((lastIndex + 13) != stringToValidate.Length) return (false, $"Day not valid on position {lastIndex + 1}");
            
            //aIndex comes from asignmentIndex
            foreach (int aIndex in asignmentPositions)
            {
                //All the valid inputs that i have seen have 13 values after the
                //',' or '=' asignment, so i will use that information to check
                //if a given period is valid.
                int startingPosition = aIndex + 1;
                int length = 13;
                string periodSubstring = stringToValidate.Substring(startingPosition,length);

                string daySubstring = periodSubstring.Substring(0, 2);
                if (ValidateDay(daySubstring) == false) return (false, $"Day not valid on position {aIndex + 1}");

                string firstTimeSubstring = periodSubstring.Substring(2, 5);
                if (ValidateTime(firstTimeSubstring) == false) return (false, $"Time not valid on position {aIndex + 3}");

                if (periodSubstring[7] != '-') return (false, $"Time separator invalid on position {aIndex+7}");

                string secondTimeSubstring = periodSubstring.Substring(8, 5);
                if (ValidateTime(secondTimeSubstring) == false) return (false, $"Time not valid on position {aIndex + 9}");

                
            }
            //If all the validations were passed, we can asume that the string has only valid time periods.
            return (true, "Time period is valid");


            bool ValidateDay(string day)
            {
                Dictionary<string, bool> dayDictionary = new Dictionary<string, bool>();
                dayDictionary.Add("MO", true);
                dayDictionary.Add("TU", true);
                dayDictionary.Add("WE", true);
                dayDictionary.Add("TH", true);
                dayDictionary.Add("FR", true);
                dayDictionary.Add("SA", true);
                dayDictionary.Add("SU", true);

                if(!dayDictionary.ContainsKey(day))
                {
                    return false;
                }
                return true;
            }
            bool ValidateTime(string time)
            {
                string hour = time.Substring(0, 2);
                if(int.TryParse(hour, out int parsedHour))
                {
                    if(parsedHour > 23)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                if (time[2] != ':') return false;

                string minutes = time.Substring(3, 2);
                if(int.TryParse(minutes, out int parsedMinutes))
                {
                    if (parsedMinutes > 59) return false;
                }
                else
                {
                    return false;
                }

                //Si todo salio correctamente
                return true;
            }
        }*/

        /*private ValidationResult ValidateAsignment(string stringToValidate)
        {
            int firstAsignment = stringToValidate.IndexOf('=');
            if (firstAsignment == -1)
            {
                return (false, "There was no asignment to a user");
            }
            return (true, string.Empty);
        }*/

        public override void Validate(string stringToValidate)
        {
            foreach (Validator validator in stringValidators)
            {
               validator?.Invoke(stringToValidate);
            }
        }

        /*private string GetInvalidText(string line, int errorIndex, int clueLength = 5)
        {
            if(line.Length <= clueLength)
            {
                return line;
            }
            //I always want to give the whole clue length if possible.
            //I'm going to check if the clue can be evenly divided in 2
            //if not, i will save the leftover to use if posible to give
            //either before or after the error index
            int clueLeftOver = clueLength % 2;
            

        }*/
    }
}

