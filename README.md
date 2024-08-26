[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/G2G612DOPI)

----------------------------------------------
STREAMSCHEDULER
STREAMSCHEDULER is a console application written in C# that helps you manage and schedule your streaming times throughout the week. It allows users to input, update, and delete stream times for each day of the week, providing a simple way to organize your streaming schedule.

----------------------------------------------
FEATURES
Weekly Schedule Management: Schedule stream times for each day of the week.
File-based Storage: Saves schedule data in text files for each day within a dedicated folder.
Input Flexibility: Allows for entering stream times, skipping days, or clearing data for specified days.
Time Validation: Ensures that entered times are in the correct 24-hour or 12-Hour clock format.
Bulk Deletion: Provides the option to delete schedule data for a specific number of consecutive days.


----------------------------------------------
GETTING STARTED

Prerequisites

.NET SDK installed (version 6.0 or later recommended).

----------------------------------------------
USAGE


When prompted, enter the stream time for each day of the week in 24-hour or 12-Hour clock format (e.g., 14:00 for 2 PM or 2:00 PM).
You can type n to clear the stream time for a day, s to skip editing a day, or d to delete the content for the current day and the subsequent days.
Follow the prompts to specify the number of days to delete if you choose the d option.



Example:
-----------------------------------------------
Enter the time for Monday (24-hour or 12-Hour clock format), 'n' for none, 's' to skip, or 'd' to delete remaining days:
14:00
Monday is updated with time: 14:00

Enter the time for Tuesday (24-hour or 12-Hour clock format), 'n' for none, 's' to skip, or 'd' to delete remaining days:
s
Tuesday is skipped, retaining the current content.

Enter the time for Wednesday (24-hour or 12-Hour clock format), 'n' for none, 's' to skip, or 'd' to delete remaining days:
d
Enter the number of subsequent days to delete (including today):
2
Deleted content for Wednesday.
Deleted content for Thursday.

OBS Quick Set-up Lua Script 
----------------------------------------------


OBS INTEGRATION
Lua Script for OBS Studio
The setup includes a Lua script for OBS Studio located in the scripts folder. The script is named "Week Setup OBS QUICK INSTALL.lua". This script automates the process of setting up scenes for each day of the week in OBS Studio.

Steps to Use the Lua Script with OBS Studio

Open OBS Studio:

Launch OBS Studio on your computer.

Access the Scripts Menu:

Go to Tools in the top menu.
Select Scripts from the dropdown menu to open the Scripts dialog.

Add the Lua Script:

In the Scripts dialog, click on the + button to add a new script.
Navigate to the scripts folder where your Lua script is located.
Select "Week Setup OBS QUICK INSTALL.lua" and click Open.

Configure the Script:

After adding the script, it will appear in the list of scripts in the Scripts dialog.
Configure any script-specific settings if required.

Run the Script:

Click on the Setup Week button in the Scripts dialog to execute the script. This will create and configure text sources in your current OBS scene based on the Lua script logic.

Verify the Setup:

Check your OBS scene to ensure that text sources for each day of the week have been created and are correctly linked to the corresponding text files.
----------------------------------------------

AUTHOR
This project is maintained by @DrPeepPeep.
----------------------------------------------
LICENSE
This project is licensed under the MIT License - see the LICENSE file for details.
