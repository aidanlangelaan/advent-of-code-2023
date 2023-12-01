Write-Output "--- Advent of Code - Challenge generator ---`r`n`r`n"

$DayNumber = Read-Host -Prompt 'Input the day to generate, e.g. "04"'

$ChallengeDirectory = "src\AdventOfCode.Console\Challenges\Day$DayNumber"
$TestDirectory = "src\AdventOfCode.Tests"

if (Test-Path "..\$ChallengeDirectory") {
    Write-Warning "Challenge Day$DayNumber already exists."
    Read-Host -Prompt "Press Enter to exit"
    return
}

New-Item -Path "..\$ChallengeDirectory" -ItemType Directory | Out-Null
Write-Output "`r`nGenerated challenge directory: $ChallengeDirectory`r`n"

New-Item -Path "..\$ChallengeDirectory\Day$DayNumber.cs" -ItemType File | Out-Null
$ChallengeCode = (Get-Content -path "templates/Challenge.template") -replace "{{day_number}}", $DayNumber
Set-Content -Path "..\$ChallengeDirectory\Day$DayNumber.cs" -Value $ChallengeCode
Write-Output "Generated challenge code: Day$DayNumber.cs`r`n"

New-Item -Path "..\$ChallengeDirectory\Input.txt" -ItemType File | Out-Null
Write-Output "Generated challenge input file: Input.txt`r`n"

New-Item -Path "..\$ChallengeDirectory\.solution" -ItemType File | Out-Null
Write-Output "Generated challenge solution file: .solution`r`n"

New-Item -Path "..\$ChallengeDirectory\Instruction.md" -ItemType File | Out-Null
Write-Output "Generated challenge instructions file: Instruction.md`r`n"

New-Item -Path "..\$TestDirectory\Day$($DayNumber)Tests.cs" -ItemType File | Out-Null
$TestCode = (Get-Content -path "templates/Tests.template") -replace "{{day_number}}", $DayNumber
Set-Content -Path "..\$TestDirectory\Day$($DayNumber)Tests.cs" -Value $TestCode
Write-Output "Generated test code: Day$($DayNumber)Tests.cs`r`n"

Write-Output "--- Completed generation for day $DayNumber ---`r`n"
Read-Host -Prompt "Press Enter to exit"