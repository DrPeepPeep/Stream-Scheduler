using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

class StreamScheduler
{
    static void Main()
    {
        try
        {
            // Path to the PowerShell script in the "scripts" folder
            string psScriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scripts", "CheckAndInstallDotNet.ps1");

            // Run the PowerShell script to check and install .NET 8.0
            RunPowerShellScript(psScriptPath);

            // Define the text messages you will display
            string[] messages = {
            "Enter the time for Monday (24-hour or 12-Hour format), 'n' for none, 's' to skip, or 'd' to delete remaining days:"
            // Add other messages here as needed
        };


            // Calculate the maximum length of the messages
            int maxLength = messages.Max(msg => msg.Length);

            // Adjust console window width and buffer size based on the longest message
            Console.SetWindowSize(Math.Max(100, maxLength), Console.WindowHeight); // Ensure minimum width of 100 columns
            Console.BufferWidth = Math.Max(100, maxLength); // Set the buffer width to match the window width

            // Days of the week in title case
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            // Get the directory of the executable
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Create a subfolder for the schedule files
            string folderPath = Path.Combine(baseDirectory, "StreamSchedule");
            Directory.CreateDirectory(folderPath); // Create folder if it doesn't exist

            // Ensure the text files are created inside the folder
            foreach (string day in days)
            {
                string filePath = Path.Combine(folderPath, $"{day}.txt");
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, string.Empty); // Create empty file if it doesn't exist
                }
            }

            // Loop through each day and get input
            for (int i = 0; i < days.Length; i++)
            {
                bool validInput = false; // Flag to control input validation loop

                while (!validInput) // Loop until valid input is provided
                {
                    Console.WriteLine($"Enter the time for {days[i]} (24-hour or 12-Hour format), 'n' for none, 's' to skip, or 'd' to delete remaining days:");
                    string input = Console.ReadLine().Trim();

                    // Prepare file path
                    string filePath = Path.Combine(folderPath, $"{days[i]}.txt");

                    // Option to skip editing this day
                    if (input.ToLower() == "s")
                    {
                        Console.WriteLine($"{days[i]} is skipped, retaining the current content.");
                        validInput = true; // Exit the loop and move to the next day
                    }
                    // Option to delete the content for this day and the next x days
                    else if (input.ToLower() == "d")
                    {
                        int daysToDelete = GetNumberOfDaysToDelete(i, days.Length);

                        // Delete content for the specified number of days
                        for (int j = i; j < i + daysToDelete; j++)
                        {
                            string deleteFilePath = Path.Combine(folderPath, $"{days[j]}.txt");
                            File.WriteAllText(deleteFilePath, string.Empty);
                            Console.WriteLine($"Deleted content for {days[j]}.");
                        }

                        validInput = true;
                        i += daysToDelete - 1; // Skip the deleted days
                    }
                    // Option to clear content for the day (none)
                    else if (input.ToLower() == "n")
                    {
                        File.WriteAllText(filePath, string.Empty);
                        Console.WriteLine($"{days[i]} has been set to 'None'.");
                        validInput = true; // Exit the loop
                    }
                    // Validate time format (24-hour or 12-Hour clock)
                    else if (IsValidTime(input))
                    {
                        File.WriteAllText(filePath, input);
                        Console.WriteLine($"{days[i]} is updated with time: {input}");
                        validInput = true; // Exit the loop
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid time in 24-hour or 12-Hour format (e.g., 14:00), 'n', 's', or 'd'.");
                    }
                }
            }

            Console.WriteLine("Stream schedule has been updated.");
        }
        catch (Exception ex)
        {
            // Catch any unhandled exception and display the error message
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }
        finally
        {
            // Wait for user input before closing the console window
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    // Method to validate the time format (24-hour or 12-Hour clock)
    static bool IsValidTime(string input)
    {
        return TimeSpan.TryParseExact(input, "h\\:mm", null, out _);
    }
   
    // Method to get the number of days to delete after the current day
    static int GetNumberOfDaysToDelete(int currentIndex, int totalDays)
    {
        while (true)
        {
            Console.WriteLine("Enter the number of subsequent days to delete (including today):");
            if (int.TryParse(Console.ReadLine(), out int daysToDelete) && daysToDelete > 0 && currentIndex + daysToDelete <= totalDays)
            {
                return daysToDelete;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number of days.");
            }
        }
    }

    // Method to run a PowerShell script
    static void RunPowerShellScript(string scriptPath)
    {
        try
        {
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = $"-ExecutionPolicy Bypass -File \"{scriptPath}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(processInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.WriteLine(result);
                }
                process.WaitForExit();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while running PowerShell script: {ex.Message}");
            Environment.Exit(1);
        }
    }
}
