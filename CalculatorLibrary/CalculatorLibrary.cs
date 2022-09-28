using System;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
   public class Calculator
    {
        JsonWriter writer;

        public Calculator ()
        {
            //how to write to a json file
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            Trace.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }

        //public Calculator()
        //{
        //          HOW TO WRITE TO A LOG WITH TRACE CLASS
        //    StreamWriter logFile = File.CreateText("calculator.log");
        //    Trace.Listeners.Add(new TextWriterTraceListener(logFile));
        //    Trace.AutoFlush = true;
        //    Trace.WriteLine("Starting Calculator Log");
        //    Trace.WriteLine(String.Format("Started {0}", System.DateTime.Now.ToString()));
        //}
        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not a number£ if an operation, such as division
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operation");

            // Use a switch statement for calculations
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    writer.WriteValue("Add");
                    //Trace.WriteLine(String.Format("{0} + {1} = {2}", num1, num2, result));
                    break;
                case "s":
                    result = num1 - num2;
                    writer.WriteValue("Subtract");
                    //Trace.WriteLine(String.Format("{0} - {1} = {2}", num1, num2, result));
                    break;
                case "m":
                    result = num1 * num2;
                    writer.WriteValue("Multiply");
                    //Trace.WriteLine(String.Format("{0} * {1} = {2}", num1, num2, result));
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                       // Trace.WriteLine(String.Format("{0} / {1} = {2}", num1, num2, result));
                    }
                    writer.WriteValue("Divide");
                    break;
                // Reutrn text for an incorrent option entry.
                default:
                    break;
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;

        }
        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
             
    }
}