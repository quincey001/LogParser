# Changes Parser

## Overview
The **Changes Parser** is a .NET console application that parses a change history log from a `ChangeHistory.txt` file and outputs a formatted `ParsedChangeHistory.txt` file. The project follows SOLID principles and includes robust exception handling for handling file operations.

## Project Structure


- **Parser.csproj**: Project file for .NET.
- **Program.cs**: Main entry point for the console application.
- **Interfaces/IParser.cs**: Interface for the parser to follow SOLID principles.
- **Entities/Change.cs & Item.cs**: Represent the parsed data entities.
- **Resource/ChangeHistory.txt**: Input file containing the change history.
- **Resource/ParsedChangeHistory.txt**: Output file containing the parsed data.

## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) version 6.0 or higher.
- A code editor (Visual Studio Code, Visual Studio, etc.).

### Setup
To set up and run this project on your local machine, follow these steps:

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-repo/changes-parser.git

2. **Navigate to the Project Folder:
    '''bash
    cd Parser

3. **Restore Dependencies:
    '''bash
    dotnet restore

4. **Build the Project:
    '''bash
    dotnet build

5. **Run the Project:
    '''bash
    dotnet run


## Input and Output Files
* Input File: The project expects a file named ChangeHistory.txt
* Format:
   ```bash
    12/01/2004, Johnason
    *) Add code to delete transactions from nist_ipa
    Changed files:
    - SystemTrans.cpp
    - SystemTransNew.cpp
    - SystemTrans.h
    Description:
    - Add one new function: CLSTransDeleteException
    - Call this new function in CLSTransDeleteRec() and CLSTransNewDeleteRec()
    - In this case, these four tables should not be put in INFO_TABLE. Before
    we put them into it, which will cause a bug: When the transaction has
    exception and has been scanned, the exception will be removed if user
    views demo and saves it.
    *) Add code to nist_ipa_print
    Changed files:
    - System.cpp  

* Output File: The parsed data will be saved in a file called ParsedChangeHistory.txt in the Resource folder.
* Format:
   ```bash
    Change ID:4|
    Changed Date:12/01/2004|
    Changed By: Johnason
    Summary: Add code to delete transactions from nist_ipa, nist_ipa_pm, Add code to nist_ipa_print|
    Description:- Add one new function: CLSTransDeleteException- Call this new function in CLSTransDeleteRec() and CLSTransNewDeleteRec()- In this case, these four tables should not be put in INFO_TABLE. Beforewe put them into it, which will cause a bug: When the transaction hasexception and has been scanned, the exception will be removed if userviews demo and saves it.|
    Purpose:|
    Changed Files:- SystemTrans.cpp- SystemTransNew.cpp- SystemTrans.h, System.cpp |
    Added Files:

## Project Design
SOLID Principles
This project adheres to SOLID principles:

Single Responsibility Principle (SRP): Each class has a specific responsibility (e.g., Change represents a change entity, ChangesParser handles parsing logic).
Open/Closed Principle (OCP): The IParser interface allows for extension without modifying existing code.
Dependency Inversion Principle (DIP): The ChangesParser class depends on abstractions (IParser), promoting flexibility and testability.

## Exception Handling
The project uses comprehensive exception handling, ensuring that errors related to file reading, writing, or parsing are caught and managed appropriately.
