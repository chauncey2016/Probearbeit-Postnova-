using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // A. read data.txt (x,y Werte)
            string filePath = "data.txt";
            var dataPoints = ReadDataFile(filePath);

            if (dataPoints.Count == 0)
            {
                Console.WriteLine("No data was read or the file is empty.");
                return;
            }

            // Value y
            var yValues = dataPoints.Select(p => p.Y).ToList();

            // B. Calculate the mean and standard deviation of y
            double average = CalculateAverage(yValues);
            double standardDeviation = CalculateStandardDeviation(yValues, average);

            Console.WriteLine($"Mean of the Y values: {average:F16}");
            Console.WriteLine($"Standard deviation of the Y values: {standardDeviation:F16}");
            Console.WriteLine();

            // C. Compute first and second derivatives
            var firstDerivatives = CalculateFirstDerivatives(dataPoints);
            var secondDerivatives = CalculateSecondDerivatives(dataPoints);

            Console.WriteLine("Calculation results:");
            Console.WriteLine("X value\tY value\tFirst derivative\tSecond derivative");
            for (int i = 0; i < dataPoints.Count; i++)
            {
                string firstDer = i < firstDerivatives.Count ? firstDerivatives[i].ToString("F6") : "N/A";
                string secondDer = i < secondDerivatives.Count ? secondDerivatives[i].ToString("F6") : "N/A";
                Console.WriteLine($"{dataPoints[i].X}\t{dataPoints[i].Y}\t{firstDer}\t\t{secondDer}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    // Reading data files
    static List<DataPoint> ReadDataFile(string filePath)
    {
        var dataPoints = new List<DataPoint>();

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File {filePath} not find.");
        }

        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split(new[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2 && double.TryParse(parts[0], out double x) && double.TryParse(parts[1], out double y))
            {
                dataPoints.Add(new DataPoint(x, y));
            }
        }

        return dataPoints;
    }

    // Calculate the average
    static double CalculateAverage(List<double> values)
    {
        return values.Average();
    }

    // Calculate standard deviation
    static double CalculateStandardDeviation(List<double> values, double average)
    {
        double sumOfSquares = values.Sum(v => Math.Pow(v - average, 2));
        return Math.Sqrt(sumOfSquares / values.Count);
    }

    // Compute first derivative (using central difference method)
    static List<double> CalculateFirstDerivatives(List<DataPoint> dataPoints)
    {
        var derivatives = new List<double>();

        for (int i = 1; i < dataPoints.Count - 1; i++)
        {
            double h = dataPoints[i + 1].X - dataPoints[i - 1].X;
            if (h == 0) continue; // Avoid division by zero

            double derivative = (dataPoints[i + 1].Y - dataPoints[i - 1].Y) / h;
            derivatives.Add(derivative);
        }

        return derivatives;
    }

    // Compute second derivatives (using central difference method)
    static List<double> CalculateSecondDerivatives(List<DataPoint> dataPoints)
    {
        var secondDerivatives = new List<double>();

        for (int i = 1; i < dataPoints.Count - 1; i++)
        {
            double h = dataPoints[i + 1].X - dataPoints[i - 1].X;
            if (h == 0) continue; // Avoid division by zero

            double secondDerivative = (dataPoints[i + 1].Y - 2 * dataPoints[i].Y + dataPoints[i - 1].Y) / (h * h);
            secondDerivatives.Add(secondDerivative);
        }

        return secondDerivatives;
    }
}

// Datastructer
class DataPoint
{
    public double X { get; }
    public double Y { get; }

    public DataPoint(double x, double y)
    {
        X = x;
        Y = y;
    }
}
