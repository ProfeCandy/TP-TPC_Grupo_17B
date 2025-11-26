Write-Host "Limpiando archivos temporales y binarios..." -ForegroundColor Yellow

Write-Host "Deteniendo procesos de IIS Express..." -ForegroundColor Cyan
Get-Process | Where-Object {$_.ProcessName -like "*iisexpress*"} | Stop-Process -Force -ErrorAction SilentlyContinue

$tempPaths = @(
    "Frontend\bin\Roslyn",
    "Frontend\bin\Temporary ASP.NET Files",
    "$env:LOCALAPPDATA\Temp\Temporary ASP.NET Files"
)

foreach ($path in $tempPaths) {
    if (Test-Path $path) {
        Write-Host "Eliminando: $path" -ForegroundColor Gray
        Remove-Item -Path $path -Recurse -Force -ErrorAction SilentlyContinue
    }
}

$projects = @("Frontend", "Negocio", "Dominio", "DTO")
foreach ($project in $projects) {
    $binPath = "$project\bin"
    $objPath = "$project\obj"
    
    if (Test-Path $binPath) {
        Write-Host "Limpiando bin de $project..." -ForegroundColor Gray
        Remove-Item -Path $binPath -Recurse -Force -ErrorAction SilentlyContinue
    }
    
    if (Test-Path $objPath) {
        Write-Host "Limpiando obj de $project..." -ForegroundColor Gray
        Remove-Item -Path $objPath -Recurse -Force -ErrorAction SilentlyContinue
    }
}

Write-Host "`nLimpieza completada. Ahora puedes recompilar la solución." -ForegroundColor Green
Write-Host "En Visual Studio: Build > Clean Solution, luego Build > Rebuild Solution" -ForegroundColor Cyan
