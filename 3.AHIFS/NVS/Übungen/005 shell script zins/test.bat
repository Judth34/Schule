::Das folgende Batch - Programm zeigt ein paar Techniken von Batch-Dateien. 
::Es berechnet das Produkt aller Zahlen zwischen einem Startwert, der als 
::Konsolenparameter übergeben wird und einem Endwert, den der Benutzer während 
::des Ablaufs eingibt

@echo off

if(%1)==() goto fehler1 s  ::Falls der Konsolenparameter ganz vergessen wurde


if (%1)==(/?) (		  
echo Hilfe zur Verwendung des Programms:
echo.Aufruf des Programms mit test Startwert.
echo.Dabei muss Startwert eine Zahl groesser als 0 sein!
echo.
goto ende
)

if %1 LEQ 0 goto fehler1

:nochmal
echo Endwert: 
set /p b=			
if %b% LSS %1 (
echo.Der Endwert muss groesser gleich %1 sein
goto nochmal
)

set /A erg=1
for /L %%a in (%1,1,%b%) do set /A erg=%%a*erg

echo.Hallo %username% - das Produkt der Zahlen von %1 bis %b% ergibt %erg%
goto ende

:fehler1
echo.Das Programm muss mit einem Startwert groesser 0 aufgerufen werden
echo.

:ende
pause

::Die Variablen wieder freigeben
set b=
set erg=

rem eine gute Seite für Befehle in Batch-Files ist übrigens 
rem http://mitglied.multimania.de/rblaettler/teko/ntbatch.htm
