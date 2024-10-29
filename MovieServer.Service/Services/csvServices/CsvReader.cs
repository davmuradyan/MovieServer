using System;
using System.Collections.Generic;
using System.IO;

internal static class CsvReader {
    internal static List<(uint? movieId, uint? tagId, double? relevance)> ReadGenomeScores(string filePath = "C:\\Users\\servi\\Desktop\\ml-latest\\ml-latest\\genome-scores.csv") {
        var data = new List<(uint? movieId, uint? tagId, double? relevance)>();

        using (var reader = new StreamReader(filePath)) {
            // Skip the header
            reader.ReadLine();

            int lineNumber = 1;
            while (!reader.EndOfStream) {
                var line = reader.ReadLine();
                var columns = line.Split(',');

                // Check column count
                if (columns.Length < 3) {
                    Console.WriteLine($"Skipping line {lineNumber + 1}: insufficient columns");
                    lineNumber++;
                    continue;
                }

                uint? movieId, tagId;
                double? relevance;

                try {
                    movieId = uint.Parse(columns[0]);
                } catch {
                    Console.WriteLine($"Error parsing movieId at line {lineNumber + 1}");
                    movieId = null;
                }

                try {
                    tagId = uint.Parse(columns[1]);
                } catch {
                    Console.WriteLine($"Error parsing tagId at line {lineNumber + 1}");
                    tagId = null;
                }

                try {
                    relevance = double.Parse(columns[2]);
                } catch {
                    Console.WriteLine($"Error parsing relevance at line {lineNumber + 1}");
                    relevance = null;
                }

                data.Add((movieId, tagId, relevance));
                lineNumber++;
            }
        }

        return data;
    }
    internal static List<(uint? userId, uint? movieId, float? rating, uint? timestemp)> ReadRatings(int part, string filePath = "C:\\Users\\servi\\Desktop\\ml-latest\\ml-latest\\ratings.csv") {
        if (part <= 0 || part > 15)
        {
            throw new Exception("Part should be from range [1;15]");
        }

        var data = new List<(uint? userId, uint? movieId, float? rating, uint? timestemp)>();

        using (var reader = new StreamReader(filePath)) {
            // Skip the header
            reader.ReadLine();

            int lineNumber = 1;
            while (!reader.EndOfStream) {
                var line = reader.ReadLine();
                var columns = line.Split(',');

                // Check column count
                if (columns.Length < 3) {
                    Console.WriteLine($"Skipping line {lineNumber + 1}: insufficient columns");
                    lineNumber++;
                    continue;
                }

                uint? movieId, userId, timestemp;
                float? rating;

                try {
                    userId = uint.Parse(columns[0]);
                } catch {
                    Console.WriteLine($"Error parsing movieId at line {lineNumber + 1}");
                    userId = null;
                }

                try {
                    movieId = uint.Parse(columns[1]);
                } catch {
                    Console.WriteLine($"Error parsing tagId at line {lineNumber + 1}");
                    movieId = null;
                }

                try {
                    rating = float.Parse(columns[2]);
                } catch {
                    Console.WriteLine($"Error parsing relevance at line {lineNumber + 1}");
                    rating = null;
                }

                try {
                    timestemp = uint.Parse(columns[3]);
                } catch {
                    Console.WriteLine($"Error parsing relevance at line {lineNumber + 1}");
                    timestemp = null;
                }

                data.Add((userId, movieId, rating, timestemp));
                lineNumber++;
            }
        }

        var rData = ReturnPart(data, part, 15);

        return rData;
    }
    private static List<(uint? userId, uint? movieId, float? rating, uint? timestemp)> ReturnPart(List<(uint? userId, uint? movieId, float? rating, uint? timestemp)> arr, int part, int totalParts) {
        var rArray = new List<(uint? userId, uint? movieId, float? rating, uint? timestemp)>();

        int i = 0;
        for (int j = (part - 1) * arr.Count / totalParts; j < part * arr.Count / totalParts; j++) {
            rArray.Add(arr[j]);
            i++;
        }

        return rArray;
    }
}