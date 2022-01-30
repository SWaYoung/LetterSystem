# LetterSystem

## Assumptions
1. The CombinedLetters folder exists and is strictly structed as described in the "Application Programmer Coding Exercise.pdf"
2. Students can have scholarship letters only if they have amission letters.
3. The Admissions Office and the Financial Aid Office never make mistaks, which means the admission letters and scholarship letters inside the Input folder never have any problems.
4. It's not clear how we should combine admission letters with no corresponding scholarship letter. The "Application Programmer Coding Exercise.pdf" only indicates we should move letters from Input to Archive. So I make following assumptions:
   - If an admission letter has a corresponding scholarship letter, two letters will be combined and output to the Outpu folder with file name as "combined-*studentID*.txt"
   - If an admission letter has no corresponding scholarship letter, it stil generate a combined letter with file name as "combined-*studentID*.txt", which can be seen as combining an admission letter with an empty letter.
5. Input for the console app must be valid.

## Structure of Code
This solution contains three part: AdmissionsOfficeFinancialAidOffice, PrintingMailingServicesDepartment, LetterSystem:

### AdmissionsOfficeFinancialAidOffice
- It simulate the Admission Office and the Financial Aid Office, which can generate letters into the Input folder using CreateLetters()
- CreateLetters() takes four input:
  - folderPath: the path of the CombinedLetters folder
  - currenDate: yyyymmdd, it's the date when letters are created
  - aNumber: number of admission letters
  - sNumber: number of scholarship letters, notice that sNumber < aNumber

### PrintingMailingServicesDepartment
- It simulate the Printing and Mailing Services Department, which process letters:
  - Combining letters
  - Move processed letters from Input to Archive
  - Write a report of combined letters
- It has two functions, ProcessLetters(), CombineTwoLetters():
  - CombineTwoLetters():
    - It takes the path of an admission letter and the path of a schloarship letter(can be null), and the path of where you want the combined file to be output.
  - ProcessLetters():
    - It handles everything and it calls CombineTwoLetters() when combining letters
    - It takes two input:
       -  folderPath: the path of the CombinedLetters folder
       -  currentDate: yyyymmdd, it's the date when letter combination app started
    - Combined leters are output to the Output folder with following structure:
      - ```
        Output
        |---- yyyymmdd
        |     |---- combined-xxxxxxxx.txt
        |     |---- combined-xxxxxxxx.txt
        |     |---- ...
        |     |---- combined-xxxxxxxx.txt
        |     |---- report.txt
        |---- yyyymmdd
        |     |---- combined-xxxxxxxx.txt
        |     |---- combined-xxxxxxxx.txt
        |     |---- ...
        |     |---- combined-xxxxxxxx.txt
        |     |---- report.txt
        |---- ...
        ```
  
    - After being combined, letters in Input folder will be moved to Archive folder with following structre:
      - ```
        Archive
        |---- yyyymmdd
        |     |---- Admission
        |     |     |---- admission-xxxxxxxx.txt
        |     |     |---- admission-xxxxxxxx.txt
        |     |     |---- ...
        |     |     |---- admission-xxxxxxxx.txt
        |     |---- Scholarship
        |           |---- scholarship--xxxxxxxx.txt
        |           |---- scholarship--xxxxxxxx.txt
        |           |---- ...
        |           |---- scholarship--xxxxxxxx.txt
        |---- yyyymmdd
        |     |---- Admission
        |     |     |---- admission-xxxxxxxx.txt
        |     |     |---- admission-xxxxxxxx.txt
        |     |     |---- ...
        |     |     |---- admission-xxxxxxxx.txt
        |     |---- Scholarship
        |           |---- scholarship--xxxxxxxx.txt
        |           |---- scholarship--xxxxxxxx.txt
        |           |---- ...
        |           |---- scholarship--xxxxxxxx.txt
        |---- ...
        ```
    - Notice that yyyymmdd is the date when letter combination app started!!!
    - Sample files are created, so that CombinedLetters folder can be uploaded to Github

### LetterSystem
It's where main function is located, for the details, see the Instruction part.


## Instruction
To start simulation: run the LetterSystem.exe under ./publish folder. \
Once it starts, you can follow the instruction printed on the console.
- First thing to do after it starts is to enter the path to the CombinedLetters folder (be sure it exists)
- Then it will show you five actions that you can choose from:
  - Create Letters (A): 
    - By typing in "A", it will call CreateLetters() and create letters base on your following input.
    - Notice that each time you run CreateLetters(), all the studentID for letters are randomly generated without duplication. However, there is still a chance that duplicated studentID will be generated by runing CreateLetters() multiple times.
  - Combine Letters (P): 
    - By typing in "P", it wil call ProcessLetters() to process and combine letters.
  - Clean up (C): 
    - By typing in "C", it will delete everything newly created inside CombineLetters folder.
  - End simulator and clean up (E): 
    - By typing in "E", it will delete everything newly created inside CombineLetters folder and end the app.
    - It's recommanded to end the app using this action.
  - End simulator without cleaning up (R): 
    - By typing in "R", it will end the app, without cleaning up.

To test the code, you can simulate how it works in real life. Here I'll show three examples based on the "Application Programmer Coding Exercise.pdf"

1. Normal case: everyday new letters generated, on the next day letters are combined.
    - Choose action Create Letters, with date 20220101, any number of admission letter, any number for scholarship letter.
    - Choose action Combine letters, with date 20220102.
    - repeat...
2. What will happen if a person accidentally runs the Console app before or after the scheduled time?
   - If runs before scheduled time, it means maybe there's no letter to combine or there will be new letters generated for the same day after letter combination.
   - Choose action Combine Letters, with date 20220103.
   - Choose action Create Letters, with date 20220104, any number of admission letter, any number for sholarship letter.
   - Choose action Combine Letters, with date 20220104.
   - hoose action Create Letters, with date 20220104, any number of admission letter, any number for sholarship letter.
   - Choose action Combine Letters, with date 20220104.
   - ...
3. What will happen if the Console app wasn’t run previous day, and it runs today?
   - Choose action Create Letters, with date 20220105, any number of admission letter, any number for sholarship letter.
   - Choose action Create Letters, with date 20220106, any number of admission letter, any number for sholarship letter.
   - Choose action Create Letters, with date 20220107, any number of admission letter, any number for sholarship letter.
   - Choose action Combine Letters, with date 20220108.
   - ...
 - When exiting the app, it's recommanded to use action End simulator and clean up (E).
  
## Hours
- Estimated hours: 24H
- Actual hours: 15H