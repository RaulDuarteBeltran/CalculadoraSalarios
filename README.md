# Overview
Greetings, i hope that you are having a great day. This is the implementation to a salary calculator in C#.
The main logic is simple. You give the name of the txt file where the data is contained and then the program creates a Parser that takes the file name,
validates that the file is valid, read it's content and finally returns a list with the employees and the work schedules that they followed.
With that the program creates a salary calculator that takes each employee and calculates it's salary according to the specifications of the problem, before
printing them on the console.

# How to run the program
I didn't know which operating system was going to be used to run the example, so in this case we'll need to build the project before using it. We could do it
by opening the project in Visual Studio and Building it, or we could use the following command:
dotnet build
This command has to be used on the project folder.
To provide a file for the program to use we need to put the file on the corresponding bin folder. For example, if we built the project in debug mode, we need to
put the file on Programa/bin/Debug/netcoreapp3.1.
We then can run the program using dotnet run Programa.dll and providing the file name when the console ask for it.

# Architecture
I decided to use a modular approach to the problem. With this i got to try some different implementations of the different parts on the solution.

## General solution
On the Program part i made use only of abstract clases and interface types on the definition of my variables. With this i can change an specific part if needed
without having to change anything on the main program.

## The parser builder
The program makes use of a ParserBuilder. This object implements the interface IParseBuilder, which specifies that the implementing class has to have a Build method
that returns an object of the type ISourceParser.
I made use of the builder programing pattern, so all my configuration of
the actual Parser can be done on this clase and if i need to change some element of the parser i only need to do it in the builder.

### The naive builder
For the actual implementation I created a naive builder, which implements IParserBuilder. It's called naive because it doesn't make a lot of validations on the
actual text that it parses before parsing it. The positive thing is that since i used the builder pattern i could implement another builder that does make
validations on the text and responds more adequately to certain cases.

The naive builder has a build method that returns a NaiveParser, which implements the ISourceParser interface and is the actual class that makes the conversion of
the text to employee objects that can be used on the program.

### The File Validator
The naive builder decides which file validator to use. in this case i used a simple validator that checks if the file exists, if it has the right extension and if
it's not empty. If one of this cases occurs, the validator throws an custom exception called FileValidationException, which has information about the file name, it's
route and a message describing the kind of error that occurred.
The builder doesn't directly uses the FileValidator. It's function is selecting the most adequate validator for the case and inject it to the actual
SourceParser, which is the one that will make use of it.

### The file reader
Just as the File validator, the builder doesn't make direct use of the file reader. It only passes it to the SourceParser for it to use it when the Parse method
is called.
The file reader gets a StreamReader object that can read the text of the file that we are using.

## The StreamConverter
The stream converted will be used by the SourceParser to convert the result of the fileReader into actual text that can be used by the application. The
Stream Converted has to inherit from an abstract class called StreamConverter, which has an abstract method called Convert that takes an StreamReader and returns an
String. I chose to use an abstract class because we could have different implementations of the base class that could make more validations for example, or choose
to return all the text in only one line.

### The MultiLineStreamConverter
This is the actual implementation that i chose. It takes the StreamReader, read it's text line by line and appends each line to a string, followed by a separator
that marks when the line ends. In my implementation each line represents a new entry for a new employee, so that is why i append a separator.

## The StringParser
This is one of the most important parts of the application. It's job is to take the text that represent the employee and use it to create an object that represents
the employee, including its name and a list of all the work schedules that the employee had. Each schedule has it's day of the week, the day period when it
worked and the time that the employee worked.

### The SimpleEmployeeStringParser
This is the actual implementation. It takes the string that we got from the MultiLineStreamConverter and splits it on an array of strings. Each element of the
array represents an employee with it's schedules, and it's the thing that we are going to parse.
For each one of the employee lines, it obtains its name and creates the employee object. This object it's from a class that inherit from the abstract Employee
Class, so that we could have different implementations of an employee or different employee categories. Maybe that way we could calculate the salary based on
the employee type if needed.
After creating the employee object, it gets the text of each one of the time periods that the employee worked, and uses a class called the SimpleWorkedScheduleParser
to parse each one of the schedule strings to an object that implements the interface IWorkedSchedule. When we obtain the object of IWorkedSchedule, we can add it
to the list of WorkedSchedules of our employee. We do this for each employee that we have on our string.

### The SimpleWorkedScheduleParser
This class implements the IWorkedScheduleParser, so i can replace it with another type of parser if needed.
It takes a string that represents the worked schedule and obtains the parts that conform a schedule object. The parts are the day, which we obtain as an enum
value for consistency; the WorkingTimeGroup, which indicates on which period of the day the schedule is from (really early, really late or a regular schedule). To
do this i obtain two dateTime objects from our schedule and use them to check on which of the groups the schedule fits. I like my implementation of this because
I created extension methods for the DateTime class to be able to easily obtain if a time if before or after midnight, after 9 A.M or after 6 P.M, which really
simplified the validations to find the schedule group.
Finally i calculate the working hours. In this implementation we are only taking into account the hours of the schedules. An alternative implementation of the
interface could make use of the hours and minutes and only be replaced on the object declaration on the StringParser.

## The SourceParser
Once we built the sourceParser with our builder, we can call the Parse method and pass it the file name that we want to parse to a group of employees.
Internally the parser validates the file, obtains the text that it contains and parses that text to a list of employees with their working schedules. To do this it
uses the components that the ParserBuilder supplied.

## The SalaryCalculator
This class has to implement the interface ISalaryCalculator, in case that we want to have another implementation to calculate the salary. It takes an employee
and it returns it's salary. The actual implementation uses the working schedule and the values that the exercise indicates to calculate the right salary for the
employee.

# Final Considerations of the architecture
I tried to make the architecture as modular as possible, so if the format of the text changes, i only need to replace the validator or the converter, without having
to really change the main program. In its current state the program can catch if the file is invalid and show why. Further improvements could give more precise 
information of where the error occurs.
