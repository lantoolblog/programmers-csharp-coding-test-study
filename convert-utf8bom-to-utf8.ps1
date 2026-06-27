# UTF-8 BOM을 UTF-8로 변환하는 스크립트
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $scriptDir

$extensions = @("*.cs", "*.csproj", "*.resx", "*.sln", "*.slnx")
$convertedCount = 0

Write-Host "====================================" -ForegroundColor Green
Write-Host "UTF-8 BOM -> UTF-8 Converter" -ForegroundColor Green
Write-Host "====================================" -ForegroundColor Green
Write-Host ""

# 프로젝트 디렉토리 목록
$projectDirs = @(
    "Programmers.Solutions",
    "Programmers.Solutions.Modern",
    "Programmers.Solutions.tests"
)

# 각 프로젝트 디렉토리 순회
foreach ($projectDir in $projectDirs) {
    $projectPath = Join-Path $scriptDir $projectDir

    if (Test-Path $projectPath) {
        Write-Host "Processing $projectDir directory..." -ForegroundColor Cyan

        foreach ($ext in $extensions) {
            $files = Get-ChildItem -Path $projectPath -Filter $ext -Recurse -File

            foreach ($file in $files) {
                # 파일의 첫 3바이트 읽기 (BOM 확인)
                $bytes = [System.IO.File]::ReadAllBytes($file.FullName)

                # UTF-8 BOM (EF BB BF) 확인
                if ($bytes.Length -ge 3 -and $bytes[0] -eq 0xEF -and $bytes[1] -eq 0xBB -and $bytes[2] -eq 0xBF) {
                    Write-Host "  Converting: $($file.FullName)" -ForegroundColor Yellow

                    # BOM 제거하고 다시 쓰기
                    $content = [System.IO.File]::ReadAllText($file.FullName)
                    $utf8NoBom = New-Object System.Text.UTF8Encoding $false
                    [System.IO.File]::WriteAllText($file.FullName, $content, $utf8NoBom)

                    Write-Host "    [OK] Converted" -ForegroundColor Green
                    $convertedCount++
                }
            }
        }
    }
    else {
        Write-Host "  Directory not found: $projectPath" -ForegroundColor Red
    }
}

Write-Host ""
Write-Host "====================================" -ForegroundColor Green
Write-Host "Conversion completed!" -ForegroundColor Green
Write-Host "Total files converted: $convertedCount" -ForegroundColor Green
Write-Host "====================================" -ForegroundColor Green
