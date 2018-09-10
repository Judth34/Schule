if($1 -eq ())
{
	fehler1
}

function fehler1{
	write-host "Das Programm muss mit einem Startwert groesser 0 aufgerufen werden"
}

$ha=Read-Host "Press ENTER"