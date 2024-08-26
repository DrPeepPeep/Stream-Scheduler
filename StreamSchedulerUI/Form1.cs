using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace StreamSchedulerUI
{
    public partial class Form1 : Form
    {
        private string folderPath;
        private string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        private TextBox[] textBoxes;

        public Form1()
        {
            InitializeComponent();
            folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StreamSchedule");
            Directory.CreateDirectory(folderPath); // Ensure the folder exists
            textBoxes = new TextBox[] { txtMonday, txtTuesday, txtWednesday, txtThursday, txtFriday, txtSaturday, txtSunday };

            // Enable drag-and-drop
            this.AllowDrop = true;
            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;

            // Subscribe to the Load event
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataFromFiles(); // Load data on form load
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            bool errorOccurred = false;

            for (int i = 0; i < days.Length; i++)
            {
                string input = textBoxes[i].Text.Trim();
                string filePath = Path.Combine(folderPath, $"{days[i]}.txt");

                if (string.IsNullOrWhiteSpace(input))
                {
                    // If input is empty, clear the file's content
                    if (File.Exists(filePath))
                    {
                        File.WriteAllText(filePath, string.Empty); // Clear the file content
                        sb.AppendLine($"{days[i]} has been cleared.");
                    }
                }
                else if (input.ToLower() == "n")
                {
                    File.WriteAllText(filePath, string.Empty);
                    sb.AppendLine($"{days[i]} has been set to 'None'.");
                }
                else if (input.ToLower() == "s")
                {
                    sb.AppendLine($"{days[i]} is skipped, retaining the current content.");
                }
                else if (input.ToLower() == "d")
                {
                    File.WriteAllText(filePath, string.Empty);
                    sb.AppendLine($"{days[i]} and the remaining days have been cleared.");
                    break; // Exit the loop if deleting remaining days
                }
                else if (IsValidTime(input))
                {
                    File.WriteAllText(filePath, input);
                }
                else
                {
                    if (!errorOccurred)
                    {
                        sb.AppendLine($"{days[i]} is invalid with the time {input}.");
                        errorOccurred = true;
                    }
                }
            }

            // Display the accumulated message box
            MessageBox.Show(errorOccurred ? sb.ToString() : "Changes saved", "Save Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool IsValidTime(string input)
        {
            return TimeSpan.TryParseExact(input, "h\\:mm", null, out _);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadDataFromFiles()
        {
            for (int i = 0; i < days.Length; i++)
            {
                string filePath = Path.Combine(folderPath, $"{days[i]}.txt");
                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    textBoxes[i].Text = content;
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Optionally adjust the form size based on the number of files
            AdjustFormSizeForFiles(files);

            foreach (var file in files)
            {
                if (Path.GetExtension(file) == ".txt" && File.Exists(file))
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    if (Array.Exists(days, day => day.Equals(fileName, StringComparison.OrdinalIgnoreCase)))
                    {
                        int index = Array.FindIndex(days, day => day.Equals(fileName, StringComparison.OrdinalIgnoreCase));
                        textBoxes[index].Text = File.ReadAllText(file);
                    }
                }
            }
        }

        private void AdjustFormSizeForFiles(string[] files)
        {
            // Example: Adjust the form size based on the number of files dropped
            int newWidth = Math.Max(this.Width, 600); // Adjust width as needed
            int newHeight = Math.Max(this.Height, 400); // Adjust height as needed

            this.Size = new System.Drawing.Size(newWidth, newHeight);
        }
    }
}
