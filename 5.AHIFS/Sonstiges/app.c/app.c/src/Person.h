/*
 * Person.h
 *
 * Demonstriert die Verwendung eines C header files. Ein solches file enthaelt nur
 * Deklarationen von Typen und Prototypen von Funktionen, also WAS gibt es an Typen
 * und Funktionen ohne anzugeben WIE es geschieht.
 *
 *  Created on: 28 May 2018
 *      Author: ChE
 */

#ifndef PERSON_H_
#define PERSON_H_           // damit wird verhindert, dass alles von diesem header file zwei- oder mehrmals
                            // inkludiert wird

#define LENGTH 64           // maximale Laenge eines Strings

enum e_Geschlecht {Mandl, Weibl, Inter};    // e_Geschlecht ist eine Aufzaehlung, engl. enumeration

typedef enum e_Geschlecht Geschlecht;        // Geschlecht ist ein Alias fuer den Typ "enum e_Geschlecht"

struct t_Person {                 // der Typ t_Person ist eine Strukur bestehend aus
	int        svnr;              // einer Sozialversicherungsnummer als Zahl
	char       famName[LENGTH];   // einem Familiennamen als String
	char       vorNamen[LENGTH];  // mehreren Vornamen als ein String
	Geschlecht geschlecht;        // einem Geschlecht
	int        alter;             // und einem Alter als Zahl
};

typedef struct t_Person Person;   // Person ist ein Alias fuer den Typ "struct t_Person"


// Initialisiert die Liste von Personen list der Laenge len
void Init(Person list[], int len);


// Fuegt die gegegebene Person p in die Liste list der Laenge len ein.
// Liefert einen positiven Wert falls p eingefuegt werden konnte, oder -1 ein falls nicht, zB
// wenn die Sozialversicherungsnummer bereits in der Liste existiert. Liefert -2 falls die Liste
// bereits voll ist, oder -3 falls die Daten von p nicht plausibel sind.
int AddPerson(Person p, Person list[], int len);


// Entfernt die Person mit der gegebenen Sozialversicherungsnummer svnr aus der Liste list
// von Personen. Liefert einen positiven Wert falls es geklappt hat, oder -1 andernfalls.
int RemovePerson(int svnr, Person list[], int len);


// Liefert entweder einen pointer auf eine Person in der Liste falls die gegebene Sozialversicherungsnummer
// svnr existiert oder NULL andernfalls
Person* findPerson(int svnr, Person list[], int len);


// Liefert die Anzahl von Personen in der Liste list der Laenge len.
int size(Person list[], int len);

// Zeigt die Daten der gegebenen Person p auf der Console an.
void showPerson(Person *p);


#endif /* PERSON_H_ */
