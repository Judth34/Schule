int zustand;
int i;

void setup() {
  zustand = 0;
  i = 0;
  
  pinMode(1, OUTPUT);
  pinMode(2, OUTPUT);
  pinMode(3, OUTPUT);

  pinMode(7, INPUT_PULLUP);
  attachInterrupt(4, knopfdruck, FALLING);
}

void loop() {
  switch(zustand)
  {
    case 0://rot
      while(i < 500)
      {
        digitalWrite(1, HIGH);
        digitalWrite(2, LOW);
        digitalWrite(3, LOW);
        i++;
        delay(50);
      }
      i=0;
      zustand = 1;
    break;
    case 1://rot-gelb
      while(i < 500)
      {
        digitalWrite(1, HIGH);
        digitalWrite(2, HIGH);
        digitalWrite(3, LOW);
        i++;
        delay(50);
      }
      i=0;
      zustand = 2;
    break;
    case 2://grün

        while(zustand == 2){
        digitalWrite(1, LOW);
        digitalWrite(2, LOW);
        digitalWrite(3, HIGH);
        delay(50);
        }
        i=0;
    break;
    case 3://grün blinkend
      while(i<500)
      {
        if(i%2==0){        
          digitalWrite(1, LOW);
          digitalWrite(2, LOW);
          digitalWrite(3, HIGH);
        }
        else{
          digitalWrite(1, LOW);
          digitalWrite(2, LOW);
          digitalWrite(3, LOW);
        }
        i++;
        delay(50);
      }
      i=0;
      zustand = 4;
    break;
    case 4://gelb
      while(i<500)
      {
        digitalWrite(1, LOW);
        digitalWrite(2, HIGH);
        digitalWrite(3, LOW);
        i++;
        delay(50);
      }
      i=0;
      zustand = 0;
    break;
  }
}

void knopfdruck()
{
  zustand = 3;
}

