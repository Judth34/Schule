/*
 ============================================================================
 Name        : c.c
 Author      : 
 Version     :
 Copyright   : Your copyright notice
 Description : Hello World in C, Ansi-style
 ============================================================================
 */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "Person.h"      // der pre-processor inkludiert alles aus dem file Person.h

#define NUM 10

int main(void) {
	int    i;
	Person p;
	Person lst[NUM];
	char   tmp[10];

	p.svnr = -1;
	strcpy(p.famName,"Boss");
	strcpy(p.vorNamen,"Huge the little");
	p.geschlecht = Weibl;
	p.alter = 25;

	showPerson(&p);

	for (i=0; i<NUM; i++) {
		sprintf(tmp, "%d", i);     // convert int to string intto tmp
		lst[i].svnr = i+100;
		strcpy(lst[i].famName, "Tobi-1");
		strcat(lst[i].famName, tmp);
		strcpy(lst[i].vorNamen, "As-");
		strcat(lst[i].vorNamen, tmp);
		lst[i].alter = i * (-1);
	}
	showPerson(&lst[3]);

	return 0;
}
