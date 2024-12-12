#!/bin/bash

# Validate that argument was given
if [ -z "$1" ]; then
    echo "Usage: CreateNewDay.sh <day number>"
    exit 1
fi

# Validate that argument is a number
if ! [[ "$1" =~ ^[0-9]+$ ]]; then
    echo "Error: Argument must be a number"
    exit 1
fi

# Add padding to day number less than 10
if [ $1 -lt 10 ]; then
    day="0$1"
else
    day="$1"
fi

# Validate that the day does not already exist
if [ -d "Day_$day" ]; then
    echo "Error: Day $1 already exists"
    exit 1
fi

# Create new c# console project 
dotnet new console --output "./Day_$day"

# Copy template project file to new project
cp ./Template/Project "./Day_$day/Day_$day.csproj"

# Add reference to new project
dotnet sln add "./Day_$day"

# Add reference to new project in test project
dotnet add "./Tests" reference "./Day_$day"