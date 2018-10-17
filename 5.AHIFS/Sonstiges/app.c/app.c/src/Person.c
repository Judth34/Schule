#include "Person.h"
#include <stdio.h>


// in diesem source code file Person.c stehen die Implementierungen der Funktionen,
// dh WIE ist die Funktion jeweils ausprogrammiert


void showPerson(Person *p) { // p-> ist die Abkuerzung fuer die Dereferenzierung mittels (*p).alter
	printf("svnr: %d, name: %s %s, alter: %d", p->svnr, p->vorNamen, p->famName, p->alter);
	switch (p->geschlecht) {
	   case Mandl:   printf("is a Mankale"); break;
	   case Weibl:   printf("is a Weibale"); break;
	   case Inter:   printf("is a Inter"); break;
	   default:      printf("is a ???"); break;
	}
	printf("\n");
}

