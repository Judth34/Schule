@echo off
set /p kapital= Geben Sie das Kapital ein:
set /p zins= Geben Sie den Zinssatz ein:  
set /p laufzeit=Geben sie die Laufzeit ein 

for /L %%N IN (1, 1, %laufzeit%) DO (
	set a/ %guthaben%=%guthaben%+%kapital%*%zins%/100
)
echo Ihr Guthaben nach %laufzeit% Jahren beträgt %guthaben%
@pause