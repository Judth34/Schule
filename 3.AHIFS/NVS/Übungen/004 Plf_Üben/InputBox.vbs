X = msgbox("Hallo willst du mit mir spielen?", vbYesNo, "Titel")

on error resume next
asdf
if x=vbyes	 then
y=InputBox("Was möchtest du spielen?")
x = msgbox("Also du willst " + y + " spielen?", vbYesNo)
else

on error goto 0
asdf

z=msgbox("Warum nicht? :o", vbWarning, "Titel")

end if