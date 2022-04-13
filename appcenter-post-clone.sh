#!/usr/bin/env bash

echo "appcenter-post-clone script: Remove Projects from Solution"
echo "Searching for Solution Files"
SLN_PATH=$(find $APPCENTER_SOURCE_DIRECTORY -iname '*.sln' -type f -print0)    

if [ -z "$SLN_PATH" ]
then 
    echo "No Solution Found. Exiting Script."
    exit 
else
    echo "SLN_PATH = $SLN_PATH"
fi

if [ -z "$RemoveUWPProjects" ]
then 
    echo "Do Not Remove RemoveUWPProjects"
else
    echo "Searching for UWP Projects"
    echo "UWP_PATHS=$(find $APPCENTER_SOURCE_DIRECTORY -iname '*UWP*.csproj' -type f -print0)"
    UWP_PATHS=$(find $APPCENTER_SOURCE_DIRECTORY -iname '*UWP*.csproj' -type f -print0)
    if [ -z "$UWP_PATHS" ]
    then 
        echo "No UWP CSPROJ files found. No Action taken."
    else
        echo " UWP_PATHS = $UWP_PATHS"

        for p in "$UWP_PATHS"; do
            echo "Removing $p from $SLN_PATH" || true
            dotnet sln $SLN_PATH remove $p || true
        done
    fi
fi

if [ -z "$RemoveANDROIDProjects" ]
then 
    echo "Do Not Remove RemoveANDROIDProjects"
else
    echo "Searching for Android Projects"
    echo "ANDROID_PATHS=$(find $APPCENTER_SOURCE_DIRECTORY -iname '*Android*.csproj' -type f -print0 )"
    ANDROID_PATHS=$(find $APPCENTER_SOURCE_DIRECTORY -iname '*Android*.csproj' -type f -print0 )

    if [ -z "$ANDROID_PATHS" ]
    then
        echo "No Android CSPROJ files found. No Action taken."
    else

        echo "ANDROID_PATHS = $ANDROID_PATHS"

        for p in "$ANDROID_PATHS"; do
            echo "Removing $p from $SLN_PATH" || true
            dotnet sln $SLN_PATH remove $p || true
        done
    fi
fi

if [ -z "$RemoveIOSProjects" ]
then 
    echo "RemoveIOSProjects"
else
    echo "Searching for Android Projects"
    echo "IOS_PATHS=$(find $APPCENTER_SOURCE_DIRECTORY -iname '*IOS*.csproj' -type f -print0 )"
    IOS_PATHS=$(find $APPCENTER_SOURCE_DIRECTORY -iname '*IOS*.csproj' -type f -print0 )

    if [ -z "$IOS_PATHS" ]
    then
        echo "No iOS CSPROJ files found. No Action taken."
    else

        echo "IOS_PATHS = $IOS_PATHS"

        for p in "$IOS_PATHS"; do
            echo "Removing $p from $SLN_PATH" || true
            dotnet sln $SLN_PATH remove $p || true
        done   
    fi 
fi