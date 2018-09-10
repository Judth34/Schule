set fso=createobject("scripting.filesystemobject")
set f = fso.opentextfile("geburtstage.dat", 1)
allNames = ""

while not f.atendofstream
	DateWithName = f.readline 		'readall liest die ganze Datei auf einmal
	ArrayDateAndName = split(DateWithName, " ")
	dateSplited = split(ArrayDateAndName(0), ".") 
	actDate = date()
	actDateSplited = split(actDate, ".")
	If (actDateSplited(0) + actDateSplited(1)) - (dateSplited(0) + dateSplited(1)) < 14 then
	allNames = allNames + vbcrlf + DateWithName 
	End If
wend
f.close

msgBox(allNames)

