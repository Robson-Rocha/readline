#!/usr/bin/env bash

if [[ !$1 ]]; then
    CONFIGURATION="Debug"
fi

if [[ $1 ]]; then
    CONFIGURATION=$1
fi

dotnet restore
dotnet build ./src/ReadLine2 -c $CONFIGURATION
dotnet build ./src/ReadLine2.Demo -c $CONFIGURATION
dotnet build ./test/ReadLine2.Tests -c $CONFIGURATION
