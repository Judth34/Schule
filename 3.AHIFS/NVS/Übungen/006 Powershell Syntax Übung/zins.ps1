Param(
  [float]$d,  #Dauer
  [float]$z,  #Zinssatz
  [float]$k  #Startkapital
)

if($args[0] -eq "-help" ) 
{
	write-host " Aufruf: .\zins -d Dauer  -z  Verzinsung -k Startkapital"
	write-host " Beispiel: .\zins -d 10 -z 3.2 -k 10000"
	exit
}

if (!$d) {  $d=read-host -pr "Gib die Dauer der Veranlagung ein"  }
if (!$z){   $z=read-host -pr "Gib die Verzinsung ein"  }
if (!$k){   $k=read-host -pr "Gib das Startkapital ein"  }

for ($i=1; $i -le $d; $i++) {
   $k=$k+$k*$z/100
}
write-host  -nonewline "Endkapital: " 
write-host $k  -foregroundcolor "yellow"
