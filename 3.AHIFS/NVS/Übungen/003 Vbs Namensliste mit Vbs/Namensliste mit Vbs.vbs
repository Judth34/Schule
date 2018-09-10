set fso=createobject("scripting.filesystemobject")
set reader = fso.opentextfile("AlleBenutzerEDVO.dat", 1)
set writer= fso.opentextfile("Freigabenliste.dat", 2)
set reader2 = fso.opentextfile("Freigabenliste.dat", 1)
fso.CreateFolder(".\Erstellte Ordner")

while not reader.atendofstream
	z=reader.readline()
	z = split(z, ";")
	writer.Write(z(0) + "_")
	x = split(z(1), " ")
	writer.Writeline(x(1))
	
	fso.CreateFolder(".\Erstellte Ordner" + z(0) + "_" + x(1))
wend
reader.close
writer.close
reader2.close